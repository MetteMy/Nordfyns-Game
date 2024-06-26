using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionToCutscene : MonoBehaviour
{
    public CanvasGroup fadePanel; // Reference to the UI panel for fade-in effect
    public float fadeDuration = 1f; // Duration of the fade-in effect
    public string newSceneName; // Name of the scene to transition to

    private bool hasTriggered = false;

    void Update()
    {
        // Check if bossesDefeated is 8 and the event has not been triggered yet
        if (GameManager.Instance.bossesDefeated == 8 && !hasTriggered)
        {
            hasTriggered = true; // Set the trigger flag to true to ensure it only happens once
            StartCoroutine(FadeAndTransition());
        }
    }

    IEnumerator FadeAndTransition()
    {
        float elapsedTime = 0f;

        // Fade-in effect
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadePanel.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        // Load the new scene after the fade-in
        SceneManager.LoadScene(newSceneName);
    }
}
