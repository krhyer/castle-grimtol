using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits = new Dictionary<string, Room>();
        public Dictionary<string, string> BlockedExits = new Dictionary<string, string>();
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
        }
        public void Door(string direction, Room room)
        {
            Exits.Add(direction, room);
        }

        public void BlockDoor(string direction, string reason)
        {
            BlockedExits.Add(direction, reason);
        }

        public void OpenDoor(string direction)
        {
            BlockedExits.Remove(direction);
        }


        public void UseItem(Item item)
        {

        }

        public bool CanExit(string direction)
        {
            if (BlockedExits.ContainsKey(direction))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(BlockedExits[direction]);
                return false;
            }
            return true;
        }
    }
}