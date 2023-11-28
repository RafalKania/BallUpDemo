using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace CodeSoldiers
{
	public class ShareManager : MonoBehaviour
	{
		//Singleton
		public static ShareManager Instance;

        private string message = "";
        private string destination;

        void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
		}

        public void ShareScore()
        {
            StartCoroutine(ProcessShare());
        }

        private IEnumerator ProcessShare()
        {
            yield return new WaitForEndOfFrame();

            ScreenCapture.CaptureScreenshot("share.png", 2);
            destination = Path.Combine(Application.persistentDataPath, "share.png");
            if (Application.systemLanguage == SystemLanguage.Polish)
            {
                message = "Czy pobijesz mój rekord?";
            }
            else
            {
                message = "Can you beat my score?";
            }
            yield return new WaitForSecondsRealtime(0.3f);

            if (!Application.isEditor)
            {
                AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
                AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
                intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
                AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
                AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
                intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"),
                                                     uriObject);
                intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"),
                                                     message);
                intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
                AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser",
                                                                                      intentObject, "Share your new score");
                currentActivity.Call("startActivity", chooser);
                yield return new WaitForSecondsRealtime(1);
            }
        }
    }
}
