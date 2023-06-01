using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMonitoring : MonoBehaviour
{
    private List<Collider> collidersInTrigger = new List<Collider>();
    public int enemiesInTrigger
    {
        get { return collidersInTrigger.Count; }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !collidersInTrigger.Contains(other))
        {
            collidersInTrigger.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (collidersInTrigger.Contains(other))
        {
            collidersInTrigger.Remove(other);
        }
    }

    private void Update()
    {
        Debug.LogFormat("In {0} are {1} enemies.", this.name, collidersInTrigger.Count);
    }
}
