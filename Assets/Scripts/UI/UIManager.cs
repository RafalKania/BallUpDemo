//**************************************************
// UIManager.cs
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
	public class UIManager : MonoBehaviour
	{
		//Singleton
		public static UIManager Instance;

        [SerializeField]
        MainMenuView mainMenuView = null;
        public MainMenuView _MainMenuView
        {
            get
            {
                return mainMenuView;
            }
        }

        [SerializeField]
        GameplayView gameplayView = null;
        public GameplayView _GameplayView
        {
            get
            {
                return gameplayView;
            }
        }

        [SerializeField]
        PauseView pauseView = null;
        public PauseView _PauseView
        {
            get
            {
                return pauseView;
            }
        }

        [SerializeField]
        EndGameView endGameView = null;
        public EndGameView _EndGameView
        {
            get
            {
                return endGameView;
            }
        }

        [SerializeField]
        RectTransform raycastStopper;
        public RectTransform _RaycastStopper
        {
            get
            {
                return raycastStopper;
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
	}
}