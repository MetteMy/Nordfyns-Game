using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
   public string sceneToLoad; 


   private void OnTriggerEnter2D(Collider2D other){
   Debug.Log("scenetransition");

   if (other.CompareTag("Player")){
      
      UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
      
   }

   }
}
