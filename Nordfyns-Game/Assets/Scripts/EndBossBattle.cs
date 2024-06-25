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

    public Transform playerBattleEndPos;

    private bool battleEnded = false; // Flag to check if battle has ended


    void Start()
    {
        if (uiImage == null)
        {
            uiImage = GetComponent<Image>();
        }

     
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        enemyAmount = enemies.Length;

        if (enemyAmount <= 0 && !battleEnded)
        {
            EndBattle();
        }

        if (player.GetComponent<HealthScript>().health <= 0 && !battleEnded)
        {
            EndBattleInPlayerDeath();
        }
    }

    public void EndBattle()
    {
        battleEnded = true; // Set flag to true

        playerWeapon.SetActive(false);
        GameManager.Instance.BossDefeated();
        Debug.Log("Boss defeated");
        GoodTeacher.SetActive(true);

        if (EvilTeacher != null)
        {
            EvilTeacher.SetActive(false);
        }

        finishSquare.SetActive(true);

        StartCoroutine(HandleEndBattle());
        
    }

    public void EndBattleInPlayerDeath()
    {
        battleEnded = true; // Set flag to true

        playerWeapon.SetActive(false);
        finishSquare.SetActive(true);

        StartCoroutine(HandlePlayerDeath());
    }

    private IEnumerator HandleEndBattle()
    {
        yield return StartCoroutine(FadeIn(false));

        finishSquare.SetActive(false);
        AudioManager.Instance.PlayBackgroundMusic();

      

        player.transform.position = playerBattleEndPos.position;
        
        gameObject.SetActive(false);
        
    }

    private IEnumerator HandlePlayerDeath()
    {
        yield return StartCoroutine(FadeIn(true));

        finishSquare.SetActive(false);
        AudioManager.Instance.PlayBackgroundMusic();

        player.GetComponent<HealthScript>().health = GameManager.Instance.playerHealth;
        Debug.Log("Setting lastDoorID to: " + doorID);
        GameManager.Instance.lastDoorID = doorID;
        SceneManager.LoadScene(respawnScene);

        gameObject.SetActive(false);
    }

    public IEnumerator FadeIn(bool isDead)
    {
        Color color = uiImage.color;
        if (isDead == true){
            color = new Color(255,0,0,0);
        }
        else {
            color = new Color(255,255,255,0);
        }
        float currentTime = 0f;

        // Initial opacity
        color.a = 0f;
        uiImage.color = color;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            color.a = Mathf.Clamp01(currentTime / fadeDuration);
            uiImage.color = color;
            yield return null;
        }

        // Ensure the final alpha is set to 1
        color.a = 1f;
        uiImage.color = color;
    }
}
