using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ToolSetColorByFillter.Comparer;
using ToolSetColorByFillter.Models;

namespace ToolSetColorByFillter.Lib
{
    public static class GetInfoObject
    {
        public static int GetCategoryCount(string categoryName, List<Element> elements)
        {
            int count = 0;
            foreach (Element element in elements) if (element.Category.Name == categoryName) count++;
            return count;
        }
        public static List<Element> GetAllElementByCategory(string categoryName, List<Element> elements)
        {
            List<Element> elements1 = new List<Element>();
            foreach (Element element in elements) if (element.Category.Name == categoryName)
                    elements1.Add(element);
            return elements1;


        }

        public static List<Parameter> GetParameters(this List<Element> elements)
        {
            var parameters = new List<Parameter>();

            foreach (Element e in elements)
            {
                foreach (Parameter p in e.Parameters)
                {
                    parameters.Add(p);
                }
            }
            return parameters.Distinct(new ParameterComparer()).ToList();
        }
 


    }
}
