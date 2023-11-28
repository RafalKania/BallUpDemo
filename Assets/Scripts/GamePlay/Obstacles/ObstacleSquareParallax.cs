//**************************************************
// ObstacleSquareparallax.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 25 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
	public class ObstacleSquareParallax : ObstacleType
	{

        [SerializeField]
        Transform[] parallaxElements;

        [SerializeField]
        float parallaxSpeed = 1f;
		
		void Awake()
		{

		}
		
		void Start()
		{
			
		}
		
		public override void Update()
		{
			foreach(Transform t in parallaxElements)
            {
                t.position += new Vector3(1 * Time.deltaTime * parallaxSpeed, 0, 0);

                if (t.position.x >= 9.8f)
                    t.position = new Vector3(-13.2f, t.position.y, t.position.z);
            }
		}
	}
}
