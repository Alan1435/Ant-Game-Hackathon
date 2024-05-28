using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rbPlayer ;
    private BoxCollider2D colPlayer ;

    [SerializeField] private GameObject SplitAnts;
    [SerializeField] float playerSpeedDef ;
    [SerializeField] float friction ;
    [SerializeField] float maxSpeed ;
    [SerializeField] float jumpHeight ;
    [SerializeField] float maxSlopeAngle ;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject antManager ;
    [SerializeField] private LayerMask platformLayerMask ;
    private SplitAnts splitAnts;
    private List<GameObject> arrayOfAnts;
    private int currentAntIndex = 0;
    public Camera mainCamera;
    public float followSpeed = 2f;
    private GameObject currentAnt;
    private SpriteRenderer spriteRenderer;
    Animator Animator;
    private float lastHorizontalVector;

    public int armySize;


    // Start is called before the first frame update
    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>() ;
        colPlayer = GetComponent<BoxCollider2D>() ;
        Animator = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        splitAnts = SplitAnts.GetComponent<SplitAnts>();
        if (splitAnts != null)
        {
            arrayOfAnts = splitAnts.ArrayOfAnts;
            if (arrayOfAnts.Count > 0) currentAnt = arrayOfAnts[0];
        }

    }

    private void Update()
    {
        Vector2 playerVelocity = rbPlayer.velocity ;

        bool climbable = SlopeClimbable() ;
 
        if (Input.GetButtonDown("Jump") && IsGrounded() && climbable)
        {
            Debug.Log("LEg") ;
            playerVelocity.y = jumpHeight ;
            FindObjectOfType<AudioManager>().Play("jump");
        }

        rbPlayer.velocity = playerVelocity ;
        //rbPlayer.transform.localScale =  new Vector3(0.5f * armySize, 0.5f * armySize, 0.5f * armySize);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 playerVelocity = rbPlayer.velocity ;

           if (antManager.GetComponent<antManagement>().selectedAnt != this.gameObject)
           {
            playerVelocity.x = playerVelocity.x * friction ;
            Animator.SetBool("IsMoving", false);

            return ;
            }

        float xDir = Input.GetAxisRaw("Horizontal") ;

        bool climbable = SlopeClimbable() ;

        //Move player left and right
        if (xDir == 0)
        {
            playerVelocity.x = playerVelocity.x * friction ;
            Animator.SetBool("IsMoving", false);
            FindObjectOfType<AudioManager>().Play("AntWalkingInGrass");
        }
        else
        {
            Animator.SetBool("IsMoving", true);
            
            lastHorizontalVector = playerVelocity.x;
            spriteRenderer.flipX = lastHorizontalVector < 0;
            
            if (playerVelocity.x > 0 && xDir > 0 || playerVelocity.x < 0 && xDir < 0 )
            {
                
                if (climbable)
                {
                    playerVelocity.x = Mathf.Clamp(playerVelocity.x + (xDir * playerSpeedDef), -maxSpeed, maxSpeed) ;
                }
            }
            else
            {
                if (climbable)
                {                
                    playerVelocity.x = Mathf.Clamp((playerVelocity.x * friction) + (xDir * playerSpeedDef), -maxSpeed, maxSpeed) ;
                }
            }
        }

        rbPlayer.velocity = playerVelocity ;
    }

    private bool SlopeClimbable()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, 2.0f, platformLayerMask) ;

        //Debug.DrawLine(transform.position, transform.position + new Vector3(-groundHit.normal.y, groundHit.normal.x, 0.0f), Color.white, 2.0f) ;

        if (groundHit.collider != null)
        {
            if (Mathf.Abs(groundHit.normal.x / (-groundHit.normal.y)) < Mathf.Tan(Mathf.Deg2Rad * maxSlopeAngle))
            {
                return true ;
            }
        }

        return false ;
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.1f ;

        RaycastHit2D raycastHit = Physics2D.BoxCast(colPlayer.bounds.center, colPlayer.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask) ;
        
        if (raycastHit.collider == null)
        {
            return false ;
        }

        if (Mathf.Abs(raycastHit.rigidbody.velocity.y) <= 0.1f)
        {
            return true ;
        } 
        else
        {
            return false ;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathBox")
        {
            
            SwitchToNextAnt();
            FollowCurrentAnt();
            Destroy(gameObject);
            arrayOfAnts.Remove(gameObject);
            Canvas.GetComponent<fractingScript>().denominator -= armySize;
        
        }
    }

    private void SwitchToNextAnt()
    {
        PlayerMovement currentAntMoveScript = arrayOfAnts[currentAntIndex %  arrayOfAnts.Count].GetComponent<PlayerMovement>();
        if (currentAntMoveScript != null)
        {
            currentAntMoveScript.enabled = false;
        }

        // Switch to the next ant
        currentAntIndex = (currentAntIndex + 1) % arrayOfAnts.Count;
        currentAnt = arrayOfAnts[currentAntIndex];
        antManager.GetComponent<antManagement>().selectedAnt = currentAnt ;

        PlayerMovement newCurrentAntMoveScript = arrayOfAnts[currentAntIndex].GetComponent<PlayerMovement>();
        if (newCurrentAntMoveScript != null)
        {
            newCurrentAntMoveScript.enabled = true;
        }

        if (mainCamera != null)
        {
            Vector3 newCameraPosition = arrayOfAnts[currentAntIndex].transform.position;
            newCameraPosition.z = mainCamera.transform.position.z;
            mainCamera.transform.position = newCameraPosition;
        }
    }

    private void FollowCurrentAnt()
    {
        Vector3 targetPosition = currentAnt.transform.position;
        targetPosition.z = mainCamera.transform.position.z;

        // Smoothly move the camera towards the target position
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
