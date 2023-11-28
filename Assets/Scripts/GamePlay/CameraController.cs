//**************************************************
// CameraController.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 16 December 2019
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
	public class CameraController : MonoBehaviour
	{
		//Singleton
		public static CameraController Instance;

        [SerializeField]
        new Camera camera = null;
        public Camera _Camera
        {
            get
            {
                return camera;
            }
        }

        [SerializeField]
        Vector3 cameraOriginalPosition;

        [SerializeField]
        float cameraOffset;

        [SerializeField]
        float shakeAmount = 0.7f;

        [SerializeField]
        bool shouldShake = false;

        [SerializeField]
        Player player;
        public Player _Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
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
            cameraOriginalPosition = camera.transform.localPosition;

            if (Screen.width == 297 && Screen.height == 594)
            {
                camera.orthographicSize = 6;
            }
            else if (Screen.width == 334 && Screen.height == 594)
            {
                camera.orthographicSize = 5;
            }
            else if (Screen.width == 1440 && Screen.height == 2960)
            {
                camera.orthographicSize = 6;
            }
            else if (Screen.width == 1440 && Screen.height == 2560)
            {
                camera.orthographicSize = 5;
            }
            else if (Screen.width == 1080 && Screen.height == 2160)
            {
                camera.orthographicSize = 6;
            }
            else if (Screen.width == 1080 && Screen.height == 1920)
            {
                camera.orthographicSize = 5;
            }
            else if (Screen.width == 720 && Screen.height == 1280)
            {
                camera.orthographicSize = 5;
            }
            else if (Screen.width == 480 && Screen.height == 800)
            {
                camera.orthographicSize = 5;
            } 
            else
            {
                camera.orthographicSize = 6;
            }
        }
		
		void Update()
		{
			if(shouldShake)
            {
                camera.transform.localPosition = cameraOriginalPosition + Random.insideUnitSphere * shakeAmount;
            }

            if (player != null)
            {
                Vector3 tempTransform = transform.position;

                tempTransform.y = player.transform.position.y;
                tempTransform.y += cameraOffset;

                transform.position = tempTransform;
            }

        }

        public IEnumerator CameraShaker()
        {
            shouldShake = true;
            yield return new WaitForSeconds(0.2f);
            shouldShake = false;
            camera.transform.localPosition = cameraOriginalPosition;
        }

        public void ShakeCamera()
        {
            StartCoroutine(CameraShaker());
        }
	}
}