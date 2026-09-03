using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Entities.Models;

public class Entity : DynamicObject, IXmlSerializable, IDictionary<string, object>
{
    private readonly string _root = "Entity";
    private readonly IDictionary<string, object> _expando;

    public Entity()
    {
        _expando = new ExpandoObject()!;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        if (_expando.TryGetValue(binder.Name, out var value))
        {
            result = value;
            return true;
        }

        return base.TryGetMember(binder, out result);
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        _expando[binder.Name] = value!;

        return true;
    }

    public XmlSchema? GetSchema() => null;

    public void ReadXml(XmlReader reader)
    {
        reader.ReadStartElement(_root);

        while (!reader.Name.Equals(_root))
        {
            var name = reader.Name;

            reader.MoveToAttribute("type");
            var typeContent = reader.ReadContentAsString();
            var underlyingType = Type.GetType(typeContent);
            reader.MoveToContent();
            _expando[name] = reader.ReadElementContentAs(underlyingType!, null!)!;
        }
    }

    public void WriteXml(XmlWriter writer)
    {
        foreach (var key in _expando.Keys)
            WriteXmlElement(key, _expando[key], writer);
    }

    private void WriteXmlElement(string key, object value, XmlWriter writer)
    {
        writer.WriteStartElement(key);
        writer.WriteString(value.ToString());
        writer.WriteEndElement();
    }

    public void Add(string key, object value) => _expando.Add(key, value);

    public bool ContainsKey(string key) => _expando.ContainsKey(key);

    public ICollection<string> Keys => _expando.Keys;

    public bool Remove(string key) => _expando.Remove(key);

    public bool TryGetValue(string key, out object value) => _expando.TryGetValue(key, out value!);

    public ICollection<object> Values => _expando.Values;

    public object this[string key]
    {
        get => _expando[key];
        set => _expando[key] = value;
    }

    public void Add(KeyValuePair<string, object> item) => _expando.Add(item);

    public void Clear() => _expando.Clear();

    public bool Contains(KeyValuePair<string, object> item) => _expando.Contains(item);

    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => _expando.CopyTo(array, arrayIndex);

    public int Count => _expando.Count;

    public bool IsReadOnly => _expando.IsReadOnly;

    public bool Remove(KeyValuePair<string, object> item) => _expando.Remove(item);

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _expando.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
