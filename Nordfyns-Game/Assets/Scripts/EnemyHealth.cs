using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //public Slider healthSlider;
    public float health;
    public float maxHealth;
    
    public Image healthBar;

    // public GameObject BossBattle;
    
    //private float maxHealth = health; 
   // Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        
        //animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // BossBattle = GetComponent<EndBossBattle>();
        if (health <= 0)
        {
            // BossBattle.enemyAmount -= 1;
            Destroy(gameObject);
        }

        if (health <= 20f)
        {
            //animator.SetBool("IsEnraged", true);
        }
        healthBar.fillAmount = Mathf.Clamp(health/maxHealth, 0, 1); 
        healthBar.color = Color.Lerp(Color.red, Color.green, health / maxHealth); 
        //UpdateHealthUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("something collided with enemy");
        
        if (other.CompareTag("bullet"))
        {
            health -= 1.0f;
            // Debug.Log("enemy health: " + health);
        }
    }

    //     void UpdateHealthUI()
    // {
    //     if (healthSlider != null)
    //     {
    //         healthSlider.value = (float) health / maxHealth;
    //     }
    // }


}
