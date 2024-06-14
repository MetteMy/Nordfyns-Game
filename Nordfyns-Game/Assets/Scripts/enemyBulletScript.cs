using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 playerPos;
    private Rigidbody2D rb;
    public float force;
    public Transform playerTransform;


    void Start()
    {
        
        if (gameObject.name == "enemyBullet(Clone)" || gameObject.name =="PieChartBullet(Clone)"|| gameObject.name =="songBookBullet(Clone)"){
            Debug.Log("enemybullet");
            
            playerPos = playerTransform.position;
            
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            rb = GetComponent<Rigidbody2D>();
       
        
            Vector3 direction = playerPos - transform.position;
            Vector3 rotation = transform.position - playerPos;

            rb.velocity = new Vector2(direction.x, direction.y).normalized * force; 
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0,rot*90);
        
    }}
    
    private void OnTriggerEnter2D(Collider2D other){
    if (other.CompareTag("inanimateObject") || other.CompareTag("Player")) {
        if (gameObject.name == "enemyBullet(Clone)"){
        Destroy(this.gameObject);
        }
        
        

    }}
}
