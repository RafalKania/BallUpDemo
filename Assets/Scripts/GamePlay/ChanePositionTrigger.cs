//**************************************************
// ChanePositionTrigger.cs
//
// Code Soldiers 2019
//
// Author: Rafał Kania
// Creation Date: <Date>
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
	public class ChanePositionTrigger : MonoBehaviour
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

        public void MoveParentUp()
        {
            parent.transform.position = new Vector3(0, parent.transform.position.y + 80, 0);
            StartCoroutine(ChangeObstacle());
        }

        IEnumerator ChangeObstacle()
        {
            parent._CurrentObstacle.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);

            parent.SetCurrentObstacle();
            parent._CurrentObstacle.gameObject.SetActive(true);
        }
	}
}
