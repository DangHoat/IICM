using API_revit_IICM_1020.Define;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace API_revit_IICM_1020.Utils
{
    class SampleCreateSharedParameter

    {
        Document doc;
        Application app;
    
        string tempFile;
        Category category ;
        CategorySet categorySet;
        public string LINK { get => this.tempFile;
            set => this.tempFile = value; }
        public SampleCreateSharedParameter(Document doc, Application app)
        {
            this.app = app;
            this.doc = doc;
            
        }
        public void SetCategory(Element element)
        {
            category = element.Category;
            categorySet = app.Create.NewCategorySet();
            categorySet.Insert(category);
        }
        public void CreateSampleSharedParameters(Element element) 
        {
            string originalFile = "";
            try
            {
               
                InstanceBinding newIB = app.Create.NewInstanceBinding(categorySet);
                category = element.Category;
                categorySet = app.Create.NewCategorySet();
                categorySet.Insert(category); 
                originalFile = app.SharedParametersFilename;
                if (tempFile.Equals("") || tempFile == null) throw new Exception("link is not define!");
                app.SharedParametersFilename = tempFile;

                DefinitionFile sharedParameterFile = app.OpenSharedParameterFile();
               
                foreach (DefinitionGroup dg in sharedParameterFile.Groups)
                {
                    foreach(ExternalDefinition externalDefinition in dg.Definitions)
                    {

                        //TaskDialog.Show("mess", externalDefinition.Name + "==" + dg.Name);
                        using (Transaction t = new Transaction(doc))
                        {
                            t.Start("Add Shared Parameters");
                            doc.ParameterBindings.Insert(externalDefinition, newIB);
                            t.Commit();
                        }

                    }
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

        public List<string> GetListShareParamerter(Element element)
        {
            List<string> result = new List<string>();
            string originalFile = "";
            try
            {
                category = element.Category;
                categorySet = app.Create.NewCategorySet();
                categorySet.Insert(category);
                InstanceBinding newIB = app.Create.NewInstanceBinding(categorySet);
              
                originalFile = app.SharedParametersFilename;
                if (tempFile.Equals("") || tempFile == null) throw new Exception("link is not define!");
                app.SharedParametersFilename = tempFile;

                DefinitionFile sharedParameterFile = app.OpenSharedParameterFile();

                foreach (DefinitionGroup dg in sharedParameterFile.Groups)
                {
                    foreach (ExternalDefinition externalDefinition in dg.Definitions)
                    {
                      result.Add(externalDefinition.Name);
                    }
                }
            }
            catch (Exception e)
            {
                WriteLog.Log(e.ToString() + "\n" + "originalFile" + originalFile);
            }
            finally
            {
                //reset to original file
                app.SharedParametersFilename = originalFile;
            }
            return result;
        }
    }
}
