//**************************************************
// GameData.cs
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
    [System.Serializable]
	public class GameData
	{
        public PlayerData playerData;
        public SettingsData settingsData;
        public GameSettingsData gameSettingsData;

        public GameData(PlayerData _playerData, SettingsData _settingsData, GameSettingsData _gameSettingsData)
        {
            playerData = _playerData;
            settingsData = _settingsData;
            gameSettingsData = _gameSettingsData;
        }
	}
}
