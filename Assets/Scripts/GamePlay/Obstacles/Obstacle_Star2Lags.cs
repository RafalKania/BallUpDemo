//**************************************************
// Obstacle_Star2Lags.cs
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
	public class Obstacle_Star2Lags : ObstacleType
	{
        [SerializeField]
        Transform leftLag = null;

        [SerializeField]
        Transform rightLag = null;

        public override void Update()
        {
            if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= 6)
            {
                isRotating = true;
            }
            else
            {
                isRotating = false;
            }

            if (isRotating)
            {
                //leftLag.Rotate(Vector3.forward, Space.Self);
                //rightLag.Rotate(Vector3.back, Space.Self);

                leftLag.Rotate(Quaternion.Euler(Vector3.back * Time.deltaTime * rotationSpeed).eulerAngles, Space.Self);
                rightLag.Rotate(Quaternion.Euler(Vector3.forward * Time.deltaTime * rotationSpeed).eulerAngles, Space.Self);
            }
        }
    }
}
