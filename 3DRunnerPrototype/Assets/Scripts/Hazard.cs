using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerEvents PE = collision.gameObject.GetComponent<PlayerEvents>();
            PE.CallPlayerDeath();
        }
    }
}
