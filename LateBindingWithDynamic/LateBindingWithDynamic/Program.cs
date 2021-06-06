using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace LateBindingWithDynamic
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        private static void AddWithReflection()
        {
            Assembly asm = Assembly.Load("MathLibrary");
            try
            {
                //Get metadata for the simplemath type
                Type type = asm.GetType("MathLibrary.SimpleMath");
                //create a simple math on the fly 
                dynamic obj = Activator.CreateInstance(type);
                //get info for add method
                //MethodInfo mi = type.GetMethod("Add");
                //invoke method with parameters
                //object[] args = { 10, 70 };
                Console.WriteLine("Result is {0} :" ,/*mi.Invoke(obj,args)*/ obj.Add(10,70));

            }catch(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
