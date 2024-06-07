using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingShield : MonoBehaviour
{
    public GameObject shieldPrefab; // The prefab to be used as shield objects
    public int shieldCount = 8; // The number of shield objects
    public float radius = 2f; // The radius of the circular path
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second
    public bool rotateClockwise = true; // Boolean to change rotation direction

    private List<GameObject> shieldObjects = new List<GameObject>();
    private GameObject shieldParent; // Parent GameObject for the rotating shields

    void Start()
    {
        CreateShieldParent();
        CreateShield();
    }

    void Update()
    {
        RotateShield();
    }

    void CreateShieldParent()
    {
        shieldParent = new GameObject("ShieldParent");
        shieldParent.transform.position = transform.position;
        shieldParent.transform.parent = transform;
    }

    void CreateShield()
    {
        for (int i = 0; i < shieldCount; i++)
        {
            float angle = i * Mathf.PI * 2 / shieldCount;
            Vector3 position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            GameObject shieldObject = Instantiate(shieldPrefab, shieldParent.transform.position + position, Quaternion.identity, shieldParent.transform);
            shieldObject.GetComponent<Collider2D>().isTrigger = true; // Ensure it has a collider
            shieldObject.tag = "Shield";
            shieldObjects.Add(shieldObject);
        }
    }

    void RotateShield()
    {
        float rotationDirection = rotateClockwise ? -1 : 1;
        shieldParent.transform.Rotate(0, 0, rotationDirection * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            Destroy(collision.gameObject); // Destroy the bullet on collision
            Debug.Log("blocked");
        }
    }
}
