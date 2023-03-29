using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerMovementScript : MonoBehaviour
{

    public charInfo charInfo;

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float inputX;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int lastDirPressed;

    private Animator _areYouOKAni;

    private SpriteRenderer mySR;
    // Start is called before the first frame update

    //Audio
    public AudioSource source;
    public AudioClip clip;

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
        rb.velocity = new Vector2(inputX * charInfo.speedValue, rb.velocity.y);


        // Jumping
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, charInfo.jumpValue);
            Debug.Log(PlayerPrefs.GetInt("_character_"));
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / charInfo.yDashingVelocity);
        }

        // Switch Sprite
        switchSprite();

        //Dash
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            isDashing = true;
            source.PlayOneShot(clip);
            canDash = false;
            tr.emitting = true;
            dashingDir = new Vector2(inputX, Input.GetAxisRaw("Vertical"));
            Debug.Log(dashingDir);
            if(dashingDir == Vector2.zero)
            {
                if (lastDirPressed == 1)
                {
                    dashingDir = new Vector2(transform.localScale.x, 0);
                }
                else
                {
                    dashingDir = new Vector2(-transform.localScale.x, 0);
                }                                           
            }
            StartCoroutine(stopDashing());
        }

        //_areYouOKAni.SetBool("isDashing", isDashing);

        if (isDashing)
        {
            if (dashingDir == new Vector2(0, 1))
            {
                rb.velocity = dashingDir.normalized * (charInfo.dashingVelocity - charInfo.optimizeYVelocity);
                Debug.Log("work?");
            }

            else
            {
                rb.velocity = dashingDir.normalized * charInfo.dashingVelocity;
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
        yield return new WaitForSeconds(charInfo.dashingTime);
        tr.emitting = false;
        isDashing = false;
    }


    void switchSprite()
    {
        if (inputX == -1 && isGrounded == true)
        {
            mySR.flipX = true;
            lastDirPressed = -1;
        }

        if (inputX == 1 && isGrounded == true)
        {
            mySR.flipX = false;
            lastDirPressed = 1;
        }

        if (inputX == -1 && isDashing == true)
        {
            mySR.flipX = true;
            lastDirPressed = -1;
        }

        if (inputX == 1 && isDashing == true)
        {
            mySR.flipX = false;
            lastDirPressed = 1;
        }
    }

}
