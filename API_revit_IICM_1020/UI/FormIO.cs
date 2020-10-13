using API_revit_IICM_1020.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_revit_IICM_1020.UI
{
    public partial class FormIO : Form
    {
        private List<ExcelModel> listParamrter;
        public List<ExcelModel> listParam {
                get{
                    if (this.listParamrter == null) return new List<ExcelModel> ();
                    return this.listParamrter;
                }
            set {
                this.listParamrter = value;
            }
           
        }
        
        public FormIO()
        {
            InitializeComponent(); 
        }
       public FormIO (List<ExcelModel> excelModels)
        {
            this.listParamrter = excelModels;
            InitializeComponent();
        }
        private void FormIO_Init()
        {
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void box1_Enter(object sender, EventArgs e)
        {

        }

        private void FormIO_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            //Thêm Item vào listview
            string[] arr = new string[2];
            ListViewItem itm;
            foreach (ExcelModel item in this.listParamrter)
            {
                arr[0] = item.NAME;
                arr[1] = item.VALUE;
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
        }

       
    }
}
