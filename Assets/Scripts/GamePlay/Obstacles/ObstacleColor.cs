//**************************************************
// ObstacleColor.cs
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
	public class ObstacleColor : ObstacleType
	{

        [SerializeField]
        List<PolygonCollider2D> coliders = new List<PolygonCollider2D>();

        [SerializeField]
        PlayerState randomedPlayerState;
        public PlayerState _RandomedPlayerState
        {
            get
            {
                return randomedPlayerState;
            }
        }

        [SerializeField]
        ColorChanger colorChanger = null;
        public ColorChanger _ColorChanger
        {
            get
            {
                return colorChanger;
            }
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnEnable()
        {
            base.OnEnable();

            foreach(PolygonCollider2D pc in coliders)
            {
                if(pc.enabled == false)

                    pc.enabled = true;
            }

            if (colorChanger.gameObject.activeSelf == false)
                colorChanger.gameObject.SetActive(true);

            SetRandomedPlayerState();
        }

        public int RandomState()
        {
            int r = Random.Range(1, 4);
            return r;
        }

        public void SetRandomedPlayerState()
        {
            int rand = RandomState();

            switch(rand)
            {
                case 1:
                    //GameManager.Instance._Player.SetPlayerState(PlayerState.Blue);
                    randomedPlayerState = PlayerState.Blue;
                    coliders[0].enabled = false;
                    break;
                case 2:
                    //GameManager.Instance._Player.SetPlayerState(PlayerState.Green);
                    randomedPlayerState = PlayerState.Green;
                    coliders[1].enabled = false;
                    break;
                case 3:
                    //GameManager.Instance._Player.SetPlayerState(PlayerState.Pink);
                    randomedPlayerState = PlayerState.Pink;
                    coliders[2].enabled = false;
                    break;
                case 4:
                    //GameManager.Instance._Player.SetPlayerState(PlayerState.Red);
                    randomedPlayerState = PlayerState.Red;
                    coliders[3].enabled = false;
                    break;
            }
        }
    }
}
