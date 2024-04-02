using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float force;
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
        // new WaitForSeconds(5);
        // this.gameObject.SetActive(false);
        // Invoke("Deactivate", 2f);
    }}
    
    private void OnTriggerEnter2D(Collider2D other){
    if (other.CompareTag("inanimateObject")) {
        if (gameObject.name == "Bullet(Clone)"){
        Destroy(this.gameObject);
        }
        
        // Debug.Log("before"+ this.gameObject);
        // this.gameObject.SetActive(false);
        //Deactivate();
        //Debug.Log("collided");

    }}

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deactivate(){
        gameObject.SetActive(false);
        Debug.Log("deactivated");
    }
}
