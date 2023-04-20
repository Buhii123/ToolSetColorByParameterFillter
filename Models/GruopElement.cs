using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace ToolSetColorByFillter.Models
{
    public class GruopElement
    {

        public int Count { get; set; }
        public string ValueParameter { get; set; }
        public List<ElementByFilter> Elements { get; set; } = new List<ElementByFilter>();
        public SolidColorBrush Background { get; set; }
        public GruopElement(string value, Parameter parameter, List<Element> elements, System.Windows.Media.Color wpfColor)
        {

         
            Background = new SolidColorBrush(wpfColor);
            int red = Background.Color.R;
            int green = Background.Color.G;
            int blue = Background.Color.B;
            ValueParameter = value;
            Elements.AddRange(elements
                    .Where(e => e?.LookupParameter(parameter?.Definition?.Name)?.AsValueString() == value)
                    .Select(e => new ElementByFilter(e.Name, e.Id, new Autodesk.Revit.DB.Color((byte)red, (byte)green, (byte)blue))));
            Count = Elements.Count;

        }
    }
}
