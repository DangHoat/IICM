using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_revit_IICM_1020.Utils
{
    class ElementSelector{
         public Element e { get; set; }
        public ElementSelector()
        {

        }
        public void SeclectElement(Document doc, UIDocument uidoc)
        {
            Reference reference = uidoc.Selection.PickObject(ObjectType.Element);
            Element element = doc.GetElement(reference);
            this.e = element;
        }
        void setParameter(Document doc)
        {

        }

    }
    
}
