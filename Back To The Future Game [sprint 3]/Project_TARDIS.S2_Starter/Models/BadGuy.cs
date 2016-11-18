using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Game
{
   public class BadGuy : Character
    {
        public string Description { get; set; }
        public bool HasMessage { get; set; }
        public string Message { get; set; }
        public bool NiceMessage { get; set; }
    }
}
