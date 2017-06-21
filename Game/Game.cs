using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Room> Rooms { get; set; }
        public void Reset()
        {
            // Console.WriteLine("Earlier in the day, you overheard that Frank \"Old Man\" Griffin has finally died! Being a thief, you were thrilled to hear this news. Rumor has it, that the old man, though he lived a very modest life, had inherited a fortune from some invention of his fathers. You suspect that his fortune sits somewhere in his house. Time is of the essense to discover this treasure, before anyone else has the chance.");
            Console.WriteLine("Hey you!");
            Console.WriteLine("Yes, you! I'm talking to you!");
            Console.WriteLine("I need your help. I, a striking beauty as you have certainly notice already, was down here picking berries. When I started home I encountered a horrible creature. Please, I beg of you. Slay the fowl beast so I can return home. I will reward you greatly.");
            CurrentPlayer = new Player(0);
            Help();
            CurrentRoom = Rooms[0];
            Look();
        }

        public void Move(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                if (CurrentRoom.CanExit(direction))
                {
                    CurrentRoom = CurrentRoom.Exits[direction];
                    Look();
                    if (CurrentRoom == Rooms[3])
                    {
                        Win();
                    }
                }
                else
                {
                    Lose();
                }
            }
            else
            {
                Console.WriteLine("You can't go that way coward");
            }
        }

        public string GetUserInput()
        {
            System.Console.WriteLine("Where will you venture?");
            string input = Console.ReadLine();
            return input;
        }

        public Boolean Playing { get; set; }

        public void Quit()
        {
            System.Console.WriteLine("Leave the game? Y/N");
            string input = Console.ReadLine().ToLower();
            if (input == "y" || input == "yes")
            {
                Playing = false;
                Console.WriteLine("GOODBYE! ....... coward");
            }
            else
            {
                System.Console.WriteLine("Go forth then, and finish your mission.");
            }
        }
        public void Look()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine($"{CurrentRoom.Name}:\n{CurrentRoom.Description}");
            for (int i = 0; i < CurrentRoom.Items.Count; i++)
            {
                System.Console.WriteLine($"Items: {CurrentRoom.Items[i].Name}\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Help()
        {
            System.Console.WriteLine("Valid actions are north and south.\nEX: north or south.\nLOOK or l: allows you to scan the room. \nHELP or h: displays a list of all the commands needed for this game.\nTAKE or t: adds an item to your inventory list. EX: Take Gold.\nUSE or u: uses an item to your inventory list. EX: Take Gold.\nINVENTORY or i: Views the items in your inventory.\nQUIT or q: leaves the game.\n");
        }

        public void Setup()
        {
            Console.WriteLine("Hey you!");
            Console.WriteLine("Yes, you! I'm talking to you!");
            Console.WriteLine("I need your help. I, a striking beauty as you have certainly notice already, was down here picking berries. When I started home I encountered a horrible creature. Please, I beg of you. Slay the fowl beast so I can return home. I will reward you greatly.");
            CurrentPlayer = new Player(0);
            Help();

            Rooms = new List<Room>();
            // ROOMS
            Room Valley = new Room("Valley Floor", "You are in a valley at the base of a hill standing by a lovely lady. You see nothing around you execpt the hill to the north. It's as if, when accepting this mission, that all other directions lost their meaning.");
            Room HillBase = new Room("Hill Base", "You are at the base of the hill. Looking ahead, you see the creature you've been told about. At your feet you've found a sword. It might come in handy. To the south lay the beautiful maiden urging you on with ernest encouragement. To the north is the creature you intend to slay. All other directions will serve you no purpose.");
            Room HillTop = new Room("Hill Top", "You've reached the top of the hill. It is here that, as you crest the top you meet your foe, a rather small green snake! Your lady anxiously awaits the outcome of the battle to the south. To the north, just beyond the rather small green snake is your ladies cottage.");
            Room Cottage = new Room("Cottage", "After vanquishing the fiendish, yet rather small green snake, you hail the maiden who meets you at her home. She showers you with hugs and kisses and she tells you she will be true to you forever!");
            Valley.Door("north", HillBase);
            HillBase.Door("south", Valley);
            HillBase.Door("north", HillTop);
            HillTop.Door("south", HillBase);
            HillTop.Door("north", Cottage);

            //ADD BLOCKED EXITS
            HillTop.BlockDoor("north", "As you try to simply walk past the snake he leaps up and bites you in the arse");
            HillTop.BlockDoor("south", "As you turn to glance at the pretty maiden the sly little snake leaps up and bites you in the arse");

            Rooms.Add(Valley);
            Rooms.Add(HillBase);
            Rooms.Add(HillTop);
            Rooms.Add(Cottage);


            // Room FrontStep = new Room("Front Step", "You're standing on the front step of \"Old Man\" Griffin's home. To the north is the door and doorbell. At your feet is a Welcome mat. To the south is a view of the neighborhood.");
            // Room Foyer = new Room("Foyer", "You are in the Foyer. To the north is a Hallway, to the west is the Living Room, to the east is the Kitchen, to the south is the front door.");
            // Room LivingRoom = new Room("Living Room", "You are in the Living Room. The room is decorated with an old lumpy sofa, a recliner, a glass coffee table, a picture of his kids, and a 42\" flat-screen TV. To the east is the Foyer.");
            // Room Kitchen = new Room("Kitchen", "You are in the Kitchen. Among the beautiful gray marble countertops and white cupboards and drawers, you see a set of stainless steel refrigerator, microwave, and stove, BlendTec mixer, spatulas, and a knifeblock. To the north is the Dining Room, to the west is the Foyer.");
            // Room DiningRoom = new Room("Dining Room", "You are in the Dining Room. A large table dominates the space circled by comfortable looking high-backed chairs. On one wall is a tapestry depicting a single bunch of delicious bananas, and in a cabinet on the other side of the room is a china set, silver flatware, and crystal goblets. To the south is the Kitchen.");
            // Room Hallway1 = new Room("Hallway1", "You are in a long Hallway. Next to you is a painting that shows three penguins staring at a hot dog. To the north is the Master Bedroom, to the west is the Bathroom, to the south is the Foyer.");
            // Room Bathroom = new Room("Bathroom", "You are in the Bathroom. Looking around you see a pedistal sink and a toilet.");
            // Room Hallway2 = new Room("Hallway2", "You are in a long Hallway. Next to you is a print that shows seven dogs playing poker. To the north is the Master Bedroom, to the east is the Den, to the south is the Foyer.");
            // Room Den = new Room("Den", "Upon entering the den, you realize that you've startled someone rummaging through draws. It appears you are not the only thief looking for the treasure. He jumps up and begins to pull a gun out from behind him.");
            // Room MasterBedroom1 = new Room("Master Bedroom1", "You are in the Master Bedroom. It appears to be a large room. You see a large bed, a nightstand, and a chest of drawers, on the other side of the room is a book on a table, and a chair with a lamp next to it. To the east is the rest of the Master Bedroom, to the west is the Master Bath, to the south is the Hallway.");
            // Room MasterBedroom2 = new Room("Master Bedroom2", "You are in the Master Bedroom. It appears to be a large room. You see a book on a table, and a chair with a lamp next to it. On the other side of the room is a large bed, a nightstand, and a chest of drawers. To the west is the Master Bath.");
            // Room MasterBath = new Room("Master Bath", "You are in the Master Bath. The countertop is littered with what appears to be empty pill bottles. There is a sink with a vanity cabinet, shower, and toilet. To the east is the Master Bedroom, to the south is the closet.");
            // Room Closet = new Room("Closet", "You are in the Closet. You are surrounded by hangup shirts and pants. At your feet is what looks like the entrance to the crawl space");
            // // ITEMS
            Item Sword = new Item("Sword", "It's a bit rusty, but better than anything you've ever held.");
            // Item SkeletonKey = new Item("Skeleton Key", "Wow, this is a really old key", 5);            
            // Item TV = new Item("TV", "42 inches, dusty", 100);
            // Item Mixer = new Item("BlendTec", "This thing will blend everything...except Chuck Norris.", 200);
            // Item Knife = new Item("Knife", "Hope you plan on cutting some vegetables with this thing.", 10);
            // Item Painting1 = new Item("Tapestry", "This painting shows a single bunch of delicious bananas, at the base of the painting is a small plaque with the name of the painting. The plaque says \"Grapefruit\"", 5000);
            // Item China = new Item("China set", "This is a decorative set of plates.", 400);
            // Item Flatware = new Item("Silver Flatware", "Tarnished. Looks like it hasn't been used in a while.", 200);
            // Item Crystal = new Item("Crystal Goblets", "As you flick it, a chime rings out. Yup, real crystal!", 200);
            // Item Painting2 = new Item("Painting", "Three penguins and a hot dog", 495);
            // Item Painting3 = new Item("Print", "Seven dogs playing poker", 50);
            // Item Book = new Item("Book", "It appears to be \"Fifty Shades of Gray\". Well, to each his own.", 5);
            // Item Lamp = new Item("Lamp", "Six foot standing lamp, nothing really impressive about it.", 50);
            // // ADD ITEMS TO ROOMS
            HillBase.Items.Add(Sword);
            // FrontStep.Items.Add(SkeletonKey);
            CurrentRoom = Valley;
        }


        public void TakeItem(string itemName)
        {
            var found = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
            if (found != null)
            {
                CurrentRoom.Items.Remove(found);
                CurrentPlayer.Inventory.Add(found);
                Console.WriteLine($"{itemName} taken");
            }
            else
            {
                Console.WriteLine("You cannot take that");
            }
        }
        // public void StealItem(string itemName)
        // {
        //     var found = CurrentRoom.Items.Find(Item => Item.Name == itemName);
        //     if(found != null)
        //     {
        //         CurrentRoom.Items.Remove(found);
        //         CurrentPlayer.Score += found.Value;
        //         Console.WriteLine($"{found} stolen");
        //     }
        //     else
        //     {
        //         Console.WriteLine("You cannot steal that");
        //     }
        // }                

        public void Lose()
        {
            Console.WriteLine("It's not a big bite, nor is it venomous, but you run away in fright, screaming like a meer lass!");
            Console.WriteLine("You Lose");
            Console.WriteLine("Score " + CurrentPlayer.Score);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Would you like to play again? (Y/N)");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                Setup();
            }
            if (input == "n")
            {
                Playing = false;
            }
        }
        public void Win()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You Win");
            Console.WriteLine("Score " + CurrentPlayer.Score);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Would you like to play again? (Y/N)");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                Setup();
            }
            if (input == "n")
            {
                Playing = false;
            }
        }

        public void UseItem(string itemName)
        {
            if (CurrentRoom == Rooms[2])
            {
                var sword = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == itemName);
                if (sword != null)
                {
                    CurrentPlayer.Inventory.Remove(sword);
                    Console.WriteLine("You raise your sword just before the snake springs out at you. You cut down across your body and take off its head.");
                    CurrentPlayer.Score += 1;
                    CurrentRoom.Description = "There is a rather small headless green snake, sadly still oozing blood..... Perhaps you could of thought of a better way to vanquish this foe.... you monster!";
                    CurrentRoom.OpenDoor("north");
                    CurrentRoom.OpenDoor("south");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No weapon? The snake springs up and bites you.");
                    Lose();
                }
            }
            else
            {
                Console.WriteLine("You can't use that here.");
            }
        }
    }
}