//**************************************************
// Obstacle.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 11 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
    public enum ObstacleRotationDirection
    {
        Forward, 
        Back
    }

	public class Obstacle : MonoBehaviour
	{

        [SerializeField]
        Diamond diamond = null;
        public Diamond _Diamond
        {
            get
            {
                return diamond;
            }
        }

        [SerializeField]
        ObstacleElement parentElement = null;

        [SerializeField]
        ObstacleType obstacleType = null;
        public ObstacleType _ObstacleType
        {
            get
            {
                return obstacleType;
            }
        }
		
		void Awake()
		{

		}
		
		void Start()
		{
			
		}
		
		private void Update()
		{

		}

        private void OnEnable()
        {
            ShowDiamond();
        }

        private void OnDisable()
        {
            
        }

        private void ShowDiamond()
        {
            int rand = Random.Range(0, 100);

            if (parentElement.isSpecial == false)
            {
                if (rand < 45)
                {
                    if (diamond.gameObject.activeSelf == false)
                        diamond.gameObject.SetActive(true);
                }
                else
                {
                    diamond.gameObject.SetActive(false);
                }
            }
            else
            {
                if (diamond.gameObject.activeSelf == false)
                    diamond.gameObject.SetActive(true);
            }
        }
    }
}
