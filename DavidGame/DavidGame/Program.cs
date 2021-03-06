using System;
using System.IO;

namespace DavidGame {
    class Program {
        static void Main() {

            var gam = BeforeGameStarts();
            bool isPlayerPlaying = true;

            gam.ThePlayer1.Name = Input.GetUserInput("Please enter your player name: ");

            Display.WriteMessage($"Hello there {gam.ThePlayer1.Name}");


            gam.PlayerLocation = 1;
            string lastPlaterAction = string.Empty;
            while (isPlayerPlaying == true) {
                Display.Clear();
                Display.WriteMessage(lastPlaterAction);

                gam.DescribeLocation(gam.PlayerLocation);
                Location currentlocation = gam.GetLocationByID(gam.PlayerLocation);

                UserAction theInput = Input.GetUserAction("Do you want to leave or stay?");

                if (theInput.Action == Action.Exit) {

                    isPlayerPlaying = false;
                }

               if (gam.TryToMove(theInput.MoveDirection)) {
                    lastPlaterAction = "You are moving north";

                }else {
                    lastPlaterAction = "You cannot go that way";
                }



              
                
                










                if (theInput.Action == Action.Unknown) {

                    lastPlaterAction = "Please enter a valid input";

                }
            }

        }

        static GameEngine BeforeGameStarts() {

            var result = new GameEngine();

            var player1 = new Player();
            result.AddPlayer(player1);
            CreateWorld(result);

            result.PlayerLocation = 01;

            return result;

        }

        private static void CreateWorld(GameEngine theGam) {
            var filenames = Directory.GetFiles(@"C:\Users\david\OneDrive\Documents\Code\DavidGame\_Dependencies\LocationData\");
            foreach (var filename in filenames) {
                var newlocation = LoadLocationFromFile(filename);
                theGam.AddLocation(newlocation);
            }
        }

            private static Location LoadLocationFromFile(string filePath) {
                Location result = null;
                int lineNumber = 0;
                var fileContents = File.ReadAllLines(filePath);
                int locationID = int.Parse(fileContents[lineNumber]);
                lineNumber++; lineNumber++;
                result = new Location(locationID);
                result.Name = fileContents[lineNumber];
                lineNumber += 2;

                while (fileContents[lineNumber] != "###") {
                    result.Description += fileContents[lineNumber];
                    result.Description += Environment.NewLine;
                    lineNumber++;

                }

                lineNumber++;

                while (fileContents[lineNumber] != "###") {

                    string temp = fileContents[lineNumber].Substring(2);

                    int roomlocation = int.Parse(temp);

                    if (fileContents[lineNumber].StartsWith("S:")) {
                        result.SetExit(Direction.South,roomlocation);
                    }


                    if (fileContents[lineNumber].StartsWith("N:")) {
                    result.SetExit(Direction.North, roomlocation);
                }


                if (fileContents[lineNumber].StartsWith("E:")) {
                    result.SetExit(Direction.East, roomlocation);
                }


                if (fileContents[lineNumber].StartsWith("W:")) {
                    result.SetExit(Direction.West, roomlocation);
                }



                lineNumber++;

                }










                return result;
            }

        }






    }



