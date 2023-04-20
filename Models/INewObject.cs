using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSetColorByFillter.Test
{
    public interface INewObject<T>
    {
        T InfoObject { get; set; }
        int Count { get; set; }
    }
}
