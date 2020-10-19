using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_revit_IICM_1020.Model
{

   public class ParameterModel
    {
        private string para;
        private string value;
        private string valueType;
        private Parameter parameter;
        private int id;
     
        public Parameter PARAMETER { 
            get => parameter;
            set => parameter = value; 
        }
        public int ID { get => id; set => id = value; }
        public string NAME
        {
            get => this.para;
            set => this.para = value;
        }
        public string VALUE
        {
            get => this.value;
            set => this.value = value;
        }
        public string TYPE{
            get => this.valueType;
            set => this.valueType = value;
}
        public ParameterModel(string param,string value,string type)
        {
            this.para = param;
            this.value = value;
            this.valueType = type;

        }
        public ParameterModel(int id,string param, string value, string type,Parameter parameter)
        {
            this.id = id;
            this.para = param;
            this.value = value;
            this.valueType = type;
            this.parameter = parameter;
        }

    }

    
}
