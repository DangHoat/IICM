using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace API_revit_IICM_1020
{
    class csAddPanel : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded; ;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Tiện ích mở rộng");
            //Create a push button in the ribbon panel “NewRibbonPanel”
            //the add-in application “HelloWorld” will be triggered when button is pushed
            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("ShowInfo",
            "HelloWorld", @"C:\Users\OAI-IICM\Desktop\APIRevit-C#\Project\IICM\API_revit_IICM_1020\bin\Debug\API_revit_IICM_1020.dll", "API_revit_IICM_1020.GetAllElement")) as PushButton;
            // Set the large image shown on button
            Uri uriImage = new Uri(@"C:\Users\OAI-IICM\Desktop\APIRevit-C#\Project\IICM\API_revit_IICM_1020\image\earth-icon.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
            return Result.Succeeded;
        }
    }
}
