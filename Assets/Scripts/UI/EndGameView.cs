using UnityEngine;
using TMPro;

namespace CodeSoldiers
{
	public class EndGameView : MonoBehaviour
	{
		//Singleton
		public static EndGameView Instance;

        [SerializeField]
        Animator animator = null;

        public TextMeshProUGUI scoreText = null;
        public TextMeshProUGUI recordScoreText = null;
		
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

        private void OnEnable()
        {
            animator.SetTrigger("Show");

            PlayerManager.Instance.SumTotalScore();
            PlayerManager.Instance.SetBestScore();

            scoreText.text = string.Format("{0}", PlayerManager.Instance._PlayerScore);
            recordScoreText.text = string.Format("{0}", PlayerManager.Instance._PlayerRecordScore);

            GameManager.Instance.dataStorage.SaveGameData();
        }

        private void OnDisable()
        {
            
        }

        public void Show()
        {

        }

        public void Hide()
        {
            animator.SetTrigger("Hide");
        }

        public void DisableEndGameView()
        {
            gameObject.SetActive(false);
        }

        public void RestartGame()
        {
            Hide();

            if (GameManager.Instance.adsDisabled == false)
            {
                if (GameManager.Instance._PlayedGames % 1 > 0)
                {
                    GameManager.Instance.SetGameState(GameState.GamePlay);
                }
                else
                {
                    GameManager.Instance.SetGameState(GameState.GamePlay);
                }
            }
            else
            {
                GameManager.Instance.SetGameState(GameState.GamePlay);
            }
        }

        public void Share()
        {
            Hide();
            ShareManager.Instance.ShareScore();
            GameManager.Instance.SetGameState(GameState.MainMenu);
        }

        public void BackToMenu()
        {
            Hide();

            if (GameManager.Instance.adsDisabled == false)
            {
                if (GameManager.Instance._PlayedGames % 1 > 0)
                {
                    GameManager.Instance.SetGameState(GameState.MainMenu);
                }
                else
                {
                    GameManager.Instance.SetGameState(GameState.MainMenu);
                }
            }
            else
            {
                GameManager.Instance.SetGameState(GameState.MainMenu);
            }
        }
    }
}
