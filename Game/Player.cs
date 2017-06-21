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
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Just a bit of dirt and dust. If you want something in here, get off your lazy arse and find something, or get a job!");

            }
            else
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Console.WriteLine($"{Inventory[i].Name}\n {Inventory[i].Description}");
                }

            }

        }
    }
}