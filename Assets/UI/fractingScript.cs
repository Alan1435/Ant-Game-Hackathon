using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fractingScript : MonoBehaviour
{
    [SerializeField] GameObject antManager;
    [SerializeField] GameObject Warning;
    public TMP_Text text;
    public int denominator;
    public int numerator;
    // Start is called before the first frame update
    void Start()
    {
        antManager = GameObject.Find("AntManager");
        text.text = "Hello World";
        denominator = antManager.GetComponent<antManagement>().totalAnts;
    }

    // Update is called once per frame
    void Update()
    {
        numerator = antManager.GetComponent<antManagement>().selectedAnt.GetComponent<PlayerMovement>().armySize;

        text.text = numerator + "/" + denominator + " ants";
        if (denominator == 0){
            Warning.SetActive(true);
        }
    }
}
