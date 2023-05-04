using System;
using System.Diagnostics;

namespace test_BatchFile
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Process proc = null;
            try
            {
                //string batDir = string.Format(@"D:\Proj\VStudio\MyOPCUAServer\InformationModelling");
                //proc = new Process();
                //proc.StartInfo.WorkingDirectory = batDir;
                //proc.StartInfo.FileName = "MyOPCUAServerBuildDesign.bat";
                //proc.StartInfo.CreateNoWindow = false;
                //proc.Start();
                //proc.WaitForExit();
                //Console.WriteLine("Bat file executed !!");


                string filename = @"D:\Proj\VStudio\MyOPCUAServer\InformationModelling\MyOPCUAServerBuildDesignFullPath.bat";
                string parameters = $"/k \"{filename}\"";
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", parameters);
                processStartInfo.CreateNoWindow = true;
                //Process.Start("cmd", parameters);
                Process.Start(processStartInfo);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show(ex.StackTrace.ToString());
            }
        }
    }
}