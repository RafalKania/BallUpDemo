//**************************************************
// Obstacle2RingAround.cs
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
	public class Obstacle2RingAround : ObstacleType
	{

        [SerializeField]
        Transform leftRing = null;

        [SerializeField]
        Transform rightRing = null;

        public override void Update()
        {
            if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= 15)
            {
                isRotating = true;
            }
            else
            {
                isRotating = false;
            }

            if (isRotating)
            {
                //leftRing.Rotate(Vector3.forward, Space.Self);
                //rightRing.Rotate(Vector3.back, Space.Self);

                leftRing.Rotate(Quaternion.Euler(Vector3.back * Time.deltaTime * rotationSpeed).eulerAngles, Space.Self);
                rightRing.Rotate(Quaternion.Euler(Vector3.forward * Time.deltaTime * rotationSpeed).eulerAngles, Space.Self);
            }
        }
    }
}
