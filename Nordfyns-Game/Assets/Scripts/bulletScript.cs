using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float force;
    public float bulletLife = 1f; 
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Bullet(Clone)"){
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force; 
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot*90);
        
    }}
    
    private void OnTriggerEnter2D(Collider2D other){
    if (other.CompareTag("inanimateObject") || other.CompareTag("enemy")) {
        if (gameObject.name == "Bullet(Clone)"){
        Destroy(this.gameObject);
        }
        
        

    }}

    // Update is called once per frame
     void Update()
     {
        if (gameObject.name == "Bullet(Clone)"){
        if (timer > bulletLife) Destroy(this.gameObject);
            timer += Time.deltaTime;    
     } }

    
}
