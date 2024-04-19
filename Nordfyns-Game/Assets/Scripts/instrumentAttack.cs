using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrumentAttack : MonoBehaviour
{
    bool canInteract = false; 
    public GameObject prefab; 
    public Transform bulletTransform;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract == true &&  Input.GetKeyDown(KeyCode.E)){
            Debug.Log("MUUUSIIIC!!!"); 
            canInteract = false; 
            GameObject shockwave = Instantiate(prefab, bulletTransform.position, Quaternion.identity);

           
        }




    }

    void OnTriggerEnter2D(Collider2D other) { 

        if (other.CompareTag("Player")){

            canInteract = true; 
            Debug.Log("true");
            

        }
        Debug.Log("ENTERED");
    }


}


