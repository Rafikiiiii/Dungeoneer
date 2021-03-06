using System;
using System.Collections.Generic;
using System.Text;

namespace DavidGame {
   
    public enum Direction {

        North = 0,
        East = 1,
        South = 2,
        West = 3

    }

    public enum Action {

        MoveNorth,
        MoveEast,
        MoveSouth,
        MoveWest,

        
        Exit,
        Back,
        Unknown,
        Move
    }
    
    public class Input {


        public static UserAction GetUserAction(string tellUserToStartAction) {
            UserAction result = new UserAction();
            
            Display.WriteMessage(tellUserToStartAction);

            Display.WriteMessage("Move: [N]orth, [E]ast, [S]outh, [W]est , e[X]it, [");
            string theActionInput = Console.ReadLine();

            theActionInput = theActionInput.ToLower();


            switch (theActionInput) {
                
                case "x":
                    result.Action = Action.Exit;
                    break;
                case "n":
                    result.Action = Action.Move;
                    result.MoveDirection = Direction.North;
                    break;
                case "e":
                    result.Action = Action.Move;
                    result.MoveDirection = Direction.East;

                    break;
                case "s":
                    result.Action = Action.Move;
                    result.MoveDirection = Direction.South;

                    break;
                case "w":
                    result.Action = Action.Move;
                    result.MoveDirection = Direction.West;

                    break;




                default: result.Action = Action.Unknown;
                    break;  
            }
            return result;



        }
    
    public static string  GetUserInput(string inputFromUser) {


            Display.WriteMessage(inputFromUser);


            return Console.ReadLine();
        
        }
    
    
    
    }
}
