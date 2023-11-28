//**************************************************
// DataStorage.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 11 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CodeSoldiers
{
	public class DataStorage : MonoBehaviour
	{
		//Singleton
		public static DataStorage Instance;

        [SerializeField]
        GameData gameData;
        public GameData _GameData
        {
            get
            {
                return gameData;
            }
        }

        void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
		}
		
		void Start()
		{
			
		}
		
		void Update()
		{
			
		}

        public void InitializeData()
        {
            string destination = Application.persistentDataPath + "/s.sbu";

            if (File.Exists(destination))
            {
                LoadGameData();
            }
            else
            {
                SaveGameData();
            }
        }

        public void SaveGameData()
        {
            string destination = Application.persistentDataPath + "/s.sbu";
            FileStream file;

            if (File.Exists(destination))
                file = File.OpenWrite(destination);
            else
                file = File.Create(destination);

            PlayerData playerData = new PlayerData(PlayerManager.Instance._PlayerTotalScore, PlayerManager.Instance._PlayerRecordScore, PlayerManager.Instance._PlayerDiamonds, PlayerManager.Instance._PlayerCurrentLevel);
            SettingsData settingsData = new SettingsData(GameManager.Instance.soundDisabled, GameManager.Instance.adsDisabled);
            GameSettingsData gameSettingsData = new GameSettingsData(GameManager.Instance._StartedGames, GameManager.Instance._PlayedGames);

            GameData data = new GameData(playerData, settingsData, gameSettingsData);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);
            file.Close();

            Debug.Log("Game Saved");
        }

        public void LoadGameData()
        {
            string destination = Application.persistentDataPath + "/s.sbu";
            FileStream file;

            if (File.Exists(destination))
                file = File.OpenRead(destination);
            else
            {
                Debug.LogError("File not found");
                return;
            }

            BinaryFormatter bf = new BinaryFormatter();
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            //if (GameManager.Instance._StartedGames == 1)
            //{
            //    PlayerManager.Instance._PlayerPaintBlobs = 50;
            //}
            //else
            //{
            //    PlayerManager.Instance._PlayerPaintBlobs = data.playerData.playerBlobs;
            //}

            PlayerManager.Instance._PlayerRecordScore = data.playerData.playerBestScore;
            PlayerManager.Instance._PlayerTotalScore = data.playerData.playerTotalScore;
            PlayerManager.Instance._PlayerDiamonds = data.playerData.playerDiamonds;

            GameManager.Instance._StartedGames = data.gameSettingsData.startedGames;
            GameManager.Instance._PlayedGames = data.gameSettingsData.playedGames;
            GameManager.Instance.soundDisabled = data.settingsData.isSoundDisabled;
            GameManager.Instance.adsDisabled = data.settingsData.isAdvertisingDisabled;

            gameData = data;

            Debug.Log("Data loaded");

        }

#if UNITY_EDITOR
        /// <summary>
        /// Prints saved player profile data from player prefs
        /// </summary>
        //[MenuItem("Utils/Prefs/Print Player Profile")]
        //public static void PrintPlayerProfileData()
        //{
        //    Debug.Log("Printing Player Profile Data");
        //    if (PlayerPrefs.HasKey(Keys.SaveData.PLAYERDATA_KEY))
        //    {
        //        Debug.Log(PlayerPrefs.GetString(Keys.SaveData.PLAYERDATA_KEY));
        //    }
        //    else
        //    {
        //        Debug.LogError("No data under key: " + Keys.SaveData.PLAYERDATA_KEY);
        //    }
        //}

        /// <summary>
        /// Deletes player profile from player prefs
        /// </summary>
        [MenuItem("Utils/Data/Delete Player Profile")]
        public static void DeletePlayerData()
        {
            Debug.Log("Removing Player Save Data");
            File.Delete(Application.persistentDataPath + "/s.sbu");
        }
#endif
    }
}
