using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace ReflectionInCSharp.Tests;

public class ReflectionInCSharpUnitTest
{
    [Fact]
    public void GivenClassNameOrObject_WhenCallsGetType_ThenReturnsType()
    {
        var type1 = typeof(MotionSensor);

        var sensor = new MotionSensor();
        var type2 = sensor.GetType();

        var qualifiedName = "ReflectionInCSharp.MotionSensor, ReflectionInCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        var type3 = Type.GetType(qualifiedName);

        Assert.Equal(type1, type2);
        Assert.Equal(type1, type3);
    }

    [Fact]
    public void GivenClass_WhenExploredAsType_ThenProvidesMetaInformation()
    {
        var type = typeof(MotionSensor);

        Assert.Equal("MotionSensor", type.Name);
        Assert.Equal("ReflectionInCSharp", type.Namespace);
        Assert.Equal("ReflectionInCSharp.MotionSensor", type.FullName);
        Assert.Equal("ReflectionInCSharp.MotionSensor, ReflectionInCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", type.AssemblyQualifiedName);
        Assert.True(type.IsClass);
        Assert.False(type.IsValueType);
    }

    [Fact]
    public void GivenGenericClass_WhenExploredAsType_ThenProvidesGenericInformation()
    {
        var type = typeof(List<string>);

        Assert.True(type.IsGenericType);
        Assert.Single(type.GenericTypeArguments);
        Assert.Equal(typeof(string), type.GenericTypeArguments[0]);
    }

    [Fact]
    public void GivenType_WhenCallsWithActivator_ThenProvidesAnObjectInstance()
    {
        var type = typeof(MotionSensor);

        var sensor1 = Activator.CreateInstance(type)!;
        var sensor2 = Activator.CreateInstance(type, new[] { "left" })!;

        Assert.True(sensor1 is MotionSensor);
        Assert.Equal("*", ((MotionSensor)sensor1).FocalPoint);

        Assert.True(sensor2 is MotionSensor);
        Assert.Equal("left", ((MotionSensor)sensor2).FocalPoint);
    }

    [Fact]
    public void GivenTypeWithoutPublicConstrcutor_WhenCallsWithActivator_ThenProvidesAnObjectInstance()
    {
        var type = typeof(InternalTracker);

        var tracker = Activator.CreateInstance(type, nonPublic: true)!;

        Assert.True(tracker is InternalTracker);
        Assert.Equal(1, ((InternalTracker)tracker).Sequence);
    }

