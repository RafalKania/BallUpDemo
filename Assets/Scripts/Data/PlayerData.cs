//**************************************************
// PlayerData.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 29 December 2019
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
    [System.Serializable]
    public class PlayerData
    {
        public uint playerTotalScore;
        public uint playerBestScore;
        public uint playerDiamonds;
        public int playerCurrentLevel;

        public PlayerData(uint _totalScore, uint _bestScore, uint _diamonds, int _playerCurrentLevel)
        {
            playerTotalScore = _totalScore;
            playerBestScore = _bestScore;
            playerDiamonds = _diamonds;
            playerCurrentLevel = _playerCurrentLevel;
        }
    }
}
