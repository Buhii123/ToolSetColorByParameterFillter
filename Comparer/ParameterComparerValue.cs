
using System.Collections.Generic;


namespace ToolSetColorByFillter.Comparer
{
   public class ParameterComparerValue : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            else
            {
                return x.Equals(y);
            }
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
