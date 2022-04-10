using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerAnim : NetworkBehaviour
{
    private Animator anim;
    private Player p;

    void Awake()
    {
        anim = GetComponent<Animator>();
        p = GetComponent<Player>();
    }

    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        MovementAnimation();
        JumpAnimation();
        WallSlideAnimation();
    }

    void MovementAnimation()
    {
        anim.SetFloat("Speed", Mathf.Abs(p.rb.velocity.x));
    }

    void JumpAnimation()
    {
        if(p.isWallSliding)
        {
            anim.SetBool("hasJumped", false);
            return;
        }
        anim.SetBool("hasJumped", !p.isRay);
    }

    void WallSlideAnimation()
    {
        anim.SetBool("isWallSliding", p.isWallSliding);
    }
}
