using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
namespace API_revit_IICM_1020.Utils
{
    class ExcelExport
    {

        string pathDes;
        string pathSou;
        public ExcelExport()
        {

        }
        public static void convertToShareParameter()
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            engine.ExecuteFile(@"C:\test.py", scope);
            dynamic testFunction = scope.GetVariable("test_func");
        


        }
        public void setPathDes(string path)
        {

        }
        public void setPathSou(string path)
        {

        }

    }
}
