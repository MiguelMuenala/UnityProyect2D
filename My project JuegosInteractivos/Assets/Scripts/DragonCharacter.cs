using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedWalk = 3.0f;
    public float speedJump = 6.0f;
    Rigidbody2D dragonChar;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRen;
    public Animator animator;

    public GameObject textGameObject;// Desactivar el texto

    void Start()
    {
        dragonChar = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right")) {
            dragonChar.velocity = new Vector2(speedWalk, dragonChar.velocity.y);
            spriteRen.flipX = false; //flipX es un booleano que indica si el sprite debe voltearse horizontalmente
            animator.SetBool("Run", true);
            animator.SetBool("Flykick", false);
            if (Input.GetKey("space"))
            {
                animator.SetBool("Flykick", true);
                dragonChar.velocity = new Vector2(speedWalk + 2.0f, dragonChar.velocity.y);
            }
        }
        else
        {
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                dragonChar.velocity = new Vector2(-speedWalk, dragonChar.velocity.y);
                spriteRen.flipX = true;//voltear
                animator.SetBool("Run", true);
                animator.SetBool("Flykick", false);
                if (Input.GetKey("space"))
                {
                    animator.SetBool("Flykick", true);
                    dragonChar.velocity = new Vector2(-speedWalk-2.0f, dragonChar.velocity.y);
                }
            }
            else
            {
                dragonChar.velocity = new Vector2(0, dragonChar.velocity.y);
                animator.SetBool("Run", false);
            }
        }
        /*if (Input.GetKey("space"))
        {
            animator.SetBool("Flykick", true);
            dragonChar.velocity = new Vector2(speedWalk + 2.0f, dragonChar.velocity.y);
        }

        if (Input.GetKey("w")) JumStrike  Flykick
        {
            dragonChar.velocity = new Vector2(0, speedJump);
        }*/
        if (Input.GetKey("w") && bock.isGround)
        {
            dragonChar.velocity = new Vector2(dragonChar.velocity.x, speedJump);

        }
        if(bock.isGround == false)
        {
            animator.SetBool("JumStrike", true);
            animator.SetBool("Run", false);
        }
        if (bock.isGround == true)
        {
            animator.SetBool("JumStrike", false);
        }

        if (betterJump)
        {
            if (dragonChar.velocity.y < 0)
            {
                dragonChar.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier)*Time.deltaTime;
            }
            if (dragonChar.velocity.y > 0 && !Input.GetKey("w"))
            {
                dragonChar.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;

            }
        }

        if (Input.GetKey("r"))//Desactivvar el texto
        {
            textGameObject.SetActive(false);
        }
        else
        {
            if (Input.GetKey("t"))
            {
                textGameObject.SetActive(true);
            }
        }
        
         
        

    }
}
