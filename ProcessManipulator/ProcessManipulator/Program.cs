using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Processes *****\n");
            //ListAllRunningProcesses();
            // Prompt user for a PID and print out the set of active threads.
           // Console.WriteLine("***** Enter PID of process to investigate *****");
           // Console.Write("PID: ");
           // string pID = Console.ReadLine();
            //int theProcID = int.Parse(pID);
            //EnumThreadsForPid(theProcID);
            StartAndKillProcess();

            Console.ReadLine();
        }
        static void ListAllRunningProcesses()
        {
            // Get all the processes on the local machine, ordered by
            // PID.
            // the dot represents the local computer
            var processes = from process in Process.GetProcesses(".") orderby process.Id select process;
            // Print out PID and name of each process.
            foreach (var pro in processes)
            {
                String info = $"->PID : {pro.Id}\tName : {pro.ProcessName} ";
                Console.WriteLine(info);

            }

            Console.WriteLine("******************************\n");

        }
        // If there is no process with the PID of 987, a runtime exception will be thrown.
        static void GetSpecificProcess()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(987);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void EnumThreadsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
                // List out stats for each thread in the specified process.
                Console.WriteLine("Here are the threads used by : {0} ",theProc.ProcessName);
                ProcessThreadCollection theThreads = theProc.Threads;
                foreach(ProcessThread pt in theThreads)
                {
                    string info = $"->Thread ID : {pt.Id}\t Start time : {pt.StartTime.ToShortTimeString()}\tPRiority: {pt.PriorityLevel}";
                    Console.WriteLine(info);
                }
                Console.WriteLine("Here are the loaded modules for: {0}", theProc.ProcessName);
                ProcessModuleCollection theMods = theProc.Modules;
                foreach(ProcessModule pm in theMods)
                {
                    string info = $" ->Module Name: {pm.ModuleName}";
                    Console.WriteLine(info);
                }
                Console.WriteLine("************************************\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        static void StartAndKillProcess()
        {
            Process ffProc = null;
            // Launch Firefox, and go to Facebook, with maximized window.
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("Firefox.exe", "www.Facebook.com");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;

                ffProc = Process.Start(startInfo);

            }catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("--> Hit enter to kill {0}...", ffProc.ProcessName);
            Console.ReadLine();
            // Kill the iexplore.exe process.
            try
            {
                ffProc.Kill();
            }catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
   }
