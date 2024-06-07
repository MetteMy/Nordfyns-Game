using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndBossBattle : MonoBehaviour
{
   public GameObject player;
public GameObject playerWeapon;
public GameObject finishSquare;   

public GameObject GoodTeacher; 
public GameObject EvilTeacher; 
public GameObject BossTeacher; 

public string respawnScene;
public string doorID;


public Image uiImage;
public float fadeDuration = 5.0f; // Duration in seconds for the fade

// public int enemyAmount; 
int enemyAmount;
GameObject[] enemies;
// public GameObject enemy;


public Transform playerBattleEndPos;
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
        

        if (player.GetComponent<HealthScript>().health <= 0){
            EndBattleInPlayerDeath();
        }


    }

     public void EndBattle()
     {

        // Debug.Log(".... Ending battle");
        player = GameObject.FindGameObjectWithTag("Player");


        playerWeapon.gameObject.SetActive(false);
        GameManager.Instance.BossDefeated();
        Debug.Log("boss defeated");
        GoodTeacher.SetActive(true);
        if (EvilTeacher != null){
        EvilTeacher.SetActive(false);
        }
    

        
        finishSquare.SetActive(true);
        // StartCoroutine(FadeIn());
        if (uiImage.color.a == 1){
            // Color color = uiImage.color;
            // color.a = 0f;
            // uiImage.color = color;
            finishSquare.SetActive(false);
            AudioManager.Instance.PlayBackgroundMusic();
            
            player.transform.position = playerBattleEndPos.position;
       
            this.gameObject.SetActive(false);
        }
     }

    public void EndBattleInPlayerDeath()
     {

        // Debug.Log(".... Ending battle");
        player = GameObject.FindGameObjectWithTag("Player");


        playerWeapon.gameObject.SetActive(false);
        //GameManager.Instance.BossDefeated();
        //GoodversionOfTeacher.SetActive(true);
        // if (GoodTeacher != null){
        // GoodTeacher.SetActive(false);
        // }
        // if (EvilTeacher != null){
        // EvilTeacher.SetActive(true);
        // }
        // if (BossTeacher != null){
        // BossTeacher.SetActive(false);
        // }

        finishSquare.SetActive(true);
        //finishSquare.GetComponent<ImageAlphaChange>().makeRed();
        
        
        // StartCoroutine(FadeIn());
        if (uiImage.color.a == 1){
            // Color color = uiImage.color;
            // color.a = 0f;
            // uiImage.color = color;
            finishSquare.SetActive(false);
            AudioManager.Instance.PlayBackgroundMusic();
            
            //player.transform.position = playerBattleEndPos.position;
            player.GetComponent<HealthScript>().health = GameManager.Instance.playerHealth;
            Debug.Log("Setting lastDoorID to: " + doorID);
            GameManager.Instance.lastDoorID = doorID;
            SceneManager.LoadScene(respawnScene);

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

