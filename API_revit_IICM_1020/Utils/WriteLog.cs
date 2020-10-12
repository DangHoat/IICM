using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_revit_IICM_1020.Define
{
    class WriteLog
    {
        private string path = "";
        public static void Log(string log)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            string path = "C:\\LogRevit\\Log.txt";


            using (StreamWriter sw = new StreamWriter(@path, true))
            {
                sw.WriteLine("\n=======================" + DateTime.Now.ToString() + "======================");
                sw.WriteLine(log);
                sw.WriteLine("============================================= ");
            }
        }
        
    }
}
