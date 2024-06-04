using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] spawners;

    public void SetActiveSpawners(int[] activeIndexes)
    {
        // Deactivate all spawners first
        foreach (var spawner in spawners)
        {
            spawner.SetActive(false);
        }

        // Activate specified spawners
        foreach (var index in activeIndexes)
        {
            if (index >= 0 && index < spawners.Length)
            {
                spawners[index].SetActive(true);
            }
        }
    }
}
