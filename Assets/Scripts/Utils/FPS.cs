using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CodeSoldiers
{
	public class FPS : MonoBehaviour
	{
		//Singleton
		public static FPS Instance;

        public TextMeshProUGUI fps = null;

        float deltaTime = 0.0f;

        void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
		}
		
		void Start()
		{
			fps = GetComponent<TextMeshProUGUI>();
		}

        void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

            DisplayFPS(deltaTime);
        }

        private void DisplayFPS(float dt)
        {
            float msec = dt * 1000.0f;
            float f = 1.0f / dt;

            if (f < 15)
            {
                fps.color = Color.red;
            }
            else if (f >= 15 && f < 30)
            {
                fps.color = Color.yellow;
            }
            else
            {
                fps.color = Color.green;
            }

            fps.text = $"FPS: {(int)f}";
        }
    }
}
