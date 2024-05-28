using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject antManager ;

    public Transform target;
    public Vector3 offset;

    void Update()
    {
        transform.position = antManager.GetComponent<antManagement>().selectedAnt.transform.position + offset;
        transform.rotation = antManager.GetComponent<antManagement>().selectedAnt.transform.rotation;
    }
}
