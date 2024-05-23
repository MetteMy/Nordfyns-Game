using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //public Slider healthSlider;
    public float health;
  
    
    //private float maxHealth = health; 
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //health = 30.0f;
        
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }

        if (health <= 20)
        {
            animator.SetBool("IsEnraged", true);
        }
        
        //UpdateHealthUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("something collided with enemy");
        
        if (other.CompareTag("bullet"))
        {
            health -= 1.0f;
            Debug.Log("enemy health: " + health);
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
