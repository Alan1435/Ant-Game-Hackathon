using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class SplitNumberChange : MonoBehaviour
{
    [SerializeField] Button splitChange ;
    [SerializeField] int changeAmount ;
    [SerializeField] Button splitButton ;

    // Start is called before the first frame update
    void Start()
    {
        splitChange.onClick.AddListener(delegate {changeSplitAmount();}) ;
        Debug.Log("Yellow");
    }

    void changeSplitAmount()
    {
        splitButton.GetComponent<SplitAnts>().splitNumber += changeAmount ;
        Debug.Log("buttonHit");
    }
}
