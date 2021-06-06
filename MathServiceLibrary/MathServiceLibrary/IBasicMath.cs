using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathServiceLibrary
{ 
    public class Math
    {
        public static void Success()
        {
            Console.WriteLine("hello guys i'm the most successful person you will see in your entire life");
        }
    }
    [ServiceContract(Namespace = "http://MyCompany.com")]
    public interface IBasicMath
    {
        [OperationContract]
        int Add(int x, int y);
    }
}
