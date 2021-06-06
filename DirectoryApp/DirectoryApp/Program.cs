using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Directory(Info) *****\n");
            ShowWindowsDirectoryInfo();
            DisplayImageFiles();
            Console.ReadLine();
        }

        private static void ShowWindowsDirectoryInfo()
        {
            // Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("**************************\n");
        }
        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            // Get all files with a *.jpg extension.
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            // How many were found?
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);
            foreach (FileInfo file in imageFiles)
            {
                // Now print out info for each file.
                Console.WriteLine("***************************");
                Console.WriteLine("File name: {0}", file.Name);
                Console.WriteLine("File size: {0}", file.Length);
                Console.WriteLine("Creation: {0}", file.CreationTime);
                Console.WriteLine("Attributes: {0}", file.Attributes);
                Console.WriteLine("***************************\n");
            }
        }
        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\");
            // Create \MyFolder off application directory.
            dir.CreateSubdirectory(@"MyFolder");

            // Create \MyFolder2\Data off application directory.
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder2/Data");

            // Prints path to ..\MyFolder2\Data.
            Console.WriteLine("New Folder is: {0}", myDataFolder);

        }
        static void FunWithDirectoryType()
        {
            // List all drives on current computer

            Console.WriteLine("Here are your drives:");
            var drives = from drive in Directory.GetLogicalDrives() select drive;
            foreach (string drive in drives)
                Console.WriteLine("-->{0}", drive);
            // Delete what was created.
            Console.WriteLine("Press Enter to delete directories");
            Console.ReadLine();
            try
            {
                // The second parameter specifies whether you
                // wish to destroy any subdirectories.
                Directory.Delete(@"C:\MyFolder");
                Directory.Delete(@"C:\MyFolder2", true);

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

