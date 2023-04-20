using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSetColorByFillter.Comparer
{
    public class ParameterComparer : IEqualityComparer<Parameter>
    {
        public bool Equals(Parameter x, Parameter y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            else
            {
                return x.Definition.Name.Equals(y.Definition.Name);
            }
        }

        public int GetHashCode(Parameter obj)
        {
            return obj.Id.IntegerValue;
        }
    }
}
