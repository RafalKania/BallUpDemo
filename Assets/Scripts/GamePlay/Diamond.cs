//**************************************************
// Diamond.cs
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
	public class Diamond : MonoBehaviour
	{
        [SerializeField]
        ObstacleElement parent = null;
        public ObstacleElement _Parent
        {
            get
            {
                return parent;
            }
        }

        [SerializeField]
        Animator animator = null;

        private void OnEnable()
        {
            //StartCoroutine(DiamondScale());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator DiamondScale()
        {
            while (true)
            {
                animator.SetTrigger("Scale");
                yield return new WaitForSeconds(3f);
                
            }
        }
    }
}
