﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Fields.Base
{
    public interface IFieldCell
    {
        public string Name { get; }
        public string UniqueName { get; }
        public uint XCoord { get; init; }
        public uint YCoord { get; init; }

        public string Color { get; }
    }
}