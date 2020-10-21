using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;

using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB.Structure;
using API_revit_IICM_1020.Utils;
using API_revit_IICM_1020.Model;
using API_revit_IICM_1020.UI;

namespace API_revit_IICM_1020
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class SelectManyElements : IExternalCommand{
        int id = 0;
        List<ParameterModel> listParamrter = new List<ParameterModel>();
        List<string> shareParameters = new List<string>();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
            ElementSelector elementSelector = new ElementSelector();
            IList<Element> ilistElements = elementSelector.SeclectManyElement(doc,uidoc);
            if (ilistElements == null) return Result.Succeeded;

            ParameterProcess parameterProcess = new ParameterProcess();
            SampleCreateSharedParameter sampleCreateSharedParameter = new SampleCreateSharedParameter(doc, app);
            sampleCreateSharedParameter.LINK = @"C:\Users\OAI-IICM\Desktop\APIRevit-C#\Project\IICM\API_revit_IICM_1020\Define\Structural-Parameters.txt";
            foreach(Element ele in ilistElements)
            {
                shareParameters.Clear();
                listParamrter.Clear();
                shareParameters.AddRange(sampleCreateSharedParameter.GetListShareParamerter(ele));
                int loop = 1;
                id = 0;
                do
                {
                    foreach (Parameter para in ele.Parameters)
                    {
                        ParameterModel p = parameterProcess.GetParameterInformation(para, doc, id);

                        if (shareParameters.Contains(p.NAME))
                        {
                            listParamrter.Add(p);
                            id++;
                        }
                    }
                    if (listParamrter.Count > 0) break;
                    sampleCreateSharedParameter.CreateSampleSharedParameters(ele);
                    ++loop;
                } while (loop < 2); ;
                if(listParamrter.Count <= 0)
                {
                    TaskDialog.Show("IICM", ele.Id.ToString()+" no parameter!");
                    continue;
                }
                
                ///show dialog update param
                ///
                using (FormIO formIO = new FormIO(listParamrter))
                {
                    formIO.Text = ele.Id.ToString();
                    DialogResult dr = formIO.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        //do update
                        List<ParameterModel> listNewParam = new List<ParameterModel>();
                        listNewParam = formIO.VALUE;
                        foreach (var new_para in listNewParam)
                        {
                            parameterProcess.setParameterToElent(new_para.PARAMETER, doc, new_para.VALUE);
                        }
                    }
                }
            }


           
            return Result.Succeeded;
            //throw new NotImplementedException();
        }
       /* public void GetInfo_Wall(Wall wall)
        {
            string message = "Wall : ";
            // Get wall AnalyticalModel type
            AnalyticalModel model = wall.GetAnalyticalModel();
            if (null != model)
            {
                // For some situation(such as architecture wall or in building version),
                // this property may return null, but if it doesn't return null, it should 
                // be AnalyticalModelWall.
                message += "\nWall AnalyticalModel type is : " + model;
            }

            wall.Flip();
            message += "\nIf wall Flipped : " + wall.Flipped;
            // Get curve start point
            message += "\nWall orientation point is :(" + wall.Orientation.X + ", "
                + wall.Orientation.Y + ", " + wall.Orientation.Z + ")";
            // Get wall StructuralUsage
            message += "\nWall StructuralUsage is : " + wall.StructuralUsage;
            // Get wall type name
            message += "\nWall type name is : " + wall.WallType.Name;
            // Get wall width
            message += "\nWall width is : " + wall.Width;

            TaskDialog.Show("Revit", message);
        }*/
    }
}
