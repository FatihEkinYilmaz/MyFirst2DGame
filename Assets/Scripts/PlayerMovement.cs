using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 10f;
    [SerializeField] private LayerMask jumpableGround;


    private enum MovementState {idle,running, jumping, falling }
    private MovementState state = MovementState.idle;

    [SerializeField] private AudioSource jumpSound;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(dirX * moveSpeed,playerRb.velocity.y);

        if (Input.GetKey(KeyCode.Space)&& IsGround())
        {
            jumpSound.Play();
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);

        }

        UpdateAnimationState();
       
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (playerRb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (playerRb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
