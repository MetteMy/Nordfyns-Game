using UnityEngine;

public class BossTeleportScript : MonoBehaviour
{
    public Transform[] teleportPoints;

    public void Teleport()
    {
        if (teleportPoints.Length > 0)
        {
            int index = Random.Range(0, teleportPoints.Length);
            transform.position = teleportPoints[index].position;
            Debug.Log("Succesful teleport!  " + transform.position);
        }
    }

  
}
