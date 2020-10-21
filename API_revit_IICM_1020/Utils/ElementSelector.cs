using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_revit_IICM_1020.Utils
{
    class ElementSelector{
        public Element e { get; set; }
        public ElementSelector()
        {

        }
        public Element SeclectElement(Document doc, UIDocument uidoc)
        {
            Reference reference = uidoc.Selection.PickObject(ObjectType.Element);
            return doc.GetElement(reference);
            
        }
        public IList<Element> SeclectManyElement(Document doc, UIDocument uidoc)
        {
            IList<Element> result = new List<Element>() ;
            Selection selection = uidoc.Selection;
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
            if (0 != selectedIds.Count)
            {
                foreach (ElementId id in selectedIds)
                {
                    try
                    {
                        //TaskDialog.Show("IICM", id.IntegerValue.ToString());
                        result.Add(doc.GetElement(id));

                    }
                    catch (ArgumentNullException e)
                    {
                        TaskDialog.Show("IICM", e.ToString());
                    }
                    
                }
                return result;
            }
            TaskDialog.Show("IICM", "You haven't selected any elements.");
            return null;
        }
    }
    
}
