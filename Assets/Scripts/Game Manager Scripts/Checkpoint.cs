using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    private LevelManager levelManager;
    //start method
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    void onTriggerEnter2D(Collider2D other)
    {

        //if player collides with checkpoint
        if (other.CompareTag("Player"))


        {
            //sets SavelastCheckPointActivated to current unlocked chechpoint
            levelManager.SaveCheckpoint(levelManager.currentCheckpointIndex);
        }


    }


}