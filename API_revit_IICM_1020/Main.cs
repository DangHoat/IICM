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

namespace API_revit_IICM_1020
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            Reference reference = uidoc.Selection.PickObject(ObjectType.Element);
            MessageBox.Show(reference.ElementReferenceType.ToString(), "Message");
            Reference reference2 = uidoc.Selection.PickObject(ObjectType.Element);
            MessageBox.Show(reference2.ElementReferenceType.ToString(), "Message");
            Wall wall = doc.GetElement(reference) as Wall;
            Wall wall2 = doc.GetElement(reference2) as Wall;

            Parameter p1 = wall.LookupParameter("Comments");
            Parameter p2 = wall2.LookupParameter("Comments");
            using (Transaction tx = new Transaction(doc,"Copy Parameter"))
            {
                tx.Start("Transaction Name");
                string valueWall1 = p1.AsString();
                p2.Set(valueWall1);
                tx.Commit();
            }

            return Result.Succeeded;
            //throw new NotImplementedException();
        }
    }
}
