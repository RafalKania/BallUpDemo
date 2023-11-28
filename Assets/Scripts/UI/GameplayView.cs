using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeSoldiers
{
    public class GameplayView : MonoBehaviour
    {
        //Singleton
        public static GameplayView Instance;

        public TextMeshProUGUI diamondsText;
        public TextMeshProUGUI scoreText = null;
        public TextMeshProUGUI startGameText = null;

        [SerializeField]
        Animator animator = null;

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
            diamondsText.text = string.Format("{0}", PlayerManager.Instance._PlayerDiamonds);
            scoreText.text = string.Format("{0}", PlayerManager.Instance._PlayerScore);
        }

        public void OnEnable()
        {
            animator.SetTrigger("Show");
        }

        public void OnDisable()
        {
            
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            animator.SetTrigger("Hide");
            GameManager.Instance.isGamePaused = true;
            UIManager.Instance._PauseView.gameObject.SetActive(true);
        }

        public void DisableGameplayView()
        {
            gameObject.SetActive(false);
        }

        public void ShowGameplayView()
        {
            animator.SetTrigger("Show");
        }

        public void HideGameplayView()
        {
            animator.SetTrigger("Hide");
        }

    }
}