using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Game
{
    public class YearLocation
    {
        #region FIELDS

        private string _name;
        private int _YearTimeLocationID; // must be a unique value for each object
        private string _description;
        private bool _accessable;

        #endregion


        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int YearTimeLocationID
        {
            get { return _YearTimeLocationID; }
            set { _YearTimeLocationID = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Accessable
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion


    }
}
