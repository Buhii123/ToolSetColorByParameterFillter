using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSetColorByFillter.Models
{
    public class ElementFillter : IListElement<Element>
    {
        private FilteredElementCollector _collector;
        public ElementFillter(FilteredElementCollector collector)
        {
            this._collector = collector;
        }
        public List<Element> ListItems()
        {
            var elements = _collector
                    .WhereElementIsNotElementType()
                    .ToElements()
                    .ToList();
            var newElements = new List<Element>();
            foreach (Element ele in elements)
            {
                if (ele != null && ele.Category!=null)
                {
                    newElements.Add(ele);
                }
                
            }
            return newElements; 

        }
    }
}
