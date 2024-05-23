// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Healthbar : MonoBehaviour
// {
//     // Start is called before the first frame update

//     Vector3 localScale; 
//     void Start()
//     {

//         maxHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>();
//         localScale -= transform.localScale;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         //Debug.Log(GameManager.Instance.playerHealth);
//         localScale.x -= GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>().health;
//         transform.localScale -= localScale; 
//     }
// }
