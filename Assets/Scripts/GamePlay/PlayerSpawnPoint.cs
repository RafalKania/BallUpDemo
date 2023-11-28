//**************************************************
// PlayerSpawnPoint.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 19 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
	public class PlayerSpawnPoint : MonoBehaviour
	{
		//Singleton
		public static PlayerSpawnPoint Instance;
		
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
