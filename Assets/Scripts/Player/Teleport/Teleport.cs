using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private int minEnemiesNumber = 100;
    [SerializeField] private GameObject playerTransform;

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGrounded)
        {
            TeleportPlayer(ChooseTeleportPoint());
        }
    }

    private Transform ChooseTeleportPoint()
    {
        List<Transform> teleportPoints = new List<Transform>();

        for (int i = 0; i < 4; i++)
        {
            int enemiesInCurrentTrigger = this.transform.GetChild(i).gameObject.GetComponent<PointMonitoring>().enemiesInTrigger;
            
            if (enemiesInCurrentTrigger < minEnemiesNumber)
            {
                teleportPoints.Add(this.transform.GetChild(i));
                minEnemiesNumber = enemiesInCurrentTrigger;
            }
            else if (enemiesInCurrentTrigger == minEnemiesNumber)
            {
                teleportPoints.Add(this.transform.GetChild(i));
            }
        }

        // if was more than one equal number of enemies
        if (teleportPoints.Count > 1)
        {
            return teleportPoints[Random.Range(0, teleportPoints.Count)].transform;
        }
        else
        {
            return teleportPoints[0].transform;
        }
    }

    private void TeleportPlayer(Transform teleportPointTransform)
    {
        playerTransform.transform.position = teleportPointTransform.position;
        playerTransform.transform.rotation = teleportPointTransform.rotation;
    }
}
