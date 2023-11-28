//**************************************************
// ObstacleHolder.cs
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
	public class ObstacleHolder : MonoBehaviour
	{
		//Singleton
		public static ObstacleHolder Instance;

        [SerializeField]
        List<ObstacleElement> obstacleElements = new List<ObstacleElement>();
        public List<ObstacleElement> _ObstacleElements
        {
            get
            {
                return obstacleElements;
            }
        }

        [SerializeField]
        ObstacleElement obstacleElementPrefab = null;

        [SerializeField]
        int maxObstacles = 10;
		
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

        public void PrepareObstacles()
        {
            for (int i = 0; i < maxObstacles; i++)
            {
                var _obstacleElement = Instantiate(obstacleElementPrefab);
                _obstacleElement.gameObject.transform.parent = transform;
                _obstacleElement._ObstacleID = i + 1;
                _obstacleElement.transform.position = new Vector3(0, i * 8, 0);
                obstacleElements.Add(_obstacleElement);
                _obstacleElement.gameObject.SetActive(false);

                if ((i+1) % 5 == 0)
                {
                    _obstacleElement.isSpecial = true;
                } else
                {
                    _obstacleElement.isSpecial = false;
                }
            }
        }

        public void ActivateObstacleElement()
        {
            foreach(ObstacleElement oe in obstacleElements)
            {
                if (oe.gameObject.activeSelf == false)
                    oe.gameObject.SetActive(true);
            }
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < maxObstacles; i++)
            {
                Gizmos.DrawWireCube(new Vector3(0, i * 8, 0), new Vector3(1, 1, 1));
            }
        }
    }
}
