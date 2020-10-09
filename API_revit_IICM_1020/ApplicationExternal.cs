using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using API_revit_IICM_1020.Define;
using Autodesk.Revit.UI;
namespace API_revit_IICM_1020
{
    class ApplicationExternal : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application){
           
            return Result.Succeeded; 
        }

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                string tabName = "IICM";
                string panelAnomationName = "panel Name";
                application.CreateRibbonTab(tabName);
                var panelAnomation = application.CreateRibbonPanel(tabName, panelAnomationName);
                Uri uriTooltip = new Uri(@"F:\DXH\Moodle\ima.svg");
                var tabWallLayyerButtonData = new PushButtonData("TagData", "TagWall", Assembly.GetExecutingAssembly().Location, "API_revit_IICM_1020.Main")
                {
                    ToolTipImage = new BitmapImage(uriTooltip),
                    ToolTip = "ToolTip..."
                };

                var TagWallLayerBtn = panelAnomation.AddItem(tabWallLayyerButtonData) as PushButton;
                Uri uriImage = new Uri(@"C:\Users\OAI-IICM\Desktop\APIRevit-C#\Project\IICM\API_revit_IICM_1020\image\earth-icon.png");
                TagWallLayerBtn.LargeImage = new BitmapImage(uriImage);

            }
            catch (Exception e)
            {
                WriteLog.Log(e.ToString());
            }

           
            return Result.Succeeded;
        }
    }
}
