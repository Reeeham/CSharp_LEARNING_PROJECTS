using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{ // This enumeration defines the possible targets of an attribute.
//    public enum AttributeTargetss
//    {
//        All, Assembly, Class, Constructor,
//        Delegate, Enum, Event, Field, GenericParameter,
//        Interface, Method, Module, Parameter,
//        Property, ReturnValue, Struct
//    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public VehicleDescriptionAttribute(string vehicalDescription) => Description = vehicalDescription;
        public VehicleDescriptionAttribute() { }
    }
}
