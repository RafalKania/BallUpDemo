using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CodeSoldiers
{
	public class SceneLoader : MonoBehaviour
	{
		//Singleton
		public static SceneLoader Instance;
        public Image loadBar = null;

        AsyncOperation asyncLoad;


        void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
		}
		
		void Start()
		{
            loadBar.fillAmount = 0;
            StartCoroutine(LoadYourAsyncScene());
        }
		
		void Update()
		{
            loadBar.fillAmount = asyncLoad.progress;
        }

        IEnumerator LoadYourAsyncScene()
        {
            asyncLoad = SceneManager.LoadSceneAsync("Main");
            
            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                //loadBar.fillAmount = asyncLoad.progress;
                yield return null;
            }
        }

    }
}
