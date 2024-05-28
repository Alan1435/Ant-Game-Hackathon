using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    [SerializeField] Sprite pressed ;
    [SerializeField] Sprite unPressed ;

    [SerializeField] GameObject beam ;

    private void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag != "Ant")
        {
            return ;
        }

        Debug.Log("Peepee") ;

        if (collider.transform.position.y < gameObject.transform.position.y + 0.0f)
        {
            return ;
        }

        if (Mathf.Abs(collider.transform.position.x - gameObject.transform.position.x) > 0.95f)
        {
            return ;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = pressed ;

        beam.layer = 7 ;
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag != "Ant")
        {
            return ;
        }

        if (beam == null)
        {
            return ;
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = unPressed ;

        beam.layer = 8 ;
    }
}
