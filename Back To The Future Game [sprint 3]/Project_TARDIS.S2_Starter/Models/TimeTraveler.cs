using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Game
{
    public class Traveler : Character
    {
        #region FIELDS

        private List<Item> _travelersItems;
        private List<Treasure> _travelersTreasures;
        private int _age;
        private int _itemID;
        private int _treasureID;
        private int _itemValueAdded;
        private int _treasureValueAdded;
        private int _lives;
        private int _healthPoints;




        #endregion

        public List<Item> TravelersItems
        {
            get { return _travelersItems; }
            set { _travelersItems = value; }
        }

        public List<Treasure> TravelersTreasures
        {
            get { return _travelersTreasures; }
            set { _travelersTreasures = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        public int TreasureID
        {
            get { return _treasureID; }
            set { _treasureID = value; }
        }

        public int ItemValueAdded
        {
            get { return _itemValueAdded; }
            set { _itemValueAdded = value; }
        }

        public int TreasureValueAdded
        {
            get { return _treasureValueAdded; }
            set { _treasureValueAdded = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public int HealthPoints
        {
            get { return _healthPoints; }
            set { _healthPoints = value; }
        }
        #region PROPERTIES



        #endregion


        #region CONSTRUCTORS

        public Traveler()
        {
            _travelersItems = new List<Item>();
            _travelersTreasures = new List<Treasure>();
            _healthPoints = 100;
        }

        public Traveler(string name, GameCharacterType character, int timeLocationID) : base(name, character, timeLocationID)
        {
            _age = Age;
            _itemID = ItemID;
            _treasureID = TreasureID;
            _healthPoints = HealthPoints;

        }

        #endregion


        #region METHODS



        #endregion
    }
}
