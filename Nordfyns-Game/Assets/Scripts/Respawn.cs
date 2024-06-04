using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private int bossDefeatedRequired;

    // Start is called before the first frame update
    void Start()
    {
        {
            int bossesDefeated = GameManager.Instance.bossesDefeated;

            if (bossesDefeated < bossDefeatedRequired)
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
