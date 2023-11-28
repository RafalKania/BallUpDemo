//**************************************************
// ObstacleType.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 26 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{

    public enum ObstacleColorType
    {
        None = 0,
        Quad,
        OneHalf,
        TwoHalf
    }

    public class ObstacleType : MonoBehaviour
	{
        [SerializeField]
        protected bool isRotating = false;

        [SerializeField]
        protected float rotationSpeed = 20;

        [SerializeField]
        protected ObstacleRotationDirection obstacleRotationDirection;

        [SerializeField]
        ObstacleColorType obstacleColorType = ObstacleColorType.None;
        public ObstacleColorType _ObstacleColorType
        {
            get
            {
                return obstacleColorType;
            }
        }

        void Awake()
		{

		}
		
		void Start()
		{
			
		}
		
		public virtual void Update()
		{

            //if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= 6)
            //{
            //    isRotating = true;
            //}
            //else
            //{
            //    isRotating = false;
            //}

            if (isRotating)
            {
                switch (obstacleRotationDirection)
                {
                    case ObstacleRotationDirection.Forward:
                        //transform.Rotate(Vector3.forward * Time.deltaTime, Space.Self);
                        transform.Rotate(Quaternion.Euler(Vector3.forward * Time.deltaTime * rotationSpeed).eulerAngles, Space.Self);
                        break;
                    case ObstacleRotationDirection.Back:
                        //transform.Rotate(Vector3.back * Time.deltaTime, Space.Self);
                        transform.Rotate(Quaternion.Euler(Vector3.back * Time.deltaTime * rotationSpeed).eulerAngles, Space.Self);
                        break;
                }

            }
        }

        public virtual void OnEnable()
        {
            int r = Random.Range(0, 100);

            if (r <= 50)
            {
                obstacleRotationDirection = ObstacleRotationDirection.Forward;
            }
            else if (r > 50)
            {
                obstacleRotationDirection = ObstacleRotationDirection.Back;
            }
        }
    }
}
