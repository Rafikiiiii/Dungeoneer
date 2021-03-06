using System;
using System.Collections.Generic;
using System.Text;

namespace DavidGame {
    public class UserAction {
        public Action Action { get; internal set; }
        public Direction MoveDirection { get; internal set; }
    }
}
