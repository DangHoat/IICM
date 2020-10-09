using API_revit_IICM_1020.Define;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_revit_IICM_1020.Utils
{
    class SampleCreateSharedParameter
    {
       

        public static  void CreateSampleSharedParameters(Document doc, Application app)
        {
            Category category = doc.Settings.Categories.get_Item(BuiltInCategory.OST_ColumnAnalytical);
            CategorySet categorySet = app.Create.NewCategorySet();
            categorySet.Insert(category);

            string originalFile = app.SharedParametersFilename;
            string tempFile = @"C:\Users\OAI-IICM\Desktop\APIRevit-C#\Project\IICM\API_revit_IICM_1020\Define\Structural-Parameters.txt";

            try
            {
                app.SharedParametersFilename = tempFile;

                DefinitionFile sharedParameterFile = app.OpenSharedParameterFile();
               
                TaskDialog.Show(sharedParameterFile.ToString(), "mes");

                foreach (DefinitionGroup dg in sharedParameterFile.Groups)
                {
                    System.Windows.Forms.MessageBox.Show(dg.ToString(), "Message");
                    if (dg.Name == "DYNAMO AND ADD-IN")
                    {
                        ExternalDefinition externalDefinition = dg.Definitions.get_Item("GROUP 1") as ExternalDefinition;

                        using (Transaction t = new Transaction(doc))
                        {
                            t.Start("Add Shared Parameters");
                            //parameter binding 
                            InstanceBinding newIB = app.Create.NewInstanceBinding(categorySet);
                            //parameter group to text
                            doc.ParameterBindings.Insert(externalDefinition, newIB, BuiltInParameterGroup.PG_TEXT);
                            t.Commit();
                        }
                    }
                }
            }
            catch (Exception e) {
                WriteLog.Log(e.ToString());
            }
            finally
            {
              
                //reset to original file
                app.SharedParametersFilename = originalFile;
            }
        }
    }
}
