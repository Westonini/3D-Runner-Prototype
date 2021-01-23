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

    private void SetGC(bool TF) //Sets the ground check
    {
        if (TF && !GetGC())
        {
            Debug.Log("Grounded");
            isTouching = true;
        }
        else if (!TF && GetGC())
        {
            Debug.Log("Not Grounded");
            isTouching = false;
        }
    }

    public bool GetGC() //Gets the ground check
    {
        return isTouching;
    }

    private void FixedUpdate()
    {
        // Does the ray intersect any objects in the layermask
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 5f, layerMask))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            SetGC(true);
        }
        else
        {
            SetGC(false);
        }
    }
}
