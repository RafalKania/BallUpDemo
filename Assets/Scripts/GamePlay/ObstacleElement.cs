//**************************************************
// ObstacleElement.cs
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
    public class ObstacleElement : MonoBehaviour
    {

        [SerializeField]
        List<Obstacle> obstacles = new List<Obstacle>();
        [SerializeField]
        List<Obstacle> specialObstacles = new List<Obstacle>();

        [SerializeField]
        Obstacle currentObstacle = null;
        public Obstacle _CurrentObstacle
        {
            get
            {
                return currentObstacle;
            }
        }

        [SerializeField]
        int obstacleID = 0;
        public int _ObstacleID
        {
            get
            {
                return obstacleID;
            }

            set
            {
                obstacleID = value;
            }
        }

        public bool isSpecial = false;

        void Awake()
        {

        }

        void Start()
        {

        }

        void Update()
        {

        }

        private void OnEnable()
        {
            SetCurrentObstacle();
        }

        private void OnDisable()
        {
            if (currentObstacle != null)
                currentObstacle.gameObject.SetActive(false);
        }

        private int RandomObstacle(int scope)
        {
            int rand = Random.Range(0, scope - 1);
            return rand;
        }

        public void SetCurrentObstacle()
        {
            if (isSpecial == false)
            {
                if (obstacleID < 5)
                {
                    if (PlayerManager.Instance._PlayerScore > 4)
                    {
                        currentObstacle = obstacles[RandomObstacle(obstacles.Count)];
                    }
                    else
                    {
                        currentObstacle = obstacles[3];
                    }
                }
                else
                {
                    currentObstacle = obstacles[RandomObstacle(obstacles.Count)];
                }
            }
            else
            {
                if (obstacleID == 10)
                    currentObstacle = specialObstacles[RandomObstacle(specialObstacles.Count)];
                else if (obstacleID == 5)
                    currentObstacle = specialObstacles[3];
            }

            currentObstacle.gameObject.SetActive(true);
        }
    }
}
