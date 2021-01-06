using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isTouching = false;
    List<GameObject> groundObjects = new List<GameObject>();

    public bool GetGC()
    {
        return isTouching;
    }

    //Ground Check
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Tile"))
        {
            if (!groundObjects.Contains(other.gameObject))
            {
                groundObjects.Add(other.gameObject);
                isTouching = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Tile"))
        {
            groundObjects.Remove(other.gameObject);

            if (groundObjects.Count == 0)
                isTouching = false;
        }
    }
}
