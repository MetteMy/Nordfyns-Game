using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwave : MonoBehaviour
{

    public float initialRadius = 0.5f;
    public float maxRadius = 4.0f;
    public float growthRate = 0.1f; 

    public int segments = 50; 

    private CircleCollider2D circleCollider; 
    private LineRenderer lineRenderer; 

    void Start()
    {

        circleCollider = gameObject.AddComponent<CircleCollider2D>();

        circleCollider.radius = initialRadius; 
    
    
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.05f; 
        lineRenderer.positionCount = segments +1; 
        lineRenderer.useWorldSpace = false; 
        UpdateLineRenderer(initialRadius);
    
    }

 
    void Update()
    {
        if (circleCollider.radius < maxRadius){
            circleCollider.radius += growthRate * Time.deltaTime; 
            UpdateLineRenderer(circleCollider.radius);
        }
    }
    void UpdateLineRenderer(float radius){
        float angle = 20f; 
        for(int i = 0; i<(segments+1); i++){
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius; 

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += (360f /segments);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
    if (other.CompareTag("inanimateObject")) {
        if (gameObject.name == "shockwave(Clone)"){
        Destroy(this.gameObject);
        }
        
        

    }}
}
