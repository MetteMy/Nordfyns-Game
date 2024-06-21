using UnityEngine;

public class CameraController : MonoBehaviour
{
    public string playerTag = "Player"; // Tag for the player
    public string enemyTag = "enemy";   // Tag for the enemy
    public float minZoom = 5f;          // Minimum zoom level
    public float maxZoom = 20f;         // Maximum zoom level
    public float zoomLimiter = 10f;     // Zoom limiter to adjust the zoom speed
    public float m_DampTime = 2f;       // Approximate time for the camera to refocus.
    public float m_ScreenEdgeBuffer = 4f; // Space between the top/bottom most target and the screen edge.

    private Transform playerTransform;
    private Transform enemyTransform;
    private Camera cam;
    private float m_ZoomSpeed;          // Reference speed for the smooth damping of the orthographic size.
    private Vector3 m_MoveVelocity;     // Reference velocity for the smooth damping of the position.
    private Vector3 m_DesiredPosition;  // The position the camera is moving towards.

    void Start()
    {
        cam = GetComponent<Camera>();
        
    }

    void Update()
    {
        FindPlayerAndEnemy();
        if (playerTransform == null)
        {
            FindPlayerAndEnemy();
            if (playerTransform == null)
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
        else
        {
            enemyTransform = null;
        }
    }

    void MoveCamera()
    {
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f); // Ensure the Z position is fixed
    }

    void FindAveragePosition()
    {
        if (enemyTransform != null)
        {
            Vector3 averagePos = new Vector3();
            int numTargets = 0;

            if (playerTransform != null)
            {
                averagePos += playerTransform.position;
                numTargets++;
            }

            if (enemyTransform != null)
            {
                averagePos += enemyTransform.position;
                numTargets++;
            }

            if (numTargets > 0)
            {
                averagePos /= numTargets;
            }

            m_DesiredPosition = averagePos;
            m_DesiredPosition.z = transform.position.z; // Maintain the original Z position
        }
        else if (playerTransform != null)
        {
            m_DesiredPosition = playerTransform.position;
            m_DesiredPosition.z = transform.position.z; // Maintain the original Z position
        }
    }

    void ZoomCamera()
    {
        float requiredSize = FindRequiredSize();
        requiredSize = Mathf.Clamp(requiredSize, minZoom, maxZoom); // Clamp the zoom level between minZoom and maxZoom
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }

    float FindRequiredSize()
    {
        if (enemyTransform != null)
        {
            Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);
            float size = 0f;

            if (playerTransform != null)
            {
                Vector3 targetLocalPos = transform.InverseTransformPoint(playerTransform.position);
                Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));
                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / cam.aspect);
            }

            if (enemyTransform != null)
            {
                Vector3 targetLocalPos = transform.InverseTransformPoint(enemyTransform.position);
                Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));
                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / cam.aspect);
            }

            size += m_ScreenEdgeBuffer;
            size = Mathf.Max(size, minZoom);

            return size;
        }
        else if (playerTransform != null)
        {
            return minZoom; // If there's no enemy, just use the minimum zoom
        }

        return minZoom;
    }
}
