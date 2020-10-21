using API_revit_IICM_1020.Model;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_revit_IICM_1020.Utils
{
    class ParameterProcess
    {

        public ParameterModel GetParameterInformation(Parameter para, Document document, int idOfModel)
        {
            string defName = para.Definition.Name;
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
            return new ParameterModel(idOfModel, defName, defValue, para.StorageType.ToString(), para);
        }
        public void setParameterToElent(Parameter parameter, Document doc, string value)
        {
            try
            {
                using (Transaction t = new Transaction(doc, "Set Type"))
                {
                    t.Start();
                    parameter.Set(value);
                    t.Commit();
                }
            }
            catch (Exception e)
            {
                TaskDialog.Show(e.ToString(), "IICM");
            }

        }
    }
}
