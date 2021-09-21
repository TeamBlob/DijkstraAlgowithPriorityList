using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    public class TestCase
    {
        string CaseName { get; set; }
        string PriorityOrHeap { get; set; }
        int DataSize { get; set; }
        double TimeTaken { get; set; }
        int Trial { get; set; }
        public TestCase(string CaseName, string PriorityOrHeap, int DataSize, double TimeTaken, int Trial)
        {
            this.CaseName = CaseName;
            this.PriorityOrHeap = PriorityOrHeap;
            this.DataSize = DataSize;
            this.TimeTaken = TimeTaken;
            this.Trial = Trial;
        }
        public void AppendNText()
        {
            string path = $@"{PriorityOrHeap}.txt";
            string input = $"Case Name/Trial: {CaseName}/{Trial}\r\n" +
                $"Priority Method?: {PriorityOrHeap}\r\n" +
                $"Data Size |V|: {DataSize}\r\n" +
                $"Time Taken(ms): {TimeTaken}\r\n";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(input);
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(input);
            }
        }
        public void AppendSText()
        {
            string path = $@"{PriorityOrHeap}.txt";
            string input = $"{TimeTaken} ms";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(input);
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(input);
            }
        }
    }
}
