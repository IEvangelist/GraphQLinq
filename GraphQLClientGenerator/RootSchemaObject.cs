﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GraphQLClientGenerator
{
    public class RootSchemaObject
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("__schema")]
        public Schema Schema { get; set; }
    }

    public class Schema
    {
        public List<Type> Types { get; set; }
        public QueryType QueryType { get; set; }
    }

    public class QueryType
    {
        public string Name { get; set; }
    }

    public class Type : BaseInfo
    {
        public TypeKind Kind { get; set; }
        public List<EnumValue> EnumValues { get; set; }
        public List<Field> Fields { get; set; }
        public List<Type> Interfaces { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeKind
    {
        List,
        [EnumMember(Value = "NON_NULL")]
        NonNull,
        Scalar,
        Object,
        Interface,
        Union,
        Enum,
        [EnumMember(Value = "INPUT_OBJECT")]
        InputObject
    }

    public class EnumValue
    {
        public string Name { get; set; }
    }

    public class Field : BaseInfo
    {
        public FieldType Type { get; set; }
        public List<Arg> Args { get; set; }
    }

    public class FieldType
    {
        public TypeKind Kind { get; set; }
        public string Name { get; set; }
        public FieldType OfType { get; set; }
    }

    public class Arg : BaseInfo
    {
        public FieldType Type { get; set; }
    }

    [DebuggerDisplay("Name = {" + nameof(Name) + "}")]
    public class BaseInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}