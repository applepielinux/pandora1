using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour

{
    private float spikeDamageCounter;
    private bool onSpikes = false;

    //needs to access player code
    public Health player;

    [SerializeField] public float damage = 1f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //while the player is touching spikes

        if (collision.tag == "Player")
        {
            //subtracts 1 health from player
            player.health -= 1;

            //set onSpikes equal to true
            onSpikes = true;
        }


    }
    //onTriggerExit2D method
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if the player is no longer touching the spikes
        if (collision.CompareTag("Player"))
        {
            //sets onSpikes to false
            onSpikes = false;
        }
    }

    //update method
    private void Update()
    {
        //if player touches the spikes for more than one second
        if (onSpikes = true && Time.time >= spikeDamageCounter)
        {
            //subtract 1 health persecond
            player.health -= 1;
            //set spikeDamageCOunter equal to damage plus Time.time
            spikeDamageCounter = Time.time + damage;
        }
    }
}




