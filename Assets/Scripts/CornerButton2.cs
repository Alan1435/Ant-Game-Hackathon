using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerButton2 : MonoBehaviour
{
    [SerializeField] GameObject antManager ;
    [SerializeField] int bridgeLength ;
    [SerializeField] GameObject Canvas;


    public CornerButton1 cornerButton1;
    public GameObject bridge;
    void Start()
    {
        cornerButton1 = FindObjectOfType<CornerButton1>();

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && (cornerButton1.clickedCornerButton1)){
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, 1 << LayerMask.NameToLayer("Buttons"));
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                bridge.GetComponent<Renderer>().enabled = true;
                bridge.GetComponent<Collider2D>().enabled = true;


                    antManager.GetComponent<antManagement>().selectedAnt.GetComponent<PlayerMovement>().armySize -= bridgeLength ;
                    Canvas.GetComponent<fractingScript>().denominator -= bridgeLength;
                    Debug.Log(antManager.GetComponent<antManagement>().selectedAnt.GetComponent<PlayerMovement>().armySize) ;
            }
            
        }
    }
}
