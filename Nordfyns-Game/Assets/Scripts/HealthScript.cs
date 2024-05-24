using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        health = GameManager.Instance.playerHealth;
        maxHealth = health;
    
    }

    // Update is called once per frame
    void Update()
    {
    
      if (health<=0)
        {
            Destroy(gameObject);
        }
        healthBar.fillAmount = Mathf.Clamp(health/maxHealth, 0, 1);
        healthBar.color = Color.Lerp(Color.red, Color.green, health / maxHealth); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("Noget har ramt trigger");
if (other.CompareTag("enemybullet"))
        {
            health -= 1.0f;
            Debug.Log("player health: " + health);
        }
    }

}
