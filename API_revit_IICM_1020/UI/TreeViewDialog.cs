using Newtonsoft.Json;
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
    public partial class TreeViewDialog : Form
    {
        string dialogResult;
        string json;
        public string DLR{get => dialogResult;}
        
        public TreeViewDialog(string json)
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            this.json = json;
        
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Nodes.Count == 0)
            {
                dialogResult = node.Text;
            }
            else
            {
                dialogResult = "";
            }
           
        }

        private void TreeViewDialog_Load(object sender, EventArgs e)
        {   
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            foreach (var obj in jsonObj.data) {
                    
                var ListGroup = new List<TreeNode>();
                foreach (var group in obj.value)
                {
                    var arrayNodeGroup = new List<TreeNode>();
                       
                    foreach (var member in group.member)
                    {
                        arrayNodeGroup.Add( new TreeNode(Convert.ToString(member)));    
                    }
                        
                    TreeNode groupNode = new TreeNode(Convert.ToString(group.className), arrayNodeGroup.ToArray());
                    ListGroup.Add(groupNode);
                }
                TreeNode newNode1 = new TreeNode(Convert.ToString(obj.key),ListGroup.ToArray());
                treeView1.Nodes.Add(newNode1);
            }
        }


       

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }
    }
}
