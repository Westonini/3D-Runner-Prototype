using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player override for Autorun
public class AutoRun_Player : AutoRun
{
    public int strafeSpeed;
    public int downwardForce;
    public GroundCheck gc;

    private PlayerAnimations anim;
    private float horizontalInput;

    private void Awake()
    {
        anim = gameObject.GetComponent<PlayerAnimations>();
    }

    public override void ToggleRun(bool toggle)
    {
        base.ToggleRun(toggle);

        anim.ToggleRunningAnim();
    }

    void Start()
    {
        ToggleRun(true);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    protected override void FixedUpdate()
    {
        if (GetToggleRun())
        {
            rb.velocity = new Vector3(horizontalInput * strafeSpeed * Time.deltaTime, rb.velocity.y, movementSpeed * Time.deltaTime);
        }

        //Gravity
        rb.AddForce(Vector3.down * downwardForce, ForceMode.Acceleration);
    }
}
