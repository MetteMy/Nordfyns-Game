using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Player stats
    public float playerHealth;
    public float playerSpeed;
    public float playerDamage;

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
        Debug.Log("boss defeated.....");
        bossesDefeated++;

        // Increase player stats
       
        // Activate corresponding NPC prefab if exists
        if (bossesDefeated - 1 < npcPrefabs.Length && npcPrefabs[bossesDefeated - 1] != null)
        {
            npcPrefabs[bossesDefeated - 1].SetActive(true);
        }
    }
}
