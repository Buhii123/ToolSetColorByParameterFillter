using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolSetColorByFillter.Comparer;

namespace ToolSetColorByFillter
{
    public class CategoryFilter : IListElement<Category>
    {
        private FilteredElementCollector _collector;
        public CategoryFilter(FilteredElementCollector collector) 
        { 
            this._collector = collector;
        } 
        public List<Category> ListItems()
        {
            var categories = _collector.WhereElementIsNotElementType()
                                      .ToElements()
                                      .Select(x => x.Category)
                                      .Distinct(new CategoryComparer())
                                      .ToList();
            var newCategories = new List<Category>();   
           foreach (Category category in categories) 
            { 
                if(category!=null)
                {
                    newCategories.Add(category);    
                }
            }
           return newCategories;   
           
        }
    }
}
