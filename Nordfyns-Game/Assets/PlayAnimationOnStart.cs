using UnityEngine;

public class PlayAnimationOnStart : MonoBehaviour
{
    public Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();

        if (anim != null)
        {
            // Assuming the default animation clip is the first one
            if (anim.clip != null)
            {
                anim.Play();
            }
            else
            {
                Debug.LogError("Default animation clip is not assigned.");
            }
        }
        else
        {
            Debug.LogError("No Animation component found on this GameObject.");
        }
    }
}
