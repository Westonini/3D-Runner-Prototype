using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;
    private AutoRun_Player autoRunner;

    private void Awake()
    {
        autoRunner = gameObject.GetComponent<AutoRun_Player>();
    }

    void OnEnable()
    {
        PlayerEvents.OnPlayerKilled += ToggleDeathAnim;
        PlayerEvents.OnPlayerKilled += InterruptJumpAnim;

        PlayerEvents.OnPlayerJumped += ToggleJumpAnim;
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerKilled -= ToggleDeathAnim;
        PlayerEvents.OnPlayerKilled -= InterruptJumpAnim;

        PlayerEvents.OnPlayerJumped -= ToggleJumpAnim;
    }

    public void ToggleRunningAnim()
    {
        if (autoRunner.GetToggleRun())
            anim.SetBool("Run", true);  
        else
            anim.SetBool("Run", false); 
    }

    public void ToggleDeathAnim()
    {
        anim.SetBool("Die", true);
    }

    public void ToggleJumpAnim()
    {
        anim.SetBool("Jump", true);

        StartCoroutine("JumpAnimFinish");
    }

    public void InterruptJumpAnim()
    {
        anim.SetBool("Jump", false);

        StopCoroutine("JumpAnimFinish");
    }

    IEnumerator JumpAnimFinish()
    {
        yield return new WaitForSeconds(0.575f);
        anim.SetBool("Jump", false);
    }
}
