using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionPickUp : MonoBehaviour
{
    //Health health;
    //needs to access player code
    public Health player;
    private void  OnTriggerEnter2D(Collider2D collision)

    {
        //if player collides with a health potion

        if (collision.tag == "Player")
        {
            //annd if the players health is less than 10
            if (player.health < 10)
            {


                //if health is less than or equal to 7
                if (player.health <= 7)

                {
                    //add 3 health points
                    player.health += 3;
                }
                //else if player helath is at 8
                else if (player.health == 8)
                {
                    //add  to  health points
                    player.health += 2;
                }
                //else
                else
                {
                    //add one health point
                    player.health += 1;
                }

                //destroy healthpotion instance

                Destroy(collision.gameObject);
            }



        }
    }
}
