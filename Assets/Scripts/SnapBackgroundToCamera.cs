using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBackgroundToCamera : MonoBehaviour
{
    [SerializeField] GameObject background ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (background != null)
        {
            background.transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f) ;
        }
    }
}
