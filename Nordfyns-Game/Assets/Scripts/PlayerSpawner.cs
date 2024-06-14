using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Door[] doors;

    private void Start()
    {
        string lastDoorID = GameManager.Instance.lastDoorID;
        Debug.Log("Spawning player at door ID: " + lastDoorID);

        // Find the player GameObject
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player GameObject not found!");
            return;
        }

        foreach (Door door in doors)
        {
            if (door.doorID == lastDoorID)
            {
                Debug.Log("Found matching door: " + door.doorID + ", setting player position.");
                Debug.Log("Current player position: " + player.transform.position);

                // Set player's position to the door's position
                player.transform.position = door.transform.position;

                //Debug.Log("New player position: " + player.transform.position);
                break;
            }
        }
    }
}
