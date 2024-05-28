using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnt : MonoBehaviour
{
    // Animator animator;
    // private PlayerMovement otherScript;
    // public GameObject playerMovementHolder; 
    // // Start is called before the first frame update
    // void Start()
    // {
        
    //     animator = gameObject.GetComponent<Animator>();
    //     otherScript = playerMovementHolder.GetComponent<PlayerMovement>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Ant")
        {
            Destroy(collision.gameObject);
        }
    }


    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ant"))
    //     {
            
    //         Animator antAnimator = collision.gameObject.GetComponent<Animator>();
    //         Rigidbody2D antRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
    //         antAnimator.SetBool("IsDead", true);
    //         antRigidbody.velocity = Vector2.zero;
    //         antRigidbody.gravityScale = 0;

    //         // Disable the Collider2D of the collided object
    //         Collider2D antCollider = collision.gameObject.GetComponent<Collider2D>();
    //         if (antCollider != null)
    //         {
    //             antCollider.enabled = false;
    //         }
    //         if (otherScript != null)
    //         {
    //             otherScript.enabled = false;
    //         }
    //     }
    // }
}