    [Fact]
    public void GivenType_WhenCallsGetMembers_ThenReturnsArrayOfMembers()
    {
        var type = typeof(MotionSensor);

        var members = type.GetMembers();

        Assert.Equal(
@".ctor : Constructor
.ctor : Constructor
MotionDetected : Event
FocalPoint : Field
IsCritical : Method
Observe : Method
Observe : Method
Enabled : Property
Status : Property
add_MotionDetected : Method
remove_MotionDetected : Method
get_Enabled : Method
set_Enabled : Method
get_Status : Method
GetType : Method
ToString : Method
Equals : Method
GetHashCode : Method
".ReplaceLineEndings(), PrintInfo(members));
    }

    [Fact]
    public void GivenType_WhenCallsGetMember_ThenReturnsArrayOfSelectedMembers()
    {
        var type = typeof(MotionSensor);

        var members = type.GetMember(nameof(MotionSensor.Observe))!;

        Assert.Equal(
@"Observe : Method
Observe : Method
".ReplaceLineEndings(), PrintInfo(members));
    }

    [Fact]
    public void GivenType_WhenCallsGetMemberWithNonPublicBindingFlag_ThenReturnsPrivateMembers()
    {
        var type = typeof(MotionSensor);

        var members = type.GetMember("RaiseMotionDetected", BindingFlags.NonPublic | BindingFlags.Instance)!;

        Assert.Single(members);
        Assert.True(((MethodInfo)members[0]).IsPrivate);
    }

    [Fact]
    public void GivenType_WhenCallsGetProperty_ThenReturnsPropertyInfo()
    {
        var type = typeof(MotionSensor);

        var properties = type.GetProperties();
        var statusProperty = type.GetProperty(nameof(MotionSensor.Status))!;

        Assert.Equal(2, properties.Length);
        Assert.Equal(typeof(string), statusProperty.PropertyType);
        Assert.False(statusProperty.CanWrite);
        Assert.True(statusProperty.CanRead);
    }

    [Fact]
    public void GivenPropertyInfo_WhenCallsGetSetValue_ThenManipulatesTargetProperty()
    {
        var sensor = new MotionSensor();

        var enabled = GetPropertyValue(sensor, nameof(sensor.Enabled))!;
        Assert.Equal(false, enabled);

        var status = GetPropertyValue(sensor, nameof(sensor.Status));
        Assert.Equal("Green", status);

        SetPropertyValue(sensor, nameof(sensor.Enabled), true);
        Assert.True(sensor.Enabled);

        Assert.ThrowsAny<ArgumentException>(() => SetPropertyValue(sensor, nameof(sensor.Status), "Yellow"));
    }

    object? GetPropertyValue(object obj, string propertyName)
    {
        var propertyInfo = obj.GetType().GetProperty(propertyName);

        return propertyInfo?.GetValue(obj);
    }

    void SetPropertyValue(object obj, string propertyName, object value)
    {
        var propertyInfo = obj.GetType().GetProperty(propertyName);

        propertyInfo?.SetValue(obj, value);
    }

    [Fact]
    public void GivenType_WhenCallsGetField_ThenReturnsFieldInfo()
    {
        var type = typeof(MotionSensor);

        var fields = type.GetFields();
        var field = type.GetField(nameof(MotionSensor.FocalPoint))!;

        Assert.Single(fields);
        Assert.Equal(typeof(string), field.FieldType);
    }

    [Fact]
    public void GivenType_WhenCallsGetMethod_ThenReturnsMethodInfo()
    {
        var type = typeof(MotionSensor);

        var methods = type.GetMethods();

        var isCritical = type.GetMethod(nameof(MotionSensor.IsCritical));
        Assert.Throws<AmbiguousMatchException>(() => type.GetMethod(nameof(MotionSensor.Observe)));

        var observe1 = type.GetMethod(nameof(MotionSensor.Observe), Type.EmptyTypes)!;
        var observe2 = type.GetMethod(nameof(MotionSensor.Observe), new Type[] { typeof(string) })!;

        Assert.Empty(observe1.GetParameters());
        Assert.Single(observe2.GetParameters());
    }

    [Fact]
    public void GivenMethodInfo_WhenCallsGetParameters_ThenReturnsParameterInfo()
    {
        var method = typeof(MotionSensor).GetMethod(nameof(MotionSensor.IsCritical))!;

        var parameters = method.GetParameters();

        Assert.Single(parameters);
        Assert.Equal("threshold", parameters[0].Name);
        Assert.Equal(typeof(int), parameters[0].ParameterType);

        Assert.Equal(typeof(bool), method.ReturnType);
    }

    [Fact]
    public void GivenMethodInfo_WhenInvokesWithObjectInstance_ThenExecutesTargetMethod()
    {
        var method = typeof(MotionSensor).GetMethod(nameof(MotionSensor.IsCritical))!;

        var sensor1 = new MotionSensor();
        var sensor2 = new MotionSensor();
        sensor2.Observe();

        var result1 = method.Invoke(sensor1, new object[] { 1 });
        var result2 = method.Invoke(sensor2, new object[] { 1 });

        Assert.Equal(false, result1);
        Assert.Equal(true, result2);
    }

    [Fact]
    public void GivenType_WhenCallsGetConstructor_ThenReturnsConstructorInfo()
    {
        var type = typeof(MotionSensor);

        var constructors = type.GetConstructors();
        var constructor1 = type.GetConstructor(Type.EmptyTypes)!;
        var constructor2 = type.GetConstructor(new Type[] { typeof(string) })!;

        Assert.Equal(2, constructors.Length);
        Assert.Empty(constructor1.GetParameters());
        Assert.Single(constructor2.GetParameters());
    }

    [Fact]
    public void GivenType_WhenCallsGetEvent_ThenReturnsEventInfo()
    {
        var type = typeof(MotionSensor);

        var events = type.GetEvents();
        var @event = type.GetEvent(nameof(MotionSensor.MotionDetected))!;

        Assert.Single(events);
        Assert.Equal(typeof(EventHandler<string>), @event.EventHandlerType);
        Assert.True(@event.IsMulticast);
    }

    [Fact]
    public void GivenType_WhenCallsGetInterface_ThenReturnsInterfaceType()
    {
        var type = typeof(MotionSensor);

        var interfaces = type.GetInterfaces();
        var supported = type.GetInterface(nameof(IMotionSensor))!;
        var notSupported = type.GetInterface(nameof(IDisposable));

        Assert.Single(interfaces);
        Assert.Equal(typeof(IMotionSensor), supported);
        Assert.Null(notSupported);
    }

    [Fact]
    public void GivenType_WhenCallsGetCustomAttribute_ThenReturnsTargetAttribute()
    {
        var type = typeof(MotionSensor);

        var classAttribute = type.GetCustomAttribute<DescriptionAttribute>()!;
        var propertyAttribute = type.GetProperty(nameof(MotionSensor.Enabled))!
            .GetCustomAttribute<DescriptionAttribute>()!;

        Assert.Equal("Detects movements in the vicinity", classAttribute.Description);
        Assert.Equal("Turn On/Off", propertyAttribute.Description);
    }

    [Fact]
    public void GivenType_WhenAccessAssemblyProperty_ThenReturnsAssemblyObject()
    {
        var type = typeof(MotionSensor);

        var assembly1 = type.Assembly;
        var assembly2 = Assembly.GetExecutingAssembly();
        var assembly3 = Assembly.GetCallingAssembly();

        Assert.Equal("ReflectionInCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", assembly1.FullName);
        Assert.Equal("ReflectionInCSharp.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", assembly2.FullName);
        Assert.Equal("xunit.execution.dotnet, Version=2.4.1.0, Culture=neutral, PublicKeyToken=8d05b1bb7a6fdb6c", assembly3.FullName);
    }

    [Fact]
    public void GivenAssembly_WhenCallsGetTypes_ThenReturnsAllTypesBelongThere()
    {
        var assembly = typeof(MotionSensor).Assembly;

        var allTypes = assembly.GetTypes();
        var exportedTypes = assembly.GetExportedTypes();

        Assert.NotEmpty(allTypes);
        Assert.Equal(
@"IMotionSensor : TypeInfo
InternalTracker : TypeInfo
MotionSensor : TypeInfo
".ReplaceLineEndings(), PrintInfo(exportedTypes));
    }

    [Fact]
    public void GivenAssembly_WhenCallsGetManifestResourceStream_ThenResourceStream()
    {
        var assembly = typeof(MotionSensor).Assembly;

        using var stream = assembly.GetManifestResourceStream("ReflectionInCSharp.SampleManifest.txt")!;
        using var reader = new StreamReader(stream);
        var content = reader.ReadToEnd();

        Assert.Equal("sample resource content", content);
    }

    string PrintInfo<T>(params T[] members) where T : MemberInfo
    {
        var builder = new StringBuilder();
        foreach(var member in members
            .OrderBy(e => e.DeclaringType == typeof(object))
            .ThenBy(e => e is MethodInfo m && m.IsSpecialName)
            .ThenBy(e => e.MemberType))
        {
            builder.AppendLine($"{member.Name} : {member.MemberType}");
        }

        return builder.ToString();
    }
}