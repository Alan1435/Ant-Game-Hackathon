using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerButton1 : MonoBehaviour
{

    public bool clickedCornerButton1;
    public float detectionRadius = 5f;
    public int requiredNumbersOfAnts;

    [SerializeField] GameObject antManager ;

    GameObject antBeingPlayed ;

    void Start()
    {
        clickedCornerButton1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //Camera.main.ScreenPointToRay, Physics2D.GetRayIntersection

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, 1 << LayerMask.NameToLayer("Buttons"));
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Clicked");

                antBeingPlayed = antManager.GetComponent<antManagement>().selectedAnt ;

                if ((antBeingPlayed.transform.position - gameObject.transform.position).magnitude > detectionRadius)
                {
                    return ;
                }

                if (antBeingPlayed.GetComponent<PlayerMovement>().armySize >= requiredNumbersOfAnts)
                {
                    Debug.Log("Clicked & set");
                    clickedCornerButton1 = true;
                    FindObjectOfType<AudioManager>().Play("bridge");
                }
                
            }
        }
            
    }
}
