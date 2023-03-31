using AutoMapper;
using DeepCopy;
using FastDeepCloner;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Serialization;

namespace DeepCopyInCSharp
{
    public class DeepCopyMaker
    {
        private readonly IMapper _mapper;

        public DeepCopyMaker()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, Address>();
                cfg.CreateMap<Person, Person>()
                   .ForMember(dest => dest.Address, opt => opt.MapFrom(src => _mapper.Map<Address>(src.Address)));
            });

            _mapper = config.CreateMapper();
        }

        public static T DeepCopyXML<T>(T input)
        {
            using var stream = new MemoryStream();

            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, input);
            stream.Position = 0;

            return (T)serializer.Deserialize(stream);
        }

        public static T DeepCopyJSON<T>(T input)
        {
            var jsonString = JsonSerializer.Serialize(input);

            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public static T DeepCopyDataContract<T>(T input)
        {
            using var stream = new MemoryStream();

            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(stream, input);
            stream.Position = 0;

            return (T)serializer.ReadObject(stream);
        }

        public static T DeepCopyReflection<T>(T input)
        {
            var type = input.GetType();
            var properties = type.GetProperties();

            T clonedObj = (T)Activator.CreateInstance(type);

            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    object value = property.GetValue(input);
                    if (value != null && value.GetType().IsClass && !value.GetType().FullName.StartsWith("System."))
                    {
                        property.SetValue(clonedObj, DeepCopyReflection(value));
                    }
                    else
                    {
                        property.SetValue(clonedObj, value);
                    }
                }
            }

            return clonedObj;
        }

        public static T DeepCopyExpressionTrees<T>(T input)
        {
            return GenerateDeepCopy<T>()(input);
        }

        private static Func<T, T> GenerateDeepCopy<T>()
        {
            var inputParameter = Expression.Parameter(typeof(T), "input");

            var memberBindings = new List<MemberBinding>();
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                var propertyExpression = Expression.Property(inputParameter, propertyInfo);

                if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string))
                {
                    var copyMethod = typeof(DeepCopyMaker)
                        .GetMethod(nameof(DeepCopyMaker.DeepCopyExpressionTrees))
                        .MakeGenericMethod(propertyInfo.PropertyType);

                    var propertyCopyExpression = Expression.Call(copyMethod, propertyExpression);

                    memberBindings.Add(Expression.Bind(propertyInfo, propertyCopyExpression));
                }
                else
                {
                    memberBindings.Add(Expression.Bind(propertyInfo, propertyExpression));
                }
            }

            var memberInitExpression = Expression.MemberInit(Expression.New(typeof(T)), memberBindings);

            return Expression.Lambda<Func<T, T>>(memberInitExpression, inputParameter).Compile();
        }

        public Person DeepCopyAutoMapper(Person input)
        {
            return _mapper.Map<Person>(input);
        }

        public static T DeepCopyFastDeepCloner<T>(T input)
        {
            return (T)DeepCloner.Clone(input);
        }

        public static T DeepCopyLibraryDeepCopy<T>(T input)
        {
            return DeepCopier.Copy(input);
        }

        public static T DeepCopyJsonDotNet<T>(T input)
        {
            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(input);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(serialized);            
        }
    }
}
