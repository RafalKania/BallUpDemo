//**************************************************
// GameManager.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 11 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
    public enum GameState
    {
        MainMenu = 0,
        GamePlay,
        EndGame
    }

	public class GameManager : MonoBehaviour
	{
		//Singleton
		public static GameManager Instance;

        public GameState currentGameState = GameState.MainMenu;

        public bool isGamePaused = false;
        public bool isConnectedToNetwork = false;

        [SerializeField]
        Player player;
        public Player _Player
        {
            get
            {
                return player;
            }
        }

        [SerializeField]
        DeadPlatform deadPlatform = null;
        public DeadPlatform _DeadPlatform
        {
            get
            {
                return deadPlatform;
            }

            set
            {
                deadPlatform = value;
            }
        }

        public DataStorage dataStorage;

        //[SerializeField]
        //GameEvents gameEvents;
        //public GameEvents _GameEvents
        //{
        //    get
        //    {
        //        return gameEvents;
        //    }
        //}


        public bool soundDisabled;
        public bool adsDisabled;

        // counting the application run
        [SerializeField]
        int startedGames;
        public int _StartedGames
        {
            get
            {
                return startedGames;
            }

            set
            {
                startedGames = value;
            }
        }

        // counting started gameplays
        [SerializeField]
        int playedGames;
        public int _PlayedGames
        {
            get
            {
                return playedGames;
            }

            set
            {
                playedGames = value;
            }
        }

        [SerializeField]
        uint startingBlots;

        void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
		}
		
		void Start()
		{
            
            dataStorage = GetComponent<DataStorage>();
            //gameEvents = GetComponent<GameEvents>();

            dataStorage.InitializeData();

            //AnalyticsManager.Instance.SetGameEvents(gameEvents);

            startedGames = dataStorage._GameData.gameSettingsData.startedGames;
            startedGames += 1;

            playedGames = dataStorage._GameData.gameSettingsData.playedGames;

            //SoundManager.Instance.SetSound(soundDisabled);

            dataStorage.SaveGameData();

            //gameEvents.CallOnGameOpened();

            PlayerManager.Instance.InstantiatePlayer();

            player = Player.Instance;
            player._Rigidbody2D.gravityScale = 0;

            deadPlatform = DeadPlatform.Instance;

            SetGameState(GameState.MainMenu);
            CameraController.Instance._Player = player;

            ObstacleHolder.Instance.PrepareObstacles();
            
		}
		
		void Update()
		{
			if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
		}

        private void OnApplicationFocus(bool focus)
        {
            //if(gameEvents != null)
                //gameEvents.CallOnGamePaused(!focus);
        }

        private void OnApplicationPause(bool pause)
        {
            //if (gameEvents != null)
            //    gameEvents.CallOnGamePaused(pause);
        }

        private void OnApplicationQuit()
        {
            dataStorage.SaveGameData();

            //if (gameEvents != null)
            //    gameEvents.CallOnGameClosed();
        }

        public void SetGameState(GameState state)
        {
            currentGameState = state;

            switch (currentGameState)
            {
                case GameState.MainMenu:

                    if (UIManager.Instance._MainMenuView.gameObject.activeSelf == true)
                        UIManager.Instance._MainMenuView.ShowMainMenuView();
                    else
                        UIManager.Instance._MainMenuView.gameObject.SetActive(true);

                    if (startedGames % 10 == 0)
                    {
                        // show rate us
                    }

                    if(soundDisabled == false)
                    {
                        UIManager.Instance._MainMenuView.soundOnButton.gameObject.SetActive(true);
                        UIManager.Instance._MainMenuView.soundOffButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        UIManager.Instance._MainMenuView.soundOnButton.gameObject.SetActive(false);
                        UIManager.Instance._MainMenuView.soundOffButton.gameObject.SetActive(true);
                    }

                    break;

                case GameState.GamePlay:

                    playedGames += 1;
                    PlayerManager.Instance._PlayerScore = 0;

                    if (UIManager.Instance._GameplayView.gameObject.activeSelf == false)
                        UIManager.Instance._GameplayView.gameObject.SetActive(true);
                    else
                        UIManager.Instance._GameplayView.ShowGameplayView();

                    foreach (ObstacleElement o in ObstacleHolder.Instance._ObstacleElements)
                    {
                        o.gameObject.SetActive(true);
                    }

                    Player.Instance.SetPlayerLiveState(PlayerLiveState.Neutral);

                    break;

                case GameState.EndGame:

                    UIManager.Instance._GameplayView.gameObject.SetActive(false);

                    if (UIManager.Instance._EndGameView.gameObject.activeSelf == false)
                        UIManager.Instance._EndGameView.gameObject.SetActive(true);
                    else
                        UIManager.Instance._EndGameView.Show();

                    var pos = 0;

                    foreach (ObstacleElement o in ObstacleHolder.Instance._ObstacleElements)
                    {
                        
                        o.gameObject.SetActive(false);
                        o.transform.position = new Vector3(0, pos * 8, 0);
                        pos += 1;
                    }


                    player.ResetPlayer();

                    break;
            }
        }

        public void UpdateGameState()
        {
            //if (currentGameState == state)
            //    return;

            switch (currentGameState)
            {
                case GameState.MainMenu:
                    break;

                case GameState.GamePlay:
                    break;

                case GameState.EndGame:
                    break;
            }
        }

        public void DidsableAds()
        {
            adsDisabled = true;
        }

        public void DoubleScore()
        {
            //PlayerManager.Instance._PlayerScore *= 2;
        }

        public uint AddExtraBlobs(uint diamondsAmount)
        {
            return diamondsAmount; 
        }
    }
}