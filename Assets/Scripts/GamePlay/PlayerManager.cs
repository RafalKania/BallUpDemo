//**************************************************
// PlayerManager.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 19 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
	public class PlayerManager : MonoBehaviour
	{
		//Singleton
		public static PlayerManager Instance;

        [SerializeField]
        Player player = null;

        [SerializeField]
        DeadPlatform deadPlatform = null;

        [SerializeField]
        uint playerScore = 0;
        public uint _PlayerScore
        {
            get
            {
                return playerScore;
            }

            set
            {
                playerScore = value;
            }
        }

        [SerializeField]
        uint playerTotalScore;
        public uint _PlayerTotalScore
        {
            get
            {
                return playerTotalScore;
            }

            set
            {
                playerTotalScore = value;
            }
        }

        [SerializeField]
        uint playerRecordScore = 0;
        public uint _PlayerRecordScore
        {
            get
            {
                return playerRecordScore;
            }

            set
            {
                playerRecordScore = value;
            }
        }

        [SerializeField]
        uint playerCurrentDiamonds = 0;
        public uint _PlayerCurrentDiamonds
        {
            get
            {
                return playerCurrentDiamonds;
            }

            set
            {
                playerCurrentDiamonds = value;
            }
        }

        [SerializeField]
        uint playerDiamonds = 0;
        public uint _PlayerDiamonds
        {
            get
            {
                return playerDiamonds;
            }

            set
            {
                playerDiamonds = value;
            }
        }

        [SerializeField]
        int playerLives = 3;
        public int _PlayerLives
        {
            get
            {
                return playerLives;
            }

            set
            {
                playerLives = value;
            }
        }

        [SerializeField]
        int playerCurrentLevel = 0;
        public int _PlayerCurrentLevel
        {
            get
            {
                return playerCurrentLevel;
            }

            set
            {
                playerCurrentLevel = value;
            }
        }

        public bool getCombo = false;

        void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
		}

        private void Start()
        {
            
        }

        void Update()
		{

		}

        public void InstantiatePlayer()
        {
            var p = Instantiate(player);
            p.InitPlayer();

            var dp = Instantiate(deadPlatform);
            dp.InitDeadPlatform(p.transform);
        }

        public void SumTotalScore()
        {
            _PlayerTotalScore = _PlayerTotalScore + _PlayerScore;

            Debug.Log(_PlayerTotalScore);
        }

        public void SumDiamonds()
        {
            playerDiamonds += playerCurrentDiamonds;
        }

        public void SetBestScore()
        {
            if(_PlayerScore > _PlayerRecordScore)
            {
                _PlayerRecordScore = _PlayerScore;
            }
        }

        public uint CalculateDiiamonds()
        {
            uint blots = 0;

            if(playerScore == 0)
            {
                blots = 0;
            }
            else if (playerScore > 0)
            {
                blots = playerScore / 20;
            }

            playerCurrentDiamonds += blots;

            return blots;
        }

        public void Pay(uint diamonds)
        {
            _PlayerDiamonds -= diamonds;
        }

        public void RunCombo()
        {
            StartCoroutine(WaitForGetCombo());
        }

        public IEnumerator WaitForLivesLeak()
        {
            yield return new WaitUntil(() => playerLives == 0);
            GameManager.Instance.SetGameState(GameState.EndGame);
        }

        public IEnumerator WaitForGetCombo()
        {
            getCombo = true;
            yield return new WaitForSeconds(0.1f);
            getCombo = false;
        }
    }
}