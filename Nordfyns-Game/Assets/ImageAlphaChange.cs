using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageAlphaChange : MonoBehaviour
{
 

    private Image uiImage;
    public float fadeDuration = 5.0f; // Duration in seconds for the fade

    void Start()
    {
        uiImage = GetComponent<Image>();
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Color color = uiImage.color;
        float currentTime = 0f;

        // Initial opacity
        color.a = 0f;
        uiImage.color = color;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            color.a = Mathf.Clamp01(currentTime / fadeDuration);
            uiImage.color = color;
            yield return null;
        }

        // Ensure the final alpha is set to 1
        color.a = 1f;
        uiImage.color = color;
    }


    public void makeRed(){
        
        uiImage = GetComponent<Image>();
        Color color = uiImage.color;
        color = new Color32(255,0,0,0);
        Debug.Log(color);
        uiImage.color = color;
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
