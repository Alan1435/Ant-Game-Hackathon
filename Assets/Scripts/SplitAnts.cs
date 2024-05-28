using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class SplitAnts : MonoBehaviour
{
    [SerializeField] GameObject antManager ;
    [SerializeField] Button splitButton ;
    [SerializeField] GameObject antSplit ;
    public List<GameObject> ArrayOfAnts;

    public int splitNumber = 1 ;

    public int requiredNumbersOfAntsToSplit = 1;

    GameObject selectedAnt ;

    // Start is called before the first frame update
    void Start()
    {
        selectedAnt = antManager.GetComponent<antManagement>().selectedAnt ;
        splitButton.onClick.AddListener(delegate {splitAnts(selectedAnt) ;}) ;
    }

    void Update(){
        selectedAnt = antManager.GetComponent<antManagement>().selectedAnt ;
    }

    public void splitAnts (GameObject ants)
    {
        if(selectedAnt.GetComponent<PlayerMovement>().armySize <= requiredNumbersOfAntsToSplit){
            return;
        }

        GameObject newAntsOne = Instantiate(ants, new Vector3(ants.transform.position.x, ants.transform.position.y + 0.5f, ants.transform.position.z), ants.transform.rotation);
        newAntsOne.GetComponent<PlayerMovement>().armySize = splitNumber;
        antManager.GetComponent<antManagement>().selectedAnt = newAntsOne;

        ArrayOfAnts.Add(newAntsOne);

        GameObject newAntsTwo = Instantiate(ants, ants.transform.position, ants.transform.rotation);
        newAntsTwo.GetComponent<PlayerMovement>().armySize = ants.GetComponent<PlayerMovement>().armySize - splitNumber;

        ArrayOfAnts.Add(newAntsTwo);

        PlayerMovement currentAntMoveScript = newAntsTwo.GetComponent<PlayerMovement>();
        if (currentAntMoveScript != null)
        {
            currentAntMoveScript.enabled = false;
        }

        Destroy(ants);
        ArrayOfAnts.Remove(ants);

        Debug.Log(splitNumber);

        selectedAnt = antManager.GetComponent<antManagement>().selectedAnt ;

        antSplit.SetActive(false);
    }

    // public void splitAnts(GameObject ants)
    // {
    //     if (ants == null) return;

    //     PlayerMovement antsPlayerMovement = ants.GetComponent<PlayerMovement>();
    //     if (antsPlayerMovement == null) return;

    //     GameObject newAntsOne = Instantiate(ants, ants.transform.position, ants.transform.rotation);
    //     PlayerMovement newAntsOneMovement = newAntsOne.GetComponent<PlayerMovement>();
    //     if (newAntsOneMovement != null)
    //     {
    //         newAntsOneMovement.armySize = splitNumber;
    //         ArrayOfAnts.Add(newAntsOne);
    //     }

    //     GameObject newAntsTwo = Instantiate(ants, ants.transform.position, ants.transform.rotation);
    //     PlayerMovement newAntsTwoMovement = newAntsTwo.GetComponent<PlayerMovement>();
    //     if (newAntsTwoMovement != null)
    //     {
    //         newAntsTwoMovement.armySize = antsPlayerMovement.armySize - splitNumber;
    //         ArrayOfAnts.Add(newAntsTwo);
    //     }

    //     // Remove the original ant from the list before destroying it
    //     if (ArrayOfAnts.Contains(ants))
    //     {
    //         ArrayOfAnts.Remove(ants);
    //     }
        
    //     Destroy(ants);

    //     antManager.GetComponent<antManagement>().selectedAnt = newAntsOne;
    //     selectedAnt = newAntsOne;
    //     antSplit.SetActive(false);
    // }


}
