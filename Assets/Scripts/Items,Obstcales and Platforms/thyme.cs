using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thyme : MonoBehaviour
{
    bool collectThyme = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player collides with Thyme

        if (collision.tag == "Player")
        {
            //set collectThyme equal to true
            collectThyme = true;

            //destroy thyme object
            Destroy(collision.gameObject);

        }




    }
}