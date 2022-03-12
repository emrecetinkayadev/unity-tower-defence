using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator animator;
    bool check = true;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile" && check)
        {
            animator.SetBool("isRunning", true);
            check = false;
        }


        if (collision.GetComponent<Defender>())
        {
            Debug.Log("Emre");

            if (collision.gameObject.tag == "Gravestone")
            {
                animator.SetTrigger("isJumping");
            }
            else
            {
                Debug.Log("Emre1");
                GetComponent<Attacker>().Attack(collision.gameObject);
            }
        }

    }   
    
}
