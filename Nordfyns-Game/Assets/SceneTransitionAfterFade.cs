using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionAfterFade : MonoBehaviour
{
    public string newSceneName; // Name of the new scene to load
    private EndBossBattle endBossBattle;

    void Start()
    {
        // Get the EndBossBattle component from the same GameObject
        endBossBattle = GetComponent<EndBossBattle>();

        // Check if the EndBossBattle component is attached
        if (endBossBattle == null)
        {
            Debug.LogError("EndBossBattle component not found on the same GameObject!");
        }
    }

    public void StartSceneTransition()
    {
        SceneManager.LoadScene(newSceneName);
    }

 
}
