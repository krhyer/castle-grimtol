using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        // public int Value { get; set; }
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
            // Value = value;
        }
    }
}