using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    public GameObject logo; // Assign your logo GameObject in the inspector
    public string mainMenuSceneName; // Name of your main menu scene

    private SpriteRenderer logoSpriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component from the logo GameObject
        if (logo != null)
        {
            logoSpriteRenderer = logo.GetComponent<SpriteRenderer>();
        }
    }

    // Method to be called when the camera pan starts
    public void StartCameraPan()
    {
        // Here you can add any logic you want to execute when the camera pan starts
        Debug.Log("Camera pan started");
    }

    // Method to be called to fade in the logo
    public void FadeInLogo()
    {
        if (logoSpriteRenderer != null)
        {
            StartCoroutine(FadeInCoroutine());
        }
    }

    private IEnumerator FadeInCoroutine()
    {
        Color color = logoSpriteRenderer.color;
        color.a = 0;
        logoSpriteRenderer.color = color;

        float duration = 1.0f; // Duration of the fade
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / duration);
            logoSpriteRenderer.color = color;
            yield return null;
        }

        color.a = 1;
        logoSpriteRenderer.color = color;
    }

    // Method to be called at the end of the camera pan to load the main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}