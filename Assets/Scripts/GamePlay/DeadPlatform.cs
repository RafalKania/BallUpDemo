//**************************************************
// DeadPlatform.cs
//
// Code Soldiers 2019
//
// Author: Rafał Kania
// Creation Date: 10 March 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
	public class DeadPlatform : MonoBehaviour
	{
		//Singleton
		public static DeadPlatform Instance;

        [SerializeField]
        float platformOffset;
		
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
            if (GameManager.Instance.currentGameState == GameState.GamePlay)
            {
                if (Player.Instance._IsJumping)
                {
                    Vector3 tempTransform = transform.position;

                    tempTransform.y = Player.Instance.transform.position.y;
                    tempTransform.y += platformOffset;

                    transform.position = tempTransform;
                }
            }
        }

        public void InitDeadPlatform(Transform t)
        {
            transform.position = new Vector3(transform.position.x, t.position.y + platformOffset, t.position.z);
        }
	}
}
