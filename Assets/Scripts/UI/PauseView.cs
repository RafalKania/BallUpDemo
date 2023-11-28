//**************************************************
// PauseView.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 20 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CodeSoldiers
{

    public enum UnpauseState
    {
        Menu,
        Gameplay
    }

	public class PauseView : MonoBehaviour
	{
		//Singleton
		public static PauseView Instance;

        [SerializeField]
        Animator animator = null;

        public TextMeshProUGUI recordScoreText = null;

        [SerializeField]
        UnpauseState currentState;
		
		void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
		}
		
		void Start()
		{
            animator = GetComponent<Animator>();
		}
		
		void Update()
		{
			
		}

        public void OnEnable()
        {
            animator.SetTrigger("Show");
            recordScoreText.text = string.Format("{0}", PlayerManager.Instance._PlayerRecordScore);
            Player.Instance.PausePlayer();

            //RaycastStopper.Instance.gameObject.SetActive(true);
        }

        public void OnDisable()
        {
            
        }

        public void SetUnpauseState(UnpauseState _state)
        {
            currentState = _state;
        }

        public void ResumeClick()
        {
            SetUnpauseState(UnpauseState.Gameplay);
            animator.SetTrigger("Hide");
        }

        public void BackToMenuClick()
        {
            SetUnpauseState(UnpauseState.Menu);
            animator.SetTrigger("Hide");
        }

        public void Back()
        {
            switch(currentState)
            {
                case UnpauseState.Menu:
                    GameManager.Instance.SetGameState(GameState.MainMenu);
                    Time.timeScale = 1;
                    GameManager.Instance.isGamePaused = false;

                    var pos = 0;

                    foreach (ObstacleElement o in ObstacleHolder.Instance._ObstacleElements)
                    {

                        o.gameObject.SetActive(false);
                        o.transform.position = new Vector3(0, pos * 8, 0);
                        pos += 1;
                    }

                    Player.Instance.ResetPlayer();
                    DeadPlatform.Instance.gameObject.SetActive(false);

                    break;
                case UnpauseState.Gameplay:
                    Time.timeScale = 1;
                    GameManager.Instance.isGamePaused = false;

                    if (UIManager.Instance._GameplayView.gameObject.activeSelf == false)
                        UIManager.Instance._GameplayView.gameObject.SetActive(true);
                    else
                        UIManager.Instance._GameplayView.ShowGameplayView();
                    Player.Instance.UnpausePlayer();
                    break;
            }
            gameObject.SetActive(false);
            //RaycastStopper.Instance.gameObject.SetActive(false);
        }
    }
}
