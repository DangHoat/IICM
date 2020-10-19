using API_revit_IICM_1020.Utils;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_revit_IICM_1020
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    class InsertShareParameter : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
            ElementSelector elementSelector = new ElementSelector();
            elementSelector.SeclectElement(doc, uidoc);
            Element element = elementSelector.e;
            SampleCreateSharedParameter sampleCreateSharedParameter = new SampleCreateSharedParameter();
            sampleCreateSharedParameter.LINK = @"C:\Users\OAI-IICM\Desktop\APIRevit-C#\Project\IICM\API_revit_IICM_1020\Define\Structural-Parameters.txt"; 
            sampleCreateSharedParameter.CreateSampleSharedParameters(doc, app, element);
            return Result.Succeeded;
        }
    }
}
