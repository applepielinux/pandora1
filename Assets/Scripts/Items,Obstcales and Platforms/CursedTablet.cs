using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedTablet : MonoBehaviour
{
    public bool collectTablet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player collides with cursedTablet

        if (collision.tag == "Player")
        {
            //set collectTablet equal to true
            collectTablet = true;

            //destroy cursedTablet object
            Destroy(collision.gameObject);
        }
    }
}
