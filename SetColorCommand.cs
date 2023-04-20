using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolSetColorByFillter.Controller;
using ToolSetColorByFillter.Views;

namespace ToolSetColorByFillter
{
    [Transaction(TransactionMode.Manual)]
    public class SetColorCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

           
            if(doc.IsFamilyDocument) 
            {
                TaskDialog.Show("Warrning", "Không thể Dùng Tool!");
                return Result.Cancelled;
            }
            ControllerView main = new ControllerView(doc, uidoc);
            main.Mainview.ShowDialog();

            return Result.Succeeded;
        }
    }
}
