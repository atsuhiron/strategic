using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using Game.Fields.Base;
using App.Constants;

namespace App.UIEFactories
{
    public class FieldCellFactory
    {
        public static Rectangle CreateFieldCell(IFieldCell fieldCell, int x, int y)
        {
            // TODO: 場合分け
            return new Rectangle
            {
                Width = Values.cellSize,
                Height = Values.cellSize,
                Stroke = new SolidColorBrush(Colors.Blue),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(Values.cellSize * x, Values.cellSize * y, 0, 0)
            };
        }
    }
}
