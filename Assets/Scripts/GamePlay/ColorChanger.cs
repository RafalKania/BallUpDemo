//**************************************************
// ColorChanger.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 18 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
	public class ColorChanger : MonoBehaviour
	{
        [SerializeField]
        ObstacleType parent = null;
        public ObstacleType _Parent
        {
            get
            {
                return parent;
            }
        }

		void Awake()
		{

		}
		
		void Start()
		{
			
		}
		
		void Update()
		{
			
		}
	}
}
