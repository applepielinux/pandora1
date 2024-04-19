using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour
{
    private PlayerManager p;
    private LevelManager lm;
    // Start is called before the first frame update
    void Start()
    {
        lm = GameObject.FindGameObjectWithTag("lm").GetComponent<LevelManager>();
        // sets player position to currentCheckPoiint Activated
        transform.position = lm.currentCheckPointActivated;
    }

    //
   // if(playerHealth == 0 && playerLives >=1)
      //  {
         //respawn at last activated checkpoint
      //  }
        
}