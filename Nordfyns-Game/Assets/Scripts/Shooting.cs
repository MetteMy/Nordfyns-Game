using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject prefab;
    public Transform bulletTransform;
    private Camera mainCam;
    private Vector3 mousePos;
    public AudioClip shootingSound;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);

        if (Input.GetMouseButtonDown(0))
        {

            GameObject bullet = Instantiate(prefab, bulletTransform.position, Quaternion.identity);


        }
    }

    void PlayShootingSound()
    {
        if (shootingSound != null)
        {
            AudioManager.Instance.PlaySound(shootingSound);
        }
    }

}
