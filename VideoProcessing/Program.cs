using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcuteProcess("../../ffmpeg.exe", "-y -i D:\\1.flv -ss 00:00:15 D:\\1.jpg", (s, e) => Console.WriteLine(e.Data));
        }

        static void ExcuteProcess(string exe, string arg, DataReceivedEventHandler output) 
        {
            using (var p = new Process())
            {
                p.StartInfo.FileName = exe;
                p.StartInfo.Arguments = arg;

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;

                p.OutputDataReceived += output;
                p.ErrorDataReceived += output;

                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();
            }
        }
    }
}
