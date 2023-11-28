//**************************************************
// Obstacle2StarsdMoved.cs
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
	public class Obstacle2StarsdMoved : ObstacleType
	{
        [SerializeField]
        float moveSpeed = 10;

        [SerializeField]
        Transform leftStar = null;

        [SerializeField]
        Transform rightStar = null;

        [SerializeField]
        Transform LPoint = null;

        [SerializeField]
        Transform RPoint = null;

        [SerializeField]
        bool isMovingRight = false;
		
		public override void Update()
		{
            var step = moveSpeed * Time.deltaTime;

            if (leftStar.position.x <= LPoint.position.x)
            {
                isMovingRight = true;
            }
            else if (leftStar.position.x >= RPoint.position.x)
            {
                isMovingRight = false;
            }

            if (isMovingRight == true)
            {
                leftStar.Rotate(Vector3.back * Time.deltaTime * 50, Space.Self);
                leftStar.position += new Vector3(1 * Time.deltaTime * moveSpeed, 0, 0);//Vector3.MoveTowards(transform.position, RPoint.position, step);
            }
            else
            {
                leftStar.Rotate(Vector3.forward * Time.deltaTime * 50, Space.Self);
                leftStar.position -= new Vector3(1 * Time.deltaTime * moveSpeed, 0, 0); //Vector3.MoveTowards(transform.position, LPoint.position, step);
            }

            //if (rightStar.position == LPoint.position)
            //{
            //    rightStar.position = Vector3.MoveTowards(transform.position, RPoint.position, step);
            //}
            //else if (rightStar.position == RPoint.position)
            //{
            //    rightStar.position = Vector3.MoveTowards(transform.position, LPoint.position, step);
            //}

        }

        public override void OnEnable()
        {
            leftStar.position = LPoint.position;
            rightStar.position = RPoint.position;
        }
    }
}
