using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_revit_IICM_1020.Model
{
    class ParameterModel{
        public ParameterModel(string code,string cost,string comment,float height,float wight,string unit)
        {
            this.code = code;
            this.comment = comment;
            this.height = height;
            this.wight = wight;
            this.unit = unit;
        }
        public string code { get; set; }
        public string cost { get; set; }
        public string comment { get; set; }
        public float height { get; set; }
        public float wight { get; set; }
        public string unit { get; set; }

        public string toJson() {
            string result = "";
            result = JsonConvert.SerializeObject(this);
            return result;
        }
    }
}
