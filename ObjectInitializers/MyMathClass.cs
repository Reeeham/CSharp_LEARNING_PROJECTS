using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    class MyMathClass
    {
        // Error! Can't change a constant! in main method
        //constant fields of a class are implicitly static.
        /// Try to set PI in ctor?
        // Not possible- must assign at time of declaration.
        //the value of constant data must be known at compile time.
        //a read-only field cannot be changed after the initial assignment
        public const double PI = 3.14;

        // Read-only fields can be assigned in ctors,
        // but nowhere else.any attempt to make assignments to a field marked readonly outside the scope of a constructor
        //results in a compiler error
        //Unlike a constant field, read-only fields are not implicitly static.
        //you must explicitly use the static keyword,if you want to expose PI from the classlevel
        //the initial assignment looks similar to that of a constant, it would be easier to simply use the const keyword in the first place,
        //if the value of a static read-only field is not known until runtime, you must use a static constructor
        public readonly double PI2;
        public static readonly double PI3;
        static MyMathClass()
        { PI3 = 3.14; }

        public MyMathClass()
        {
            PI2 = 3.14;
        }
    }
}
