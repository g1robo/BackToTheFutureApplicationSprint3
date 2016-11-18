using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Game
{
    /// <summary>
    /// define all treasure objects
    /// </summary>
    public class Treasure : GameObject
    {
        public enum Type
        {
            Keys,
            Cane,
            GoldCoin,
            Map,
            PhoneBook,
            Nikes,
            
        }

        public override int GameObjectID { get; set; }

        public override string Name { get; set; }

        public Type TreasureType { get; set; }

        public override string Description { get; set; }

        public override int YearTimeLocationID { get; set; }

        public override bool HasValue { get; set; }

        public override int Value { get; set; }

        public override bool CanAddToInventory { get; set; }

    }
}
