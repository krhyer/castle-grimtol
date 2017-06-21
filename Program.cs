using System;
using CastleGrimtol.Game;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var game = new Game.Game();
            game.Setup();
            game.Look();
            game.Playing = true;
            while (game.Playing)
            {
                string userChoice = game.GetUserInput().ToLower();
                string[] userAction = userChoice.Split(' ');
                string userCommand = userAction[0];
                string commandDetail = "";
                if (userAction.Length > 1)
                {
                    commandDetail = userAction[1];
                }
                
                if (userCommand == "g" || userCommand == "go")
                {
                    game.Move(commandDetail);                    
                }
                else if (userCommand == "l" || userCommand == "look")
                {
                    game.Look();
                }
                else if (userCommand == "h" || userCommand == "help")
                {
                    game.Help();
                }
                else if (userCommand == "i" || userCommand == "inventory")
                {
                    game.CurrentPlayer.ShowInventory();
                }
                else if (userCommand == "t" || userCommand == "take" && commandDetail != null)
                {
                    game.TakeItem(commandDetail);
                }
                else if (userCommand == "u" || userCommand == "use" && commandDetail != null)
                {
                    game.UseItem(commandDetail);
                }
                else if (userCommand == "q" || userCommand == "quit")
                {
                    game.Quit();
                }
                else if (userCommand == "u" || userCommand == "use")
                {
                    game.UseItem(commandDetail);

                }

            }
        }
    }
}
