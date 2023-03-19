using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerMovementScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float inputX;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private SpriteRenderer mySR;
    // Start is called before the first frame update

    //Dash thing
    [Header ("Dashing")]
    private bool isDashing;
    private bool canDash;
    private Vector2 dashingDir;
    [SerializeField] private float dashingVelocity = 14f;
    [SerializeField] private float dashingTime = 0.5f;
 
    public TrailRenderer tr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        Debug.Log(inputX);
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);


        if (isDashing)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {

            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce / 1.5f;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        
        // Switch Sprite
        switchSprite();

        //Dash
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            isDashing = true;
            canDash = false;
            tr.emitting = true;
            dashingDir = new Vector2(inputX, Input.GetAxisRaw("Vertical"));
            if(dashingDir == Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(stopDashing());
        }

        if (isDashing)
        {
            rb.velocity = dashingDir.normalized * dashingVelocity;
            return;
        }

        if (isGrounded)
        {
            canDash = true;
        }
    }

    private IEnumerator stopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
    }


    void switchSprite()
    {
        if (inputX == -1 && isGrounded == true)
        {
            mySR.flipX = true;
        }

        if (inputX == 1 && isGrounded == true)
        {
            mySR.flipX = false;
        }

    }

}
