using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    private LevelManager lm;
    //start method
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
    }
    void onTriggerEnter2D(Collider2D other)
    {

        //if player collides with checkpoint
        if (other.CompareTag("Player"))


        {
            //sets SavelastCheckPointActivated to current unlocked chechpoint
            lm.SaveCheckpoint(lm.currentCheckpointIndex);
        }


    }


}