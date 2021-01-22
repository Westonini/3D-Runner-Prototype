using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private RaycastHit hit;
    private bool isTouching = false;
    private int layerMask;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("Tile");
    }

    public bool GetGC()
    {
        return isTouching;
    }

    private void FixedUpdate()
    {
        // Does the ray intersect any objects in the layermask
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.6f, layerMask))
        {
            Debug.Log("Did Hit");
            isTouching = true;
        }
        else
        {
            Debug.Log("Did not Hit");
            isTouching = false;
        }
    }
}
