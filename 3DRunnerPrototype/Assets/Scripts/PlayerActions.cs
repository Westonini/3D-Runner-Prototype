using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public int jumpForce;
    public GroundCheck gc;

    private Rigidbody rb;
    private Animator anim;
    private AutoRun_Player autoRun;
    private AutoRun camAutoRun;
    private PlayerEvents PE;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        autoRun = gameObject.GetComponent<AutoRun_Player>();
        camAutoRun = Camera.main.gameObject.GetComponent<AutoRun>();
        PE = gameObject.GetComponent<PlayerEvents>();
    }

    void OnEnable()
    {
        PlayerEvents.OnPlayerKilled += Death;
        PlayerEvents.OnPlayerJumped += Jump;
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerKilled -= Death;
        PlayerEvents.OnPlayerJumped -= Jump;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && gc.GetGC() && autoRun.GetToggleRun())
            PE.CallPlayerJump();
    }

    public void Jump()
    {
            rb.AddForce((Vector3.up * jumpForce), ForceMode.Force);
    }

    public void Death()
    {
        autoRun.ToggleRun(false);
        camAutoRun.ToggleRun(false);
    }
}
