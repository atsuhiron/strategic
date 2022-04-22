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
        public static Rectangle CreateFieldCell(IFieldCell fieldCell)
        {
            byte[] argb = fieldCell.Color;

            Brush cellColor;
            if (argb.Length == 3)
            {
                cellColor = new SolidColorBrush(Color.FromArgb(255, argb[0], argb[1], argb[2]));
            }
            else
            {
                cellColor = new SolidColorBrush(Color.FromArgb(argb[0], argb[1], argb[2], argb[3]));
            }
            
            return new Rectangle
            {
                Width = Values.cellSize,
                Height = Values.cellSize,
                Stroke = new SolidColorBrush(Colors.Gray),
                Fill = cellColor,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(Values.cellSize * fieldCell.XCoord, Values.cellSize * fieldCell.YCoord, 0, 0)
            };
        }
    }
}
