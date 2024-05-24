
using UnityEngine;

public class BossMultiplyScript : MonoBehaviour
{
    public Transform[] teleportPoints;
    public GameObject enemyPrefab;

    public bool hasMultiplied =false;

    private GameObject enemyclone;


    public void Multiply()
    {


        Debug.Log("tried multiplying");
        if (teleportPoints.Length > 0 && hasMultiplied == false)
        {
            for (int i = 0; i < teleportPoints.Length; i++)
            {
                if (this.transform.position != teleportPoints[i].position){
                //int index = Random.Range(0, teleportPoints.Length);
                //transform.position = teleportPoints[i].position;
                Debug.Log("enemy pos: " + teleportPoints[i].position);
                enemyclone = Instantiate(enemyPrefab, teleportPoints[i].position, transform.rotation);
                enemyclone.SetActive(true);
                }

            }
            Debug.Log("Succesful multiply!");
            hasMultiplied = true;
        }
    }

}
