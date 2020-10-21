using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using API_revit_IICM_1020.Define;
using API_revit_IICM_1020.UI;
using API_revit_IICM_1020.Utils;
using API_revit_IICM_1020.Model;

namespace API_revit_IICM_1020
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    
    class SeclectOneElementAndUpdate : IExternalCommand
    {
        int id = 0;
        List<ParameterModel> listParamrter = new List<ParameterModel>();
        List<string> shareParameters = new List<string>();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements){
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
            ElementSelector elementSelector = new ElementSelector();
            Element element = elementSelector.SeclectElement(doc, uidoc);
            ParameterProcess parameterProcess = new ParameterProcess();

            SampleCreateSharedParameter sampleCreateSharedParameter = new SampleCreateSharedParameter(doc, app);
            sampleCreateSharedParameter.LINK = @"C:\Users\OAI-IICM\Desktop\APIRevit-C#\Project\IICM\API_revit_IICM_1020\Define\Structural-Parameters.txt";
            shareParameters.AddRange(sampleCreateSharedParameter.GetListShareParamerter(element));
            int loop = 1;
            do
            {
                foreach (Parameter para in element.Parameters)
                {
                    ParameterModel p = parameterProcess.GetParameterInformation(para, doc, id);
                    
                    if (shareParameters.Contains(p.NAME))
                    {
                        listParamrter.Add(p);
                        id++;
                    }
                }
                if (listParamrter.Count > 0) break;
                sampleCreateSharedParameter.CreateSampleSharedParameters(element);
                ++loop;
            } while (loop < 2); ;
            ///show dialog update param
            ///
            using (FormIO formIO = new FormIO(listParamrter))
            {
                 DialogResult dr = formIO.ShowDialog();
                if(dr  == DialogResult.OK)
                {
                    //do update
                    List<ParameterModel> listNewParam = new List<ParameterModel>();
                    listNewParam = formIO.VALUE;
                    foreach(var new_para in listNewParam)
                    {
                        parameterProcess.setParameterToElent(new_para.PARAMETER, doc, new_para.VALUE);
                    }
                }
            }
                
            return Result.Succeeded;
            //throw new NotImplementedException();
        }      
    }
}