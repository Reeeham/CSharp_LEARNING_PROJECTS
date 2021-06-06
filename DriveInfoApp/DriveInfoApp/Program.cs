using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace DriveInfoApp
{
    [Serializable]
    public class UserPrefs
    {
        public string WindowColor;
        public int FontSize;
    }
    class Program
    {
        static void Main(string[] args)
        {
            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Yellow";
            userData.FontSize = 50;
            // The BinaryFormatter persists state data in a binary format.
            // You would need to import System.Runtime.Serialization.Formatters.Binary
            // to gain access to BinaryFormatter.
            BinaryFormatter binFormat = new BinaryFormatter();
            // Store object in a local file.
            using (Stream fStream = new FileStream("users.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, userData);

            }
            Console.ReadLine();
        }
        static void DriveInfoMethod()
        {
            Console.WriteLine("***** Fun with DriveInfo *****\n");
            // Get info regarding all drives.
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            // Now print drive stats.
            foreach (var drive in myDrives)
            {
                Console.WriteLine("Name {0}", drive.Name);
                Console.WriteLine("Type : {0}", drive.GetType());
                // Check to see whether the drive is mounted.
                if (drive.IsReady)
                {
                    Console.WriteLine("Free space: {0}", drive.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", drive.DriveFormat);
                    Console.WriteLine("Label: {0}", drive.VolumeLabel);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void FileInfoMethod()
        {
            FileInfo f = new FileInfo(@"C:\Test.dat");
            using (FileStream fs = f.Create())
            {
                // Use the FileStream object...
            }
            // Make a new file via FileInfo.Open().
            FileInfo f2 = new FileInfo(@"C:\Test2.dat");
            using (FileStream fs2 = f2.Open(FileMode.OpenOrCreate,
            FileAccess.ReadWrite, FileShare.None))
            {
                // Use the FileStream object...
            }
            // Get a FileStream object with read-only permissions.
            FileInfo f3 = new FileInfo(@"C:\Test3.dat");
            using (FileStream readOnlyStream = f3.OpenRead())
            {
                // Use the FileStream object...
            }
            // Now get a FileStream object with write-only permissions.
            FileInfo f4 = new FileInfo(@"C:\Test4.dat");
            using (FileStream writeOnlyStream = f4.OpenWrite())
            {
                // Use the FileStream object...
            }
            // Get a StreamReader object.
            FileInfo f5 = new FileInfo(@"C:\boot.ini");
            using (StreamReader sreader = f5.OpenText())
            {
                // Use the StreamReader object...
            }
            FileInfo f6 = new FileInfo(@"C:\Test6.txt");
            using (StreamWriter swriter = f6.CreateText())
            {
                // Use the StreamWriter object...
            }
            FileInfo f7 = new FileInfo(@"C:\FinalTest.txt");
            using (StreamWriter swriterAppend = f7.AppendText())
            {
                // Use the StreamWriter object...
            }
        }

        static void FileMethod()
        {
             // the difference between fileinfo and file object that file methods all are static 
            // Obtain FileStream object via File.Create().
            using (FileStream fs = File.Create(@"C:\Test.dat"))
            { }
            // Obtain FileStream object via File.Open().
            using (FileStream fs2 = File.Open(@"C:\Test2.dat",
            FileMode.OpenOrCreate,
            FileAccess.ReadWrite, FileShare.None))
            { }
            // Get a FileStream object with read-only permissions.
            using (FileStream readOnlyStream = File.OpenRead(@"Test3.dat"))
            { }
            // Get a FileStream object with write-only permissions.
            using (FileStream writeOnlyStream = File.OpenWrite(@"Test4.dat"))
            { }
            // Get a StreamReader object.
            using (StreamReader sreader = File.OpenText(@"C:\boot.ini"))
            { }
            // Get some StreamWriters.
            using (StreamWriter swriter = File.CreateText(@"C:\Test6.txt"))
            { }
            using (StreamWriter swriterAppend = File.AppendText(@"C:\FinalTest.txt"))
            { }
        }

        static void FileIOMethod()
        {
            Console.WriteLine("***** Simple I/O with the File Type *****\n");
            string[] myTasks = {"Fix bathroom sink", "Call Dave","Call Mom and Dad", "Play Xbox One"};
            // Write out all data to file on C drive.
            File.WriteAllLines(@"tasks.txt", myTasks);
            foreach (string task in File.ReadAllLines(@"tasks.txt"))
            {
                Console.WriteLine("Todo {0} :",task);
            }
            Console.ReadLine();
        }
        
        static void FileStreamMethod()
        {
            Console.WriteLine("***** Fun with FileStreams *****\n");
            // Obtain a FileStream object.
            using (FileStream fStream = File.Open(@"myMessage.dat", FileMode.Create))
            {
                // Encode a string as an array of bytes.
                string msg = "Hello";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
                // Write byte[] to file.
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);

                // Reset internal position of stream.
                fStream.Position = 0;

                // Read the types from file and display to console.
                Console.Write("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Console.WriteLine(bytesFromFile[i]);
                    
                }
                // Display decoded messages.
                Console.Write("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));

            }
            Console.ReadLine();
        }

        static void StreamWriterAndStreamReader()
        {
            Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");
            // Get a StreamWriter and write string data.
            using (StreamWriter writer = File.CreateText("reminders.txt"))
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                writer.WriteLine("Don't forget Father's Day this year...");
                writer.WriteLine("Don't forget these numbers:");
                for (int i = 0; i < 10; i++)
                    writer.Write(i + " ");
                // Insert a new line.
                writer.Write(writer.NewLine);
            }
            Console.WriteLine("Created file and wrote some thoughts...");
            Console.ReadLine();
            // Now read data from file.
            Console.WriteLine("Here are your thoughts:\n");
            using (StreamReader sr = File.OpenText("reminders.txt"))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                    Console.WriteLine(input);
            }
            Console.ReadLine();
        }

        static void StringWriterAndStringReader()
        {
            Console.WriteLine("***** Fun with StringWriter / StringReader *****\n");
            // Create a StringWriter and emit character data to memory.
            using (StringWriter strWriter = new StringWriter())
            {
                strWriter.WriteLine("Don't forget Mother's Day this year...");
                // Get a copy of the contents (stored in a string) and dump
                // to console.
                Console.WriteLine("Contents of StringWriter:\n{0}", strWriter);
                // Get the internal StringBuilder.
                StringBuilder sb = strWriter.GetStringBuilder();
                sb.Insert(0, "Hey!! ");
                Console.WriteLine("-> {0}", sb.ToString());
                sb.Remove(0, "Hey!! ".Length);
                Console.WriteLine("-> {0}", sb.ToString());
                // Read data from the StringWriter.
                using (StringReader strReader = new StringReader(strWriter.ToString()))
                {
                    string input = null;
                    while ((input = strReader.ReadLine()) != null)
                    {
                        Console.WriteLine(input);
                    }
                }
            }

            Console.ReadLine();
        }

        static void BinaryWritersAndReaders()
        {
            // Open a binary writer for a file.
            FileInfo f = new FileInfo("BinFile.dat");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                // Print out the type of BaseStream.
                // (System.IO.FileStream in this case).
                Console.WriteLine("Base stream is: {0}", bw.BaseStream);
                // Create some data to save in the file.
                double aDouble = 1234.67;
                int anInt = 34567;
                string aString = "A, B, C";
                // Write the data.
                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }
            // Read the binary data from the stream.
            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        static void FileWatcher()
        {
            Console.WriteLine("***** The Amazing File Watcher App *****\n");
            // Establish the path to the directory to watch.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"C:\MyFolder";
            }catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            // Set up the things to be on the lookout for.
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = "*.txt";
            // Add event handlers.
            watcher.Changed += new  FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching the directory.
            watcher.EnableRaisingEvents = true;
            // Wait for the user to quit the program.
            // Wait for the user to quit the program.
            Console.WriteLine(@"Press 'q' to quit app.");
            while (Console.Read() != 'q')
                ;
        }
        //The following two event handlers simply print the current file modification
        static void OnChanged(object source , FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File : {0} {1}!",e.FullPath,e.ChangeType);
        }
        static void OnRenamed(object source , RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);

        }
    }
}
