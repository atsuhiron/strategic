using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Fields;
using Game.Fields.Base;

namespace Game
{
    public class Field
    {
        public int Width { get; init; }
        public int Height { get; init; }
        public IReadOnlyList<IReadOnlyList<IFieldCell>> FieldCells { get; init; }

        public Field(bool debug)
        {
            if (debug)
            {
                Width = 10;
                Height = 8;

                FieldCells = Enumerable
                    .Range(0, Height)
                    .Select(hi => Enumerable
                        .Range(0, Width)
                        .Select(wi => new Plane(wi, hi) as IFieldCell)
                        .ToList())
                    .ToList();
            } 
            else
            {
                Width = 0;
                Height = 0;
                FieldCells = Array.Empty<IReadOnlyList<IFieldCell>>();
            }
            
        }
    }
}
