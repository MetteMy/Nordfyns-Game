using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwave : MonoBehaviour
{

    public float initialRadius = 0.5f;
    public float maxRadius = 4.0f;
    public float growthRate = 0.1f;

    public int segments = 50;
    public string enemyTag;

    private CircleCollider2D circleCollider;
    private LineRenderer lineRenderer;

    void Start()
    {
        
            circleCollider = this.gameObject.GetComponent<CircleCollider2D>();

            circleCollider.radius = initialRadius;


            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.widthMultiplier = 0.05f;
            lineRenderer.positionCount = segments + 1;
            lineRenderer.useWorldSpace = false;
            UpdateLineRenderer(initialRadius);
        
    }


    void Update()
    {
        if (circleCollider.radius < maxRadius)
        {
            circleCollider.radius += growthRate * Time.deltaTime;
             UpdateLineRenderer(circleCollider.radius);
        }
        else
        {
            if (gameObject.name == "shockwave(Clone)")
            {
                //Debug.Log(circleCollider.radius);
                Destroy(this.gameObject);
            }
        }
    }
    void UpdateLineRenderer(float radius)
    {
        float angle = 20f;
        for (int i = 0; i < (segments + 1); i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += (360f / segments);
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
     {

        Debug.Log(this.gameObject.name + " colided with " + other.gameObject.name);
        if (other.CompareTag(enemyTag)) {
            Debug.Log("shockwaves collided");
        
        if (gameObject.name == "shockwave(Clone)" || gameObject.name == "enemyShockwave(Clone)"){
        Destroy(this.gameObject);
        }}}
        //  Debug.Log("shockwave collided with" + other.gameObject.name);
        //   if (other.gameObject.name =="inanimateObject")
        //   {
        //       if (gameObject.name == "shockwave(Clone)")
        //       {
        //           Destroy(this.gameObject);
        //       }
        //  }


     }


