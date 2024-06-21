using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public GameObject[] prefabs; // Array to hold prefabs to be activated based on bosses defeated
    public GameObject evilBoss;

    void Start()
    {
        InitializeScene();
    }

    void InitializeScene()
    {
        // Get the number of bosses defeated from the GameManager
        int bossesDefeated = GameManager.Instance.bossesDefeated;

        // Iterate through the prefabs array
        for (int i = 0; i < prefabs.Length; i++)
        {
            // Activate the prefab if the number of bosses defeated is greater than or equal to the current index + 1
            if (i < bossesDefeated && prefabs[i] != null)
            {
                prefabs[i].SetActive(true);
                evilBoss.SetActive(false);
            }
            else if (prefabs[i] != null)
            {
                prefabs[i].SetActive(false);
                evilBoss.SetActive(true);
            }
        }
    }
}
