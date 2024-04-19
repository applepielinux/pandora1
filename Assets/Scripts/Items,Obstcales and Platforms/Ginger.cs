using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ginger : MonoBehaviour
{
    public bool collectGinger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player collides with Ginger

        if (collision.tag == "Player")
        {
            //set collectGinger equal to true
            collectGinger = true;

            //destroy Ginger object
            Destroy(collision.gameObject);
        }
    }
}