using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameController gameController;

    Vector3 enemyMovement;

    bool movingRight = true;

    float Speed = 3;

    public Transform groundDetection;

    RaycastHit2D groundInformation;

    float distance = 2;

    Animator animator;


    void Start()
    {
        gameController = GameObject.Find("GlobalScripts").GetComponent<GameController>();

        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (gameObject.CompareTag("CrabPatrolEnemy"))
        {
            EnemyCrabMovement();
        }
        

    }


    void EnemyCrabMovement()
    {
        gameObject.transform.Translate(Vector2.right * Speed * Time.deltaTime);

        groundInformation = Physics2D.Raycast(groundDetection.position,Vector2.down,distance);
        
        animator.SetBool("IsWalking", true);

        if (groundInformation.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false;

            }else
            {
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

       if (other.gameObject.CompareTag("Player"))
       {
            gameController.DecrementLives();

            AudioController.Instance.PlaySoundEffect(AudioController.SoundEffect.Damage);   
       }

    }
}
