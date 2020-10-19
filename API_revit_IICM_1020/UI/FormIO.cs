using API_revit_IICM_1020.Model;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using Newtonsoft.Json;
using sun.tools.asm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_revit_IICM_1020.UI
{
    public partial class FormIO : Form
    {
        Button btn ;
        int id;
        private List<ParameterModel> listParamrters;
        private ParameterModel temp;
        public List<ParameterModel> VALUE {
            get{
                if (this.listParamrters == null) return new List<ParameterModel> ();
                return this.listParamrters;
                }
            set {
                this.listParamrters = value;
            }
           
        }
        
        public FormIO()
        {
            InitializeComponent(); 
        }
       public FormIO (List<ParameterModel> excelModels)
        {
            this.listParamrters = excelModels;
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            listParameter.View = View.Details;
            listParameter.GridLines = true;
            listParameter.FullRowSelect = true;
            
            string[] arr = new string[4];
            ListViewItem itm;
            foreach (ParameterModel item in this.listParamrters)
            {
                arr[0] = item.NAME;
                arr[1] = item.VALUE;
                arr[2] = Convert.ToString(item.ID);
                arr[3] = item.TYPE;
                itm = new ListViewItem(arr);
               // comboBoxParam.Items.Add(arr[0]);
                listParameter.Items.Add(itm);
            }
        }
        

        private void listParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listParameter.SelectedItems.Count == 0)
                return;
            //get selected row
            ListViewItem item = listParameter.Items[listParameter.SelectedIndices[0]];
            //fill the text boxes
            comboBoxParam.Text = item.SubItems[0].Text;
            textBoxParam.Text = item.SubItems[1].Text;
            id = Convert.ToInt32(item.SubItems[2].Text);
            if (!btnUpdate.Enabled) {
                btnUpdate.Enabled = true;
            }
            
            btn = new Button();
            btn.Size = new Size(textBoxParam.ClientSize.Height - 3, textBoxParam.ClientSize.Height - 3);
            btn.Location = new Point(textBoxParam.ClientSize.Width - btn.Width, 2);
            btn.Cursor = Cursors.Default;
            btn.Text = "...";
            btn.Click += btn_Click;
            textBoxParam.Controls.Add(btn);

        }  
        private void btn_Click(object sender, EventArgs e)
        {
            using (StreamReader r = new StreamReader(@"C:\Users\OAI-IICM\Desktop\APIRevit-C#\dutoan.json"))
            {
                string json = r.ReadToEnd();
                using (var treeViewDialog = new TreeViewDialog(json))
                {
                    treeViewDialog.Text = comboBoxParam.Text;
                    DialogResult dr = treeViewDialog.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        textBoxParam.Text = treeViewDialog.DLR;
                    }
                    
                }
            }
          
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Update by ID
            listParamrters.FirstOrDefault(p => p.ID == id).VALUE = textBoxParam.Text;
            UpdateListView();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Return data update
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void textBoxParam_TextChanged(object sender, EventArgs e)
        {

        }
        private void UpdateListView()
        {
            listParameter.Items.Clear();
            string[] arr = new string[4];
            ListViewItem itm;
            foreach (ParameterModel item in this.listParamrters)
            {
                arr[0] = item.NAME;
                arr[1] = item.VALUE;
                arr[2] = Convert.ToString(item.ID);
                itm = new ListViewItem(arr);
                // comboBoxParam.Items.Add(arr[0]);
                listParameter.Items.Add(itm);
            }
        }
    }
}
