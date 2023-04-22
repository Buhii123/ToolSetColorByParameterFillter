using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolSetColorByFillter.Comparer;

namespace ToolSetColorByFillter
{
    public class CategoryFilter : IListItem<Category>
    {
        private FilteredElementCollector _collector;
        public CategoryFilter(FilteredElementCollector collector) 
        { 
            this._collector = collector;
        } 
        public List<Category> ListItems()
        {
            return  _collector.WhereElementIsNotElementType()
                                      .ToElements()
                                      .Select(x => x.Category)
                                      .Distinct(new CategoryComparer())
                                      .Where(x => x != null) 
                                      .ToList();
        }
    }
}
