using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Game
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum GameCharacterType
        {
            None,
            Marty,
            Doc,
            Einstein,
            Jennifer, 
            Clara
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _timeLocationID;
        private GameCharacterType _character;
        

        #endregion


        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int TimeLocationID
        {
            get { return _timeLocationID; }
            set { _timeLocationID = value; }
        }

        public GameCharacterType GameCharacter
        {
            get { return _character; }
            set { _character = value; }
        }

        
        #endregion


        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, GameCharacterType character, int timeLocationID)
        {
            _name = name;
            _character = character;
            _timeLocationID = timeLocationID;
            
        }

        #endregion


        #region METHODS



        #endregion




    }
}
