using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossBattle : MonoBehaviour
{
    // Start is called before the first frame update
public GameObject player;
public Transform playerBattleStartPos;

     public void StartBattle()
     {

        Debug.Log(".... starting battle");
        player = GameObject.FindGameObjectWithTag("Player");


        player.transform.position = playerBattleStartPos.position;

     }

    // // Update is called once per frame

}
