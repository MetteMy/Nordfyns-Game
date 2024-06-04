using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossBattle : MonoBehaviour
{
    // Start is called before the first frame update
public GameObject player;
public GameObject playerWeapon;

public GameObject enemy;

public GameObject Bossbattle;


public Transform playerBattleStartPos;

     public void StartBattle()
     {

        Debug.Log(".... starting battle");

        AudioManager.Instance.PlayBossMusic();
        player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = playerBattleStartPos.position;

        playerWeapon.gameObject.SetActive(true);

        enemy.gameObject.SetActive(true);

        Bossbattle.gameObject.SetActive(true);
     }

    // // Update is called once per frame

}
