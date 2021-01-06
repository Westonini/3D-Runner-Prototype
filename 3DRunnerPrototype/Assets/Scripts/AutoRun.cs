using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Autorun forward
public class AutoRun : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody rb;

    private bool isRunning;

    //GETTERS
    public bool GetToggleRun()
    {
        return isRunning;
    }

    public virtual void ToggleRun(bool toggle)
    {
        isRunning = toggle;

        if (!GetToggleRun())
            rb.velocity = Vector3.zero;
    }

    void Start()
    {
        ToggleRun(true);
    }

    protected virtual void FixedUpdate()
    {
        if (GetToggleRun())
        {
            rb.velocity = new Vector3(0, 0, movementSpeed * Time.deltaTime); //Constantly move forward depending on movementSpeed and time.
        }
    }
}
