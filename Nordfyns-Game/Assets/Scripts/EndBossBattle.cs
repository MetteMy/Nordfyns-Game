using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndBossBattle : MonoBehaviour
{
   public GameObject player;
public GameObject playerWeapon;
public GameObject finishSquare;   


public Image uiImage;
public float fadeDuration = 5.0f; // Duration in seconds for the fade

// public int enemyAmount; 
int enemyAmount;
GameObject[] enemies;
// public GameObject enemy;


public Transform playerBattleStartPos;
void Start()
    {
        uiImage = uiImage.GetComponent<Image>();
        
    }
    void Update(){
        
        

        enemies = GameObject.FindGameObjectsWithTag("enemy");
        enemyAmount = enemies.Length;
        
        
        if (enemyAmount <= 0){
            EndBattle();
        }
        


    }

     public void EndBattle()
     {

        Debug.Log(".... Ending battle");
        player = GameObject.FindGameObjectWithTag("Player");


        playerWeapon.gameObject.SetActive(false);
        GameManager.Instance.BossDefeated();

        
        finishSquare.SetActive(true);
        // StartCoroutine(FadeIn());
        if (uiImage.color.a == 1){
            // Color color = uiImage.color;
            // color.a = 0f;
            // uiImage.color = color;
            finishSquare.SetActive(false);
            AudioManager.Instance.PlayBackgroundMusic();
            
        player.transform.position = playerBattleStartPos.position;
       

        this.gameObject.SetActive(false);
        }
     }


    

    // private IEnumerator FadeIn()
    // {
    //     Color color = uiImage.color;
    //     float currentTime = 0f;

    //     // Initial opacity
    //     color.a = 0f;
    //     uiImage.color = color;

    //     while (currentTime < fadeDuration)
    //     {
    //         currentTime += Time.deltaTime;
    //         color.a = Mathf.Clamp01(currentTime / fadeDuration);
    //         uiImage.color = color;
    //         yield return null;
    //     }

    //     // Ensure the final alpha is set to 1
    //     // 
        
    //     color.a = 1f;
    //     uiImage.color = color;
        
        
    // }

  

}

