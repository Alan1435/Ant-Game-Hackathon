using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiPush : MonoBehaviour
{
    [SerializeField] GameObject antManager ;
    [SerializeField] int pushableThreshold ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (antManager.GetComponent<antManagement>().selectedAnt.GetComponent<PlayerMovement>().armySize >= pushableThreshold)
        {
            gameObject.GetComponent<Rigidbody2D>().mass = 5 ;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().mass = 500 ;
        }
    }
}