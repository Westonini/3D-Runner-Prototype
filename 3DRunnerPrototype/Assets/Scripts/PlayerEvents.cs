using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerKilled;

    public delegate void PlayerJump();
    public static event PlayerJump OnPlayerJumped;

    public void CallPlayerDeath()
    {
        if (OnPlayerKilled != null)
            OnPlayerKilled();
    }

    public void CallPlayerJump()
    {
        if (OnPlayerJumped != null)
            OnPlayerJumped();
    }
}
