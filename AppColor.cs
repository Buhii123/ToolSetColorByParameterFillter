using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolSetColorByFillter.UIApp;

namespace ToolSetColorByFillter
{
    internal class AppColor : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            CreateUIApp.CreateUI<ColorTab>(application);
            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded; ;
        }

    }
}
