using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antManagement : MonoBehaviour
{
    [SerializeField] GameObject startingAnt;
    public int totalAnts;
    [SerializeField] GameObject antSplit ;

    public GameObject selectedAnt;
    // Start is called before the first frame update
    void Start()
    {
        startingAnt.GetComponent<PlayerMovement>().armySize = totalAnts;
        selectedAnt = startingAnt;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            antSplit.SetActive(true) ;
        }

        
    }
}
