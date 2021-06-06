.assembly extern mscorlib
{  
   .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
   .ver 4:0:0:0
}
// Our assembly.
.assembly CILTypes
{
.ver 1:0:0:0
}
// The module of our single-file assembly.
.module CILTypes.dll

// Our assembly has a single namespace.
.namespace CIL {
        // System.Object base class assumed.
      .class public MyBaseClass{
      
      }
}
// A structure definition is always sealed.
.class public sealed MyStruct
extends [mscorlib]System.ValueType{}

// Shorthand notation for declaring a structure.
.class public sealed value MyStruct{}


// An enum.
.class public sealed MyEnum
extends [mscorlib]System.Enum{}

// Enum shorthand.
.class public sealed enum MyEnum
{
.field public static literal valuetype
MyNamespace.MyEnum A = int32(0)
.field public static literal valuetype
MyNamespace.MyEnum B = int32(1)
.field public static literal valuetype
MyNamespace.MyEnum C = int32(2)
}


// In C#: List<int> myInts = new List<int>();
newobj instance void class [mscorlib]
System.Collections.Generic.List`1<int32>::.ctor()

// In C#: List<List<int>> myInts = new List<List<int>>();
newobj instance void class [mscorlib]
System.Collections.Generic.List`1<class
[mscorlib]System.Collections.Generic.List`1<int32>>::.ctor()

// In C#: Dictionary<string, int> d = new Dictionary<string, int>();
newobj instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::.ctor()


//root namespace
/*.namespace MyCompany
//{
//.namespace MyNamespace {}
//}

// Defining a nested namespace.
//.namespace MyCompany.MyNamespace {}

//// An interface definition.
//.class public interface IMyInterface {}

// A simple base class.
.class public MyBaseClass {
.field private string stringField = "hello!"
.field private int32 intField = int32(42)
.method public hidebysig specialname
instance string get_TheString() cil managed
{
// TODO: Add implementation code...
}
.method public hidebysig specialname
instance void set_TheString(string 'value') cil managed
{
// TODO: Add implementation code...
}
.property instance string TheString()
{
.get instance string
MyNamespace.MyBaseClass::get_TheString()
.set instance void
MyNamespace.MyBaseClass::set_TheString(string)
}
.method public hidebysig specialname rtspecialname
instance void .ctor(string s, int32 i) cil managed
{
// TODO: Add implementation code...
}
}

.method public hidebysig static void MyMethod(int32 inputInt,
int32& refInt,
class [mscorlib]System.Collections.ArrayList ar,
[out] int32& outputInt) cil managed
{

}

.method public hidebysig static int32 Add(int32 a,
int32 b) cil managed
{
.maxstack 2
ldarg.0 // Load "a" onto the stack.
ldarg.1 // Load "b" onto the stack.
add // Add both values.
ret
}

// MyDerivedClass now implements IMyInterface,
// and extends MyBaseClass.
//.class public MyDerivedClass
//extends MyNamespace.MyBaseClass
//implements MyNamespace.IMyInterface {}

// A simple base class.
//.class public MyBaseClass {}
// MyDerivedClass now implements IMyInterface,
// and extends MyBaseClass.
//.class public MyDerivedClass
//extends MyNamespace.MyBaseClass
//implements MyNamespace.IMyInterface {}