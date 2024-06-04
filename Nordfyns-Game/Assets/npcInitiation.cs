using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcInitiation : MonoBehaviour
{
    public int bossDefeatedRequired;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Ensure the GameObject is initially inactive
        
    }

    // Start is called before the first frame update
    void Start()
    {
        CheckBossesDefeated();
    }

    void CheckBossesDefeated()
    {
        int bossesDefeated = GameManager.Instance.bossesDefeated;

        if (bossesDefeated < bossDefeatedRequired)
        {
            gameObject.SetActive(false);
        }
    }
}
