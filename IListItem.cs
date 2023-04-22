using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSetColorByFillter
{
    public interface IListItem<T>
    {
        List<T> ListItems();
    }
}
