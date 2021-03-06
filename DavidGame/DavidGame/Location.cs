using System;
using System.Collections.Generic;
using System.Text;

namespace DavidGame {
   public class Location {


        public string Name { get; set; }


        public string  Description { get; set; }

        public Dictionary<Direction, int>  Exits { get; set; }




        public int Id { get; set; }

        public Location(int newID) {

            Exits = new Dictionary<Direction, int>();

           

            Id = newID;

        }

        
        public void SetExit(Direction theDirectionOfTheExit, int theIdentityOfTheRoom) {
            Exits.Add(theDirectionOfTheExit, theIdentityOfTheRoom);
        }
        
        
        
        internal int GetExit(Direction theInput) {


            if (Exits.ContainsKey(theInput)) {
                return Exits[theInput];
            }
            return -1;
        }
    }



}
