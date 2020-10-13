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
       

        public static  void CreateSampleSharedParameters(Document doc, Application app,Element element) 
        {
            string originalFile = "";
            try
            {
                
                Category category = element.Category;
                CategorySet categorySet = app.Create.NewCategorySet();
                categorySet.Insert(category);
                InstanceBinding newIB = app.Create.NewInstanceBinding(categorySet);

                originalFile = app.SharedParametersFilename;
               
                string tempFile = @"C:\Users\OAI-IICM\Desktop\APIRevit-C#\Project\IICM\API_revit_IICM_1020\Define\Structural-Parameters.txt";

            
                app.SharedParametersFilename = tempFile;

                DefinitionFile sharedParameterFile = app.OpenSharedParameterFile();
                
               
                foreach (DefinitionGroup dg in sharedParameterFile.Groups)
                {
                    foreach(ExternalDefinition externalDefinition in dg.Definitions)
                    {

                        /*TaskDialog.Show("mess", externalDefinition.Name + "==" + dg.Name);*/
                        using (Transaction t = new Transaction(doc))
                        {
                            t.Start("Add Shared Parameters");
                            doc.ParameterBindings.Insert(externalDefinition, newIB);
                            t.Commit();
                        }

                    }
                    /*if (dg.Name == "Group1")
                    {
                        ExternalDefinition externalDefinition = dg.Definitions.get_Item("Code") as ExternalDefinition;

                        using (Transaction t = new Transaction(doc))
                        {
                            t.Start("Add Shared Parameters");
                            //parameter binding 
                            InstanceBinding newIB = app.Create.NewInstanceBinding(categorySet);
                            //parameter group to text
                            doc.ParameterBindings.Insert(externalDefinition, newIB, BuiltInParameterGroup.PG_TEXT);
                            t.Commit();
                        }
                    }*/
                }
            }
            catch (Exception e) {
                WriteLog.Log(e.ToString()+"\n" + "originalFile"+ originalFile);
            }
            finally
            {
              
                //reset to original file

                app.SharedParametersFilename = originalFile;
            }
        }
        public static void CreateSampleSharedParameters(Document doc, UIApplication uiApp, Application app, Element element)
        {
            try
            {


                Category category = element.Category;
                CategorySet categorySet = app.Create.NewCategorySet();
                categorySet.Insert(category);
                DefinitionFile spFile = uiApp.Application.OpenSharedParameterFile();

                foreach (DefinitionGroup dG in spFile.Groups)
                {
                    
                  
                    if (dG.Name == "Space")
                    {
                        var v = (from ExternalDefinition d in dG.Definitions select d);
                        using (Transaction t = new Transaction(doc))
                        {
                            t.Start("Add Space Shared Parameters");
                            foreach (ExternalDefinition eD in v)
                            {
                                InstanceBinding newIB = uiApp.Application.Create.NewInstanceBinding(categorySet);
                                doc.ParameterBindings.Insert(eD, newIB, BuiltInParameterGroup.PG_TEXT);
                            }
                            t.Commit();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                WriteLog.Log(e.ToString());
            }
            finally
            {

            }
        }
    }
}
