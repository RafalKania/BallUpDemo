//**************************************************
// RaycastStopper.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 20 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
	public class RaycastStopper : MonoBehaviour
	{
		//Singleton
		public static RaycastStopper Instance;
		
		void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
		}
	}
}
