
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeSoldiers
{
    public class MainMenuView : MonoBehaviour
    {
        //Singleton
        public static MainMenuView Instance;

        public Button soundOnButton = null;
        public Button soundOffButton = null;

        [SerializeField]
        Animator animator = null;

        [SerializeField]
        GridLayoutGroup gridLayoutGroup = null;

        void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;
        }

        private void OnEnable()
        {
            animator.SetTrigger("Show");
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public void StartGame()
        {
            animator.SetTrigger("Hide");
            GameManager.Instance.SetGameState(GameState.GamePlay);
        }

        public void ShowMainMenuView()
        {
            animator.SetTrigger("Show");
        }

        public void DisableSound()
        {
            SoundManager.Instance.SetSound(true);
            GameManager.Instance.dataStorage.SaveGameData();
        }

        public void EnableSound()
        {
            SoundManager.Instance.SetSound(false);
            GameManager.Instance.dataStorage.SaveGameData();
        }

        public void SetGamePlayState()
        {
            GameManager.Instance.SetGameState(GameState.GamePlay);
        }
    }
}