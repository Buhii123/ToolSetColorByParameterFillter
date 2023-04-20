using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolSetColorByFillter.Lib;
using ToolSetColorByFillter.Models;

namespace ToolSetColorByFillter.Test
{
    public class GetCategoryAndCount : INewObject<Category>
    {
        public Category InfoObject { get ; set ; } 
        public int Count { get; set; }
        public List<Element> ElementAll { get; set; }
     
        
        public GetCategoryAndCount(Category category, List<Element>elements) 
        {
            InfoObject = category;
            Count = GetInfoObject.GetCategoryCount(category.Name, elements);
            ElementAll  = GetInfoObject.GetAllElementByCategory(category.Name, elements);
           
        }
    }
}
