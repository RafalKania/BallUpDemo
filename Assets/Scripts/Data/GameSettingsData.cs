//**************************************************
// GameSettingsData.cs
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
    public class GameSettingsData 
	{
        public int startedGames;
        public int playedGames;

        public GameSettingsData(int _startedGames, int _playedGames)
        {
            startedGames = _startedGames;
            playedGames = _playedGames;
        }
    }
}
