using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotionPickUp : MonoBehaviour
{



    //needs to access player code
    public Mana player;
    private void nTriggerEnter2D(Collider2D collision)
    {
        //if player collides with a mana potion

        if (collision.tag == "Player")
        {
            //annd if the players mana is less than 10
            if (player.mana < 10)
            {


                //if mana is less than or equal to 7
                if (player.mana <= 7)

                {
                    //add 3 mana points
                    player.mana += 3;
                }
                //else if player mana is at 8
                else if (player.mana == 8)
                {
                    //add  two  mana points
                    player.mana += 2;
                }
                //else
                else
                {
                    //add one mana point
                    player.mana += 1;
                }

                //destroy manapotion instance

                Destroy(collision.gameObject);
            }



        }
    }
}
