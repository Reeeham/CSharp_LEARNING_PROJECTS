using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Must reference System.Runtime.Serialization.Formatters.Soap.dll.
using System.Runtime.Serialization.Formatters.Soap;
// Gain access to the BinaryFormatter in mscorlib.dll.
using System.Runtime.Serialization.Formatters.Binary;
// Defined within System.Xml.dll.
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

namespace SimpleSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Serialization *****\n");
            // Make a JamesBondCar and set state.
            JamesBondCar jbc = new JamesBondCar();
            jbc.canFly = true;
            jbc.canSubmerge = false;
            jbc.theRadio.stationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;
            // Now save the car to a specific file in a binary format.
            SaveAsBinaryFormat(jbc, "CarData.dat");

            Console.WriteLine("***** Fun with Custom Serialization *****");

            // Recall that this type implements ISerializable.
            StringData myData = new StringData();
            // Save to a local file in SOAP format.
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream("MyData.soap",
            FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, myData);
            }
           

            Console.ReadLine();
        }
        static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            // Save object to a file named CarData.dat in binary.
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName,
            FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in binary format!");
        }
        static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            // Read the JamesBondCar from the binary file.
            using (Stream fStream = File.OpenRead(fileName))
            {
                JamesBondCar carFromDisk =
                (JamesBondCar)binFormat.Deserialize(fStream);
                Console.WriteLine("Can this car fly? : {0}", carFromDisk.canFly);
            }
        }
        // Be sure to import System.Runtime.Serialization.Formatters.Soap
        // and reference System.Runtime.Serialization.Formatters.Soap.dll.
        static void SaveAsSoapFormat(object objGraph, string fileName)
        {
            // Save object to a file named CarData.soap in SOAP format.
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream(fileName,
            FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in SOAP format!");
        }
        static void SaveAsXmlFormat(object objGraph, string fileName)
        {
            // Save object to a file named CarData.xml in XML format.
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));
            using (Stream fStream = new FileStream(fileName,
            FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in XML format!");


        }
        static void SaveListOfCars()
        {
            // Now persist a List<T> of JamesBondCars.
            List<JamesBondCar> myCars = new List<JamesBondCar>();
            myCars.Add(new JamesBondCar(true, true));
            myCars.Add(new JamesBondCar(true, false));
            myCars.Add(new JamesBondCar(false, true));
            myCars.Add(new JamesBondCar(false, false));
            using (Stream fStream = new FileStream("CarCollection.xml",
            FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
                xmlFormat.Serialize(fStream, myCars);
            }
            Console.WriteLine("=> Saved list of cars!");

        }
        static void SaveListOfCarsAsBinary()
        {
            // Save ArrayList object (myCars) as binary.
            List<JamesBondCar> myCars = new List<JamesBondCar>();
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("AllMyCars.dat",
            FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, myCars);
            }
            Console.WriteLine("=> Saved list of cars in binary!");
        }
    }
        [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;
        [NonSerialized]
        public string radioID = "XF-552RR6";
    }
    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }
    [Serializable, XmlRoot(Namespace = "http://www.MyCompany.com")]
    public class JamesBondCar : Car
    {
        [XmlAttribute]
        public bool canFly;
        [XmlAttribute]
        public bool canSubmerge;

        public JamesBondCar(bool skyWorthy, bool seaWorthy)
        {
            canFly = skyWorthy;
            canSubmerge = seaWorthy;
        }
        // The XmlSerializer demands a default constructor!
        public JamesBondCar() { }
    }
        [Serializable]
    public class Person
    {
        // A public field.
        public bool isAlive = true;
        // A private field.
        private int personAge = 21;
        // Public property/private data.
        private string fName = string.Empty;
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
    }
    //CustomSerialization
    [Serializable]
    class StringData : ISerializable
    {
        private string dataItemOne = "First data block";
        private string dataItemTwo = "More data";
        public StringData() { }

        protected StringData(SerializationInfo si, StreamingContext ctx)
        {
            // Rehydrate member variables from stream.
            dataItemOne = si.GetString("First_Item").ToLower();
            dataItemTwo = si.GetString("dataItemTwo").ToLower();
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            // Fill up the SerializationInfo object with the formatted data.
            info.AddValue("First_Item", dataItemOne.ToUpper());
            info.AddValue("dataItemTwo", dataItemTwo.ToUpper());
        }
    }
    [Serializable]
    class MoreData
    {
        private string dataItemOne = "First data block";
        private string dataItemTwo = "More data";
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            // Called during the serialization process.
            dataItemOne = dataItemOne.ToUpper();
            dataItemTwo = dataItemTwo.ToUpper();
        }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // Called when the deserialization process is complete.
            dataItemOne = dataItemOne.ToLower();
            dataItemTwo = dataItemTwo.ToLower();
        }
    }
}
