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

    private Animator _areYouOKAni;

    private SpriteRenderer mySR;
    // Start is called before the first frame update

    //Dash thing
    [Header ("Dashing")]
    private bool isDashing;
    private bool canDash = true;
    private Vector2 dashingDir;
    [SerializeField] private float dashingVelocity = 10f;
    [SerializeField] private float dashingTime = 0.5f;
    [SerializeField] private float yVelJumpReleaseMod = 2f;


    public TrailRenderer tr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySR = GetComponent<SpriteRenderer>();
        _areYouOKAni = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //been walking since day one i was born while eating corn cornered by aliens 
        inputX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);


        // Jumping
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / yVelJumpReleaseMod);
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
            Debug.Log(dashingDir);
            if(dashingDir == Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(stopDashing());
        }

        _areYouOKAni.SetBool("isDashing", isDashing);

        if (isDashing)
        {
            if (dashingDir == new Vector2(0, 1))
            {
                rb.velocity = dashingDir.normalized * (dashingVelocity - 2);
                Debug.Log("work?");
            }

            else
            {
                rb.velocity = dashingDir.normalized * dashingVelocity;
            }

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

        if (inputX == -1 && isDashing == true)
        {
            mySR.flipX = true;
        }

        if (inputX == 1 && isDashing == true)
        {
            mySR.flipX = false;
        }


    }

}
