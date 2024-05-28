using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillTrigger : MonoBehaviour
{
    public GameObject NextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breadcrumb")
        {

            NextLevel.SetActive(true);
        }
    }

}
