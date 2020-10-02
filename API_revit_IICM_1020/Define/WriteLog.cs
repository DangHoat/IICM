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
            using (StreamWriter sw = new StreamWriter(@"C:\Users\BlueDragon\Desktop\log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " : "+ log);
            }
        }
    }
}
