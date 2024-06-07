using UnityEngine;

public class CameraController : MonoBehaviour
{
    public string playerTag = "Player"; // Tag for the player
    public string enemyTag = "Enemy";   // Tag for the enemy
    public float minZoom = 5f;          // Minimum zoom level
    public float zoomLimiter = 10f;     // Zoom limiter to adjust the zoom speed

    private Transform playerTransform;
    private Transform enemyTransform;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        FindPlayerAndEnemy();
    }

    void LateUpdate()
    {
        if (playerTransform == null || enemyTransform == null)
        {
            FindPlayerAndEnemy();
            if (playerTransform == null || enemyTransform == null)
                return;
        }

        MoveCamera();
        ZoomCamera();
    }

    void FindPlayerAndEnemy()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        GameObject enemy = GameObject.FindGameObjectWithTag(enemyTag);

        if (player != null)
        {
            playerTransform = player.transform;
        }

        if (enemy != null)
        {
            enemyTransform = enemy.transform;
        }
    }

    void MoveCamera()
    {
        Vector3 centerPoint = GetCenterPoint();
        transform.position = new Vector3(centerPoint.x, centerPoint.y, transform.position.z);
        Debug.Log("Camera Position: " + transform.position);
    }

    void ZoomCamera()
    {
        float greatestDistance = GetGreatestDistance();
        float newZoom = Mathf.Max(greatestDistance);
        cam.orthographicSize = newZoom;
        Debug.Log("Greatest Distance: " + greatestDistance + ", New Zoom: " + newZoom);
    }


    Vector3 GetCenterPoint()
    {
        return (playerTransform.position + enemyTransform.position) / 2f;
    }

    float GetGreatestDistance()
    {
        float distanceX = Mathf.Abs(playerTransform.position.x - enemyTransform.position.x);
        float distanceY = Mathf.Abs(playerTransform.position.y - enemyTransform.position.y);

        return Mathf.Max(distanceX, distanceY);
    }
}
