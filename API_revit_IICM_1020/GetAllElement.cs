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
    class GetAllElement : IExternalCommand
    {
        List<ExcelModel> listParamrter = new List<ExcelModel>();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements){
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
            ElementSelector elementSelector = new ElementSelector();
            elementSelector.SeclectElement(doc, uidoc);
            Element element = elementSelector.e;
            // Parameter parameter = element.LookupParameter("Absorptance");

            foreach (Parameter para in element.Parameters)
            {
                GetParameterInformation(para, doc);
                //MessageBox.Show(GetParameterInformation(para, doc), GetParameterInformation(para, doc));

               /* if (para.Definition.Name == "Mark")
                {
                    try
                    {
                        using (Transaction t = new Transaction(doc, "Set Type"))
                        {
                            t.Start();
                            para.Set("Mar"); ;
                            t.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString(), "Message");
                    }

                }*/

            }
            FormIO formIO = new FormIO();
            formIO.Show();
           
            /*foreach(KeyValuePair<string,string> item in listParamrter)
            {
                MessageBox.Show(item.Key, item.Value);
            }*/

            return Result.Succeeded;
            //throw new NotImplementedException();
        }

         /*string GetElementParameterInformation(Document document, Element element)
        {
            // Format the prompt information string
            String prompt = "Show parameters in selected Element: \n\r";

            StringBuilder st = new StringBuilder();
            // iterate element's parameters
            foreach (Parameter para in element.Parameters)
            {
                st.AppendLine(GetParameterInformation(para, document));
            }
            WriteLog.Log(st.ToString());
            // Give the user some information
         
            return prompt;

        }*/

        void GetParameterInformation(Parameter para, Document document)
        {
            string defName = para.Definition.Name + "\t : ";
            string defValue = string.Empty;
            // Use different method to get parameter data according to the storage type
            switch (para.StorageType)
            {
                case StorageType.Double:
                    //covert the number into Metric
                    defValue = para.AsValueString();
                    break;
                case StorageType.ElementId:
                    //find out the name of the element
                    Autodesk.Revit.DB.ElementId id = para.AsElementId();
                    if (id.IntegerValue >= 0)
                    {
                        defValue = document.GetElement(id).Name;
                    }
                    else
                    {
                        defValue = id.IntegerValue.ToString();
                    }
                    break;
                case StorageType.Integer:
                    if (ParameterType.YesNo == para.Definition.ParameterType)
                    {
                        if (para.AsInteger() == 0)
                        {
                            defValue = "False";
                        }
                        else
                        {
                            defValue = "True";
                        }
                    }
                    else
                    {
                        defValue = para.AsInteger().ToString();
                    }
                    break;
                case StorageType.String:
                    defValue = para.AsString();
                    break;
                default:
                    defValue = "Unexposed parameter.";
                    break;
            }
            
            listParamrter.Add(new ExcelModel(defName,defValue, para.StorageType.ToString()));

           // return defName + defValue;
        }
        void setParameterToElent(Element e)
        {

        }
    }
}