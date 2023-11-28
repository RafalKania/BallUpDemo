//**************************************************
// Obstacle2Desk2RotatedUp.cs
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
	public class Obstacle2Desk2RotatedUp : ObstacleType
	{
        [SerializeField]
        Transform leftDesk = null;

        [SerializeField]
        Transform rightDesk = null;

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
                leftDesk.Rotate(Quaternion.Euler(Vector3.forward* Time.deltaTime * rotationSpeed).eulerAngles, Space.Self);
                rightDesk.Rotate(Quaternion.Euler(Vector3.back * Time.deltaTime * rotationSpeed).eulerAngles, Space.Self);
            }
        }
    }
}
