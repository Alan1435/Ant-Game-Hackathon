using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadController : MonoBehaviour
{

    private int x;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ant")
        {
            x++;
            transform.SetParent(collision.transform);
            if(x == 1){
                FindObjectOfType<AudioManager>().Play("crumbNoise");
            }
            
        }
    }

}