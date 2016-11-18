using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Game
{
    public class Item : GameObject
    {
        public override int GameObjectID { get; set; }

        public override string Name { get; set; }

        public override string Description { get; set; }

        public override int YearTimeLocationID { get; set; }

        public override bool HasValue { get; set; }

        public override int Value { get; set; }

        public override bool CanAddToInventory { get; set; }

    }
}
