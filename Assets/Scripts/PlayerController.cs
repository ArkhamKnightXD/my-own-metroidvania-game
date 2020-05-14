using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float lastHorizontalAxis;

    float lastVerticalAxis;

    Animator animator;

    float speedX = 6f;

    Vector3 deltaPosition;

    Vector3 characterScale;

    bool jumping = false;

    float jumpTime;
    
    float maxJumpingTime = 0.95f;

    bool canJump;

    float horizontalAxis;

    float verticalAxis;

    Rigidbody2D _rigidbody;

    GameController gameController;

    public GameObject BulletPrefab;

   
    void Start()
    {
        gameController = GameObject.Find("GlobalScripts").GetComponent<GameController>();

        animator = GetComponent<Animator>();

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");

        verticalAxis = Input.GetAxis("Vertical");


        deltaPosition = new Vector3(horizontalAxis, 0) * speedX * Time.deltaTime;
        
        gameObject.transform.Translate(deltaPosition);

        Jump();

        PlayerMovementAnimation();

        RotateCharacter();

        animator.SetBool("IsShooting", Input.GetButton("Fire1"));

    }

// Intentar mejor la funcion de disparo, 
    void SimpleShoot()
    {
        Instantiate(BulletPrefab,transform.position,Quaternion.identity);
    }


    void PlayerMovementAnimation()
    {
        if (lastHorizontalAxis != horizontalAxis)
        {
            lastHorizontalAxis = horizontalAxis;

            animator.SetFloat("HorizontalAxis", lastHorizontalAxis);            
        }


        if (lastVerticalAxis != verticalAxis)
        {
            lastVerticalAxis = verticalAxis;

            animator.SetFloat("VerticalAxis", lastVerticalAxis);            
        }
    }


    void RotateCharacter()
    {

       characterScale = transform.localScale;

        if (Input.GetKey("left"))
        {
            characterScale.x = -1;

        }

        if (Input.GetKey("right"))
        {
            characterScale.x = 1;

        }

        transform.localScale = characterScale;
    }


    void Jump()
    {
        if (Input.GetButton("Jump") && !jumping)
        {
            jumpTime = 0f;

            _rigidbody.AddForce(transform.up * 300f);

            animator.SetBool("Jump", true);

            jumping = true;

            AudioController.Instance.PlaySoundEffect(AudioController.SoundEffect.Jump);
        }

        if (jumping)
        {
            jumpTime += Time.deltaTime;

            if (jumpTime > maxJumpingTime)
            {
                jumping = false;

                animator.SetBool("Jump", false);

            }   
        }
        
    }
}
