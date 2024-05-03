using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject prefab;
    public Transform bulletTransform;
    private Camera mainCam;
    private Vector3 mousePos;
       
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 rotation = mousePos - transform.position;

        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rotz);

        if (Input.GetKeyDown(KeyCode.Space)){
           
            GameObject bullet = Instantiate(prefab, bulletTransform.position, Quaternion.identity);
            
       }}

}
