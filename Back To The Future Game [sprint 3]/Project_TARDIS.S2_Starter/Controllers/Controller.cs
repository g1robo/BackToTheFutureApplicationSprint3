using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Back_To_The_Future_Game
{
    public class Controller
    {
        #region FIELDS

        private bool _usingGame;

        //
        // declare all objects required for the game
        // Note - these field objects do not require properties since they
        //        are not accessed outside of the controller
        //
        private ConsoleView _gameConsoleView;
        private Traveler _gameTraveler;
        private Year _gameYear;

        #endregion

        #region PROPERTIES


        #endregion
        
        #region CONSTRUCTORS

        public Controller()
        {
            
            InitializeGame();

            //
            // instantiate a Salesperson object
            //
            _gameTraveler = new Traveler();

            //
            // instantiate a ConsoleView object
            //
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameYear);

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion
        
        #region METHODS

        /// <summary>
        /// initialize the game 
        /// </summary>
        private void InitializeGame()
        {
            _usingGame = true;
            _gameYear = new Year();
            _gameTraveler = new Traveler();
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameYear);

        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            
            TravelerAction travelerActionChoice;

            _gameConsoleView.DisplayWelcomeScreen();

            GameSetup();

            //
            // game loop
            //
            while (_usingGame)
            {
                UpdateGameStatus();
                //
                // get a menu choice from the ConsoleView object
                //
                travelerActionChoice = _gameConsoleView.DisplayGetTravelerActionChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case TravelerAction.None:
                        break;
                    case TravelerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case TravelerAction.LookAt:
                        _gameConsoleView.DisplayLookAt();
                        break;
                    case TravelerAction.TalkTo:
                        _gameConsoleView.DisplayTalkTo();
                        break;
                    case TravelerAction.Hover:
                        _gameConsoleView.Hover();
                        break;
                    case TravelerAction.PickUpItem:
                        int itemID;
                        itemID = _gameConsoleView.DisplayPickUpItem();
                        AddItemToTravelersInventory(itemID);
                        break;
                    case TravelerAction.PickUpTreasure:
                        int treasureID;
                        treasureID = _gameConsoleView.DisplayPickUpTreasures();
                        AddItemToTravelersTreasure(treasureID);
                        break;
                    case TravelerAction.PutDownItem:
                        itemID = _gameConsoleView.DisplayPutDownItem();
                        RemoveItemToTravelersInventory(itemID);
                        break;
                    case TravelerAction.PutDownTreasure:
                        treasureID = _gameConsoleView.DisplayPutDownTreasures();
                        RemoveItemToTravelersTreasure(treasureID);
                        break;
                    case TravelerAction.Travel:
                        _gameTraveler.TimeLocationID = _gameConsoleView.DisplayGetTravelersNewDestination().YearTimeLocationID;
                        break;
                    case TravelerAction.TravelerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;
                    case TravelerAction.TravelerInventory:
                        _gameConsoleView.DisplayTravelerItems();
                        break;
                    case TravelerAction.TravelerTreasure:
                        _gameConsoleView.DisplayTravelerTreasure();
                        break;
                    case TravelerAction.ListYearDestinations:
                        _gameConsoleView.DisplayAllYearDestinations();
                        break;
                    case TravelerAction.ListItems:
                        _gameConsoleView.DisplayListAllGameItems();
                        break;
                    case TravelerAction.ListTreasures:
                        _gameConsoleView.DisplayListAllGameTreasures();
                        break;
                    case TravelerAction.Exit:
                        _usingGame = false;
                        break;
                    default:
                        break;
                }
            }

            _gameConsoleView.DisplayExitPrompt();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        private void UpdateGameStatus()
        {
           foreach(Item item in _gameTraveler.TravelersItems)
            if (item.Value > 299 && item.HasValue == true)
            {
                    _gameConsoleView.CanAddToInventory();
            }
           foreach (Item item in _gameTraveler.TravelersItems)
            if (item.GameObjectID == 7)
            {
              _gameConsoleView.HasRequiredItemToEnterLocation(); 
            }
            if (_gameTraveler.TimeLocationID == 4 || _gameTraveler.TimeLocationID == 1)
            {
                _gameTraveler.HealthPoints-=5;
            }

            if (_gameTraveler.HealthPoints == 0)
            {
                _gameConsoleView.DisplaySpawn();
            }

            
        
         
           }

        /// <summary>
        /// initialize the traveler's starting mission  parameters
        /// </summary>
        private void GameSetup()
        {
            _gameConsoleView.DisplayMissionSetupIntro();
            _gameTraveler.Name = _gameConsoleView.DisplayGetTravelersName();
            _gameTraveler.GameCharacter = _gameConsoleView.DisplayGetTravelersRace();
            _gameTraveler.TimeLocationID = _gameConsoleView.DisplayGetTravelersNewDestination().YearTimeLocationID;

            // 
            // add initial treasures to the traveler's inventory
            //
            
            AddItemToTravelersTreasure(1);
        }

        /// <summary>
        /// add a game item to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddItemToTravelersInventory(int itemID)
        {
            Item item;
            item = _gameYear.GetItemtByID(itemID);
            item.YearTimeLocationID = 0;
            _gameTraveler.TravelersItems.Add(item);
        }

        /// <summary>
        /// add a game treasure to the traveler's inventory
        /// </summary>
        /// <param name="treasureID">treasure ID</param>
        private void AddItemToTravelersTreasure(int treasureID)
        {
            Treasure treasure;
            treasure = _gameYear.GetTreasuretByID(treasureID);
            treasure.YearTimeLocationID = 0;
                _gameTraveler.TravelersTreasures.Add(treasure);
        
        }

        /// <summary>
        /// remove a game item to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void RemoveItemToTravelersInventory(int itemID)
        {
            Item item;
            item = _gameYear.GetItemtByID(itemID);
            item.YearTimeLocationID = _gameTraveler.TimeLocationID;
                _gameTraveler.TravelersItems.Remove(item);
          
        }

        /// <summary>
        /// remove a game treasure to the traveler's inventory
        /// </summary>
        /// <param name="treasureID">treasure ID</param>
        private void RemoveItemToTravelersTreasure(int treasureID)
        {
            Treasure treasure;
            treasure = _gameYear.GetTreasuretByID(treasureID);
            treasure.YearTimeLocationID = _gameTraveler.TimeLocationID;
                _gameTraveler.TravelersTreasures.Remove(treasure);
        }

       

        #endregion
    }
}
