using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsmusMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float pos;
    private int r;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Move() {
        r = Random.Range(-6,6);
        if (r % 2 != 0){
            Debug.Log("converting");
            r += 1;
            }
            Debug.Log(this.transform.position.x);
        
        if (this.transform.position.x >= 32 && this.transform.position.x <= 126){
            
            Debug.Log("r "+ r);
            transform.Translate(r,0,0);
            
        }
        else {
            this.transform.position = new Vector3(76,this.transform.position.y,0);
        }
        
        // if (this.transform.position.x <= 126){
        // //transform.Translate(-random,0,0);
     
        // }
        // transform.Translate(random,0,0);


        //transform.position = new Vector2(0,44);
        // pos = transform.position.x;
        // pos += 44;
        // transform.position.x = pos;
}


}
