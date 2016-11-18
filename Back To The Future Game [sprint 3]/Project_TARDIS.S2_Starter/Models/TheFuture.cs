using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Back_To_The_Future_Game
{
    /// <summary>
    /// the Year class manages all of the game elements
    /// </summary>
    public class Year
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all year locations
        //
        public List<YearLocation> YearLocations { get; set; }

        //
        // list of all items
        //
        public List<Item> Items { get; set; }


        //
        // list of all treasure
        //
        public List<Treasure> Treasures { get; set; }

        //
        // list of all bad guys
        //
        public List<BadGuy> BadGuys { get; set; }

        #endregion

        #region ***** constructor *****

        //
        // default Year constructor
        //
        public Year()
        {
            //
            // instantiate the lists of locations and game objects
            //
            this.YearLocations = new List<YearLocation>();
            this.Items = new List<Item>();
            this.Treasures = new List<Treasure>();
            this.BadGuys = new List<BadGuy>();

            //
            // add all of the locations and game objects to their lists
            // 
            IntializeFutureYearTimeLocations();
            IntializeFutureItems();
            IntializeFutureTreasures();
            IntializeFutureBadGuys();
        }

        #endregion

        #region ***** define methods to get the next available ID for game elements *****

        /// <summary>
        /// return the next available ID for a YearLocation object
        /// </summary>
        /// <returns>next SpaceTimeLocationObjectID </returns>
        private int GetNextYearLocationID()
        {
            int MaxID = 0;

            foreach (YearLocation YTLocation in YearLocations)
            {
                if (YTLocation.YearTimeLocationID > MaxID)
                {
                    MaxID = YTLocation.YearTimeLocationID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for an item
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextItemID()
        {
            int MaxID = 0;

            foreach (Item item in Items)
            {
                if (item.GameObjectID > MaxID)
                {
                    MaxID = item.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for a treasure
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextTreasureID()
        {
            int MaxID = 0;

            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID > MaxID)
                {
                    MaxID = treasure.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        #endregion

        #region ***** define methods to return game element objects *****

        /// <summary>
        /// get a YearLocation object using an ID
        /// </summary>
        /// <param name="ID"> location ID</param>
        /// <returns>requested location</returns>
        public YearLocation GetYearTimeLocationByID(int ID)
        {
            YearLocation spt = null;

            //
            // run through the location list and grab the correct one
            //
            foreach (YearLocation location in YearLocations)
            {
                if (location.YearTimeLocationID == ID)
                {
                    spt = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (spt == null)
            {
                string feedbackMessage = $"The location ID {ID} does not exist.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);

            }

            return spt;
        }

        /// <summary>
        /// get an item using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested item object</returns>
        public Item GetItemtByID(int ID)
        {
            Item requestedItem = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Item item in Items)
            {
                if (item.GameObjectID == ID)
                {
                    requestedItem = item;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (requestedItem == null)
            {
                string feedbackMessage = $"The Item ID {ID} does not exist in the current Year.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedItem;
        }

        /// <summary>
        /// get a treasure using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested treasure object</returns>
        public Treasure GetTreasuretByID(int ID)
        {
            Treasure requestedTreasure = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID == ID)
                {
                    requestedTreasure = treasure;
                };
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (requestedTreasure == null)
            {
                string feedbackMessage = $"The treasure ID {ID} does not exist in the current Year.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedTreasure;
        }

        #endregion

        #region ***** define methods to get lists of game elements by location *****


        /// get a list of items using a location ID
        /// </summary>
        /// <param name="ID"> location ID</param>
        /// <returns>list of items in the specified location</returns>
        public List<Item> GetItemsByYearTimeLocationID(int ID)
        {
       
            List<Item> itemsInYearTimeLocation = new List<Item>();

            //
            // run through the item list and put all items in the current location
            // into a list
            //
            foreach (Item item in Items)
            {
                if (item.YearTimeLocationID == ID)
                {
                    itemsInYearTimeLocation.Add(item);
                }
            }

            if (itemsInYearTimeLocation == null)
            {
                string feedbackMessage = $"The Item ID {ID} does not exist in the current Year.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }
            return itemsInYearTimeLocation;
        }

        /// get a list of treasures using a location ID
        /// </summary>
        /// <param name="ID">location ID</param>
        /// <returns>list of treasures in the specified location</returns>
        public List<Treasure> GetTreasuressByYearTimeLocationID(int ID)
        {
           
            List<Treasure> treasuresInYearTimeLocation = new List<Treasure>();

            //
            // run through the treasure list and put all items in the current location
            // into a list
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.YearTimeLocationID == ID)
                {
                    treasuresInYearTimeLocation.Add(treasure);
                }
            }
            if (treasuresInYearTimeLocation == null)
            {
                string feedbackMessage = $"The Treasure ID {ID} does not exist in the current Year.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }
            return treasuresInYearTimeLocation;
        }

        public List<BadGuy> GetBadGuysByYearTimeLocationID(int ID)
        {
           
            List<BadGuy> BadGuysInYearTimeLocation = new List<BadGuy>();

            //
            // run through the item list and put all items in the current location
            // into a list
            //
            foreach (BadGuy badGuys in BadGuys)
            {
                if (badGuys.TimeLocationID == ID)
                {
                    BadGuysInYearTimeLocation.Add(badGuys);
                }
            }
            if (BadGuysInYearTimeLocation == null)
            {
                string feedbackMessage = $"The ID {ID} does not exist in the current Year.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }
            return BadGuysInYearTimeLocation;
        }

       

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the future with all of the locations
        /// </summary>
        private void IntializeFutureYearTimeLocations()
        {
            YearLocations.Add(new YearLocation
            {
                Name = "1955",
                YearTimeLocationID = 1,
                Description = "The year is 1955, a time where you went to the drive in, a sock hop, and steady. " +
                              "You just arrived at the Enchantment of Sea dance and who would have ever thought 1955 could have been this fun." +
                              "You just realized that you left your photo of your family in another year",
                Accessable = true
            });

            YearLocations.Add(new YearLocation
            {
                Name = "1985",
                YearTimeLocationID = 2,
                Description = "The year is 1985, a time where everything is neon and radical " +
                              "You just walked into the door of your house and are so glad to be home. " +
                              "Then you realize that you left your walkman in another year.",
                Accessable = false
            });

            YearLocations.Add(new YearLocation
            {
                Name = "2015",
                YearTimeLocationID = 3,
                Description = "The year is 2015, thought to be a time of flying cars and hoverboards. " +
                  "You arrive in 2015 looking to see the Chicago Cubs winning the world series, " +
                  "then you realize that you left your sports almanac in another year.",
                Accessable = true
            });
            YearLocations.Add(new YearLocation
            {
                Name = "1885",
                YearTimeLocationID = 4,
                Description = "The year is 1885, a time where a good time included whiskey and a gun. " +
                              "You just arrived at the Good Ole Saloon and sit down for a drink. " +
                              "Then you realize that you left your colt 45 in another year.",
                Accessable = true
            });
            YearLocations.Add(new YearLocation
            {
                Name = "1925",
                YearTimeLocationID = 5,
                Description = "The year is 1925, a time where automobiles started to rule the road. " +
                                         "You just arrived at the Motorists Motel to reserve your room. " +
                                         "Then you realize that you left your newest edition of The Great Gasby in another year.",
                Accessable = true
            });
            YearLocations.Add(new YearLocation
            {
                Name = "2045",
                YearTimeLocationID = 6,
                Description = "The year is 2045, The flying car rules the airway. " +
                                         "You just arrived at the park to watch virtual televison. " +
                                         "Then you realize that you left your virtual glasses in another year.",
                Accessable = true
            });
        }

        /// <summary>
        /// initialize the future with all of the items
        /// </summary>
        private void IntializeFutureItems()
        {
            Items.Add(new Item
            {
                Name = "Photo",
                GameObjectID = 1,
                Description = "A polaroid photo taken of you and your family in front of the house.",
                YearTimeLocationID = 3,
                HasValue = false,
                Value = 15,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Guitar",
                GameObjectID = 2,
                Description = "This sweet, red fender guitar is the only guitar worth playing.",
                YearTimeLocationID = 2,
                HasValue = true,
                Value = 500,
                CanAddToInventory = false
            });

            Items.Add(new Item
            {
                Name = "Hoverboard",
                GameObjectID = 3,
                Description = "Mattel Toy Maker produces a board similar to a skateboard that hovers above the ground.",
                YearTimeLocationID = 2,
                HasValue = true,
                Value = 200,
                CanAddToInventory = true,
                InInventory = true
            });

            Items.Add(new Item
            {
                Name = "Gun",
                GameObjectID = 4,
                Description = "A beautiful white handle to go with the all chrome Colt 45.",
                YearTimeLocationID = 1,
                HasValue = true,
                Value = 45,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Almanac",
                GameObjectID = 5,
                Description = "This sports almanac will give the sports scores of every team spanning 50 years, is it worth the bet?",
                YearTimeLocationID = 5,
                HasValue = true,
                Value = 300,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Book",
                GameObjectID = 6,
                Description = "An American classic, The Great Gasby stands the test of time.",
                YearTimeLocationID = 4,
                HasValue = false,
                Value = 10,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Sony Walkman",
                GameObjectID = 7,
                Description = "A yellow cassette tape player with matching yellow headphones.",
                YearTimeLocationID = 6,
                HasValue = false,
                Value = 20,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Virtual Glasses",
                GameObjectID = 8,
                Description = "These one size fits all glasses allow you to watch television or surf the web.",
                YearTimeLocationID = 1,
                HasValue = true,
                Value = 150,
                CanAddToInventory = true
            });
        }

        /// <summary>
        /// initialize the future with all of the treasures
        /// </summary>
        private void IntializeFutureTreasures()
        {
            Treasures.Add(new Treasure
            {
                Name = "Keys",
                TreasureType = Treasure.Type.Keys,
                GameObjectID = 1,
                Description = "Keys to the Delorean that can take you anywhere.",
                YearTimeLocationID = 2,
                HasValue = true,
                Value = 50,
                CanAddToInventory = true
            });

            Treasures.Add(new Treasure
            {
                Name = "Cane",
                TreasureType = Treasure.Type.Cane,
                GameObjectID = 2,
                Description = "A gold crusted knuckle handle is at the tip of the cane.",
                YearTimeLocationID = 3,
                HasValue = false,
                Value = 15,
                CanAddToInventory = true
            });

            Treasures.Add(new Treasure
            {
                Name = "Gold Coin",
                TreasureType = Treasure.Type.GoldCoin,
                GameObjectID = 3,
                Description = "This coin can pay for a lot in 1885.",
                YearTimeLocationID = 5,
                HasValue = true,
                Value = 35,
                CanAddToInventory = true
            });

            Treasures.Add(new Treasure
            {
                Name = "Map",
                TreasureType = Treasure.Type.Map,
                GameObjectID = 4,
                Description = "This map has been around for centuries and is the only thing that will help navigate the future.",
                YearTimeLocationID = 1,
                HasValue = true,
                Value = 100,
                CanAddToInventory = false
            });

            Treasures.Add(new Treasure
            {
                Name = "Phone Book",
                TreasureType = Treasure.Type.PhoneBook,
                GameObjectID = 5,
                Description = "This black pocket phone book has all the phone numbers needed to get a hold of everyone in the future.",
                YearTimeLocationID = 6,
                HasValue = false,
                Value = 40,
                CanAddToInventory = true
            });

            Treasures.Add(new Treasure
            {
                Name = "Nikes",
                TreasureType = Treasure.Type.Nikes,
                GameObjectID = 6,
                Description = "These Nikes are the second Air Jordan's that everyone has been looking for.",
                YearTimeLocationID = 5,
                HasValue = true,
                Value = 80,
                CanAddToInventory = true
            });
        }
        
        private void IntializeFutureBadGuys()
        {
            BadGuys.Add(new BadGuy
            {
                Name = "Biff",
                TimeLocationID = 1,
                Description = "Biff is bully who doesn't like people who are trying to take his almanac.",
                HasMessage = true,
                Message = "Hey Butthead! What are you doing back here? I thought I told you never to come back!",
                NiceMessage = false,

            });
            BadGuys.Add(new BadGuy
            {
                Name = "Griff",
                TimeLocationID = 3,
                Description = "Griff does what he likes and is always into trouble.",
                HasMessage = true,
                Message = ("Hello? Hello? Is there anybody home?"),
                NiceMessage = true

            });

            BadGuys.Add(new BadGuy
            {
                Name = "Mad Dog",
                TimeLocationID = 4,
                Description = "Mad Dog likes to shoot first and ask questions last.",
                HasMessage = true,
                Message = ($"I thought I told you never to come back to these parts."),
                NiceMessage = false,

            });
        }
        #endregion

    }
}

