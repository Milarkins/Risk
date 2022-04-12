using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Player : NetworkBehaviour
{
    public float movementSpeed, movement, jumpForce, groundCheckDistance, wallJumpTime, wallSlideSpeed, wallDistance;
    private float jumpTime;
    public bool isRay, isWall, isWallSliding, faceR;
    public LayerMask groundLayer;
    public Rigidbody2D rb;

    private Material playerMaterialClone;
    [SyncVar(hook = nameof(OnColorChanged))]
    public Color playerColor = Color.white;
    private SetColor sc;

    void OnColorChanged(Color _Old, Color _New)
    {
        playerMaterialClone = new Material(GetComponent<Renderer>().material);
        playerMaterialClone.color = _New;
        GetComponent<Renderer>().material = playerMaterialClone;
    }
    
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        Jump();
    }

    void FixedUpdate()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        if(faceR)
        {
            isWall = (Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, groundLayer));
        } else
        {
            isWall = (Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, groundLayer));
        }
        WallJump();
        Movement();
    }

    void Movement()
    {
        movement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movement * movementSpeed, rb.velocity.y);
        if(!isWallSliding)
        {
            if(movement<0 && faceR) { Flip(); }
            if(movement>0 && !faceR) { Flip(); }
        }
    }

    void WallJump()
    {
        if(isWall && !isRay && movement != 0)
        {
            isWallSliding = true;
            jumpTime = Time.time + wallJumpTime;
        } else if(jumpTime < Time.time)
        {
            isWallSliding = false;
        }
        if(isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlideSpeed, float.MaxValue));
        }
    }

    void Jump()
    {
        isRay = (Physics2D.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer));
        if(!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
        if(isRay)
        {

            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        if(isWall && !isRay)
        {
            rb.AddForce(transform.up * (jumpForce /1.2f), ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        faceR = !faceR;
        transform.Rotate(0f, 180f, 0f);
    }

    void Start()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        sc = FindObjectOfType<SetColor>();
        Color color = sc.colorlist[sc.colorNum];
        CmdSetupPlayer(color);
    }

    [Command]
    public void CmdSetupPlayer(Color _col)
    {
        playerColor = _col;
    }
}
