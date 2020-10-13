using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_revit_IICM_1020.Model
{

   public class ExcelModel
    {
        private string parameter;
        private string value;
        private string valueType;
        private typeValue type;
        public string NAME
        {
            get => this.parameter;
            set => parameter = value;
        }
        public string VALUE
        {
            get => this.value;
            set => value = value;
        }
        public string TYPE{
            get => this.valueType;
            set => this.valueType = value;
}
        public ExcelModel(string param,string value,string type)
        {
            this.parameter = param;
            this.value = value;
            this.type = type;

        }

    }

    public enum typeValue
    {
        Options,
        Text,
        Number
    }
}
