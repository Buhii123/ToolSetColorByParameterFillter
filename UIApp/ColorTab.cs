using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolSetColorByFillter.UIApp.UIBase;

namespace ToolSetColorByFillter.UIApp
{
    [Tab("Color Fillter")]
    public class ColorTab
    {
        [Panel("Color Fillter")]
        public class PanelColor
        {
            [Button("Color Fillter", "ToolSetColorByFillter.SetColorCommand", LinkImage = "color.png", LongDescription = "This is Test")]
            public class ColorButton
            {

            }
        }
    }
}
