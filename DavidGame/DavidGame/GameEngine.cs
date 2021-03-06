using System;
using System.Collections.Generic;
using System.Text;

namespace DavidGame {
    public class GameEngine {
        public Dictionary<int, Location> TheWorld { get; set; }
        public Player ThePlayer1 { get; set; }

        public int PlayerLocation { get; set; }

        public GameEngine() {


            TheWorld = new Dictionary<int, Location>();
        }
    
    

        public void AddPlayer(Player thePlayerToAdd) {


            ThePlayer1 = thePlayerToAdd;
        }

        public Location GetLocationByID(int idOfLocation) {

            Location result = TheWorld[idOfLocation];
            return result;
        }


        public void DescribeLocation(int locationIdToDisplay) {

#if DEBUG
            if (!TheWorld.ContainsKey(locationIdToDisplay)) {

                Console.WriteLine("DEVELOPER FAULT location does not exist");

            }
#endif 
            

            Location wherePlayerIs = TheWorld[locationIdToDisplay];
            Display.WriteMessage($"You are at {wherePlayerIs.Name}");
            Display.LeaveALine();
            Display.WriteMessage($"{wherePlayerIs.Description}");

        }

        internal bool TryToMove(Direction theInput) {

            Location currentLocation = this.GetLocationByID(this.PlayerLocation);
           int exitlocation = currentLocation.GetExit(theInput);

            if (exitlocation > 0 ) {
                this.PlayerLocation = exitlocation;
                return true;
            }

            return false;





        }

        public void AddLocation(Location roomToAdd) {
            TheWorld.Add(roomToAdd.Id, roomToAdd);
        }
    }
}
