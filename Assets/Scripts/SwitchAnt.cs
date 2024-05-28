using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnt : MonoBehaviour
{
    [SerializeField] private GameObject SplitAnts;
    [SerializeField] GameObject antManager ;
    private SplitAnts splitAnts;
    private List<GameObject> arrayOfAnts;
    private int currentAntIndex = 0;
    public Camera mainCamera;
    public float followSpeed = 2f;
    private GameObject currentAnt;

    void Start()
    {
        splitAnts = SplitAnts.GetComponent<SplitAnts>();
        if (splitAnts != null)
        {
            arrayOfAnts = splitAnts.ArrayOfAnts;
            if (arrayOfAnts.Count > 0) currentAnt = arrayOfAnts[0];
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchToNextAnt();
        }
        if (currentAnt != null)
        {
            FollowCurrentAnt();
        }
    }

    private void SwitchToNextAnt()
    {
        PlayerMovement currentAntMoveScript = arrayOfAnts[currentAntIndex % arrayOfAnts.Count].GetComponent<PlayerMovement>();
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
