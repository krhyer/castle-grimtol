using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Player : IPlayer
    {
        public int Score { get; set; }
        public List<Item> Inventory { get; set; }
        public Player(int score)
        {
            Score = score;
            Inventory = new List<Item>();
        }
        public void ShowInventory()
        {

            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"{Inventory[i].Name}\n {Inventory[i].Description}");
            }
        }
    }
}