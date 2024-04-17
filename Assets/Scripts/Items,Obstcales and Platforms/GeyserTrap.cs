using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeyserTrap : MonoBehaviour
{
    private float geyserDamageCounter;
    private bool onGeyser = false;
    [SerializeField] public float damage = 1f;
    //needs to access player code
    public Health player;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //while the player is touching Geyser Spray

        if (collision.tag == "Player")
        {
            //subtracts 2 health from player
            player.health -= 2;

            //set onGeyser is equal to true
            onGeyser = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if the player is no longer touching the geyser spray
        if (collision.CompareTag("Player"))
        {
            //sets onGeyser to false
            onGeyser = false;
        }
    }

    //update method
    private void Update()
    {
        //if player touches the geyser spary for more than one second
        if (onGeyser = true && Time.time >= geyserDamageCounter)
        {
            //subtract 2 health per second
            player.health -= 2;

            //set geyserDamageCounter equal to damage plus Time.time
            geyserDamageCounter = Time.time + damage;
        }
    }
}

