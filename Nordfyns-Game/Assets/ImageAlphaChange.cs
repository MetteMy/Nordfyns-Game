using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageAlphaChange : MonoBehaviour
{
    // Start is called before the first frame update
    // private Image uiImage;
    
    // void Start()
    // {
    //     uiImage = GetComponent<Image>();
    //     Debug.Log("Imageeeee" + uiImage.color);
    //     Color color = uiImage.color;
    //     color.a = 0; 
    //     for (float i = 0; i < 100; i++)
    //     {
    //         color.a = i/100;
    //         Debug.Log(color.a  + "   " + i);
    //         uiImage.color = color;
            
    //     }
    // }

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
