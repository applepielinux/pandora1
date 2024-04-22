using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{

    //declare levelsUnlocked
    int levelsUnlocked = 1;

    //declare checkpointsUnlocked
    int checkpointsUnlocked = 0;

    // Index of the last checkpoint activated
    public int currentCheckpointIndex = 0;

    internal void SaveCheckpoint(object lastCheckpointIndex)
    {
        throw new NotImplementedException();
    }


    //holds the transform value
    public Vector3 currentCheckPointActivated;

    //declare boolean levelWon and set to false
    bool levelWon = false;

    //need fixing a placeholder value
    public Vector3 playerStartPos;

    // Holds the transform values of all checkpoints
    public List<Vector3> checkpoints ;

    //need to add  transform values of each checkpoint to the checkpoints  list in the order they are unloocked in the game. Must set up levels to do so.
  


    //levelWon function
    public void levelIsWon()
    {
        //set levelWon to true
        levelWon = true;
    }
    //start function
    void Start()
    {
        //sets levelsUnlocked to integer stored in Player preferences. If no int is stored the value is 1
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        //check last checkpoint unlocked.If no integer is store set equal to 0
        checkpointsUnlocked = PlayerPrefs.GetInt("checkpointsUnlocked", 0);

        //calls levelLoad function to load the level indicated by levelsUnlocked 
        levelLoad();

        checkpointLoad();


    }


    //loadLevel function
    public void loadLevel(int levelNum)
    {
        //load the level
        SceneManager.LoadScene(levelNum);
    }
    //update function
    void Update()
    {
        //if win condition is met
        if (levelWon)
        {
            // Reset checkpoint to 0
            checkpointsUnlocked = 0;

            // Unlock next level if not the final level
            if (levelsUnlocked < 9)
            {
                //increment level
                levelsUnlocked++;

                //save new value to levelsUnlocked
                PlayerPrefs.SetInt("levelsUnlocked", levelsUnlocked);
            }
            else
            {
                // Load credits scene if it's the final level
                SceneManager.LoadScene(10);
            }

            // Reset level won
            levelWon = false;
        }
    }



    //level load function
    public void levelLoad()
    {
        //load last level unlocked
        SceneManager.LoadScene(levelsUnlocked);
    }


    //SaveCheckpoint Method
    public void SaveCheckpoint(int checkpointIndex)
    {
        //if checkpoint index is greated then 0 and less than checkpoints.Count
        if (checkpointIndex >= 0 && checkpointIndex < checkpoints.Count)
        {
            //set  currentCheckPointActivated  equal checkpoint Index os checkpoints list
            currentCheckPointActivated = checkpoints[checkpointIndex];

            //set currentCheckpointIndex equal to  checkpointIndex

            currentCheckpointIndex = checkpointIndex;

            //set player prefs checkpoints unlocked to lastCHeckpointIndex
            PlayerPrefs.SetInt("checkpointsUnlocked", currentCheckpointIndex);
        }
    }
    //checkpointLoad method
    public void checkpointLoad()
    {
        //if the lastCheckpointIndex is greater than or equal to 0 and its less than  checkpoints.Count  
        if (currentCheckpointIndex >= 0 && currentCheckpointIndex < checkpoints.Count)
        {
            // Move player to the position of the current checkpoint activated
            playerStartPos = checkpoints[currentCheckpointIndex];
        }
        else
        {
            
            // otheerwise set player at the beginning of the level
       //   playerStartPos = checkpoints[0];
        }
    }

}
