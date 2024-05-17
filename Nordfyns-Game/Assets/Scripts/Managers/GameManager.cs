using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Player stats
    public float playerHealth = 100f;
    public float playerSpeed = 5f;
    public float playerDamage = 10f;

    // Boss defeat tracking
    public int bossesDefeated = 0;
    public GameObject[] npcPrefabs; // Array to hold NPC prefabs

    public string lastDoorID;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to update player stats and activate NPCs after a boss is defeated
    public void BossDefeated()
    {
        bossesDefeated++;

        // Increase player stats
        playerHealth += 20f; // Increase health
        playerSpeed += 1f;   // Increase speed
        playerDamage += 5f;  // Increase damage

        // Activate corresponding NPC prefab if exists
        if (bossesDefeated - 1 < npcPrefabs.Length && npcPrefabs[bossesDefeated - 1] != null)
        {
            npcPrefabs[bossesDefeated - 1].SetActive(true);
        }
    }
}
