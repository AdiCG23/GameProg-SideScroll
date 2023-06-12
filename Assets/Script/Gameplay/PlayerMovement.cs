using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;

    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    #region AnimationHandler
    private Animator animator;
    private void PlayWalk(float spd)
    {
        animator.SetFloat("Speed", spd);
    }
    private void PlayJump()
    {
        animator.SetTrigger("triggerJump");
    }
    #endregion

    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < -0.1)
        {
            spriteRenderer.flipX = false;
        }
        else if(horizontalInput > 0.1)
        {
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        SpriteFlip(horizontalInput);
        Debug.Log(horizontalInput);
        PlayWalk(Mathf.Abs(horizontalInput));
        
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            PlayJump();
        }
    }
}