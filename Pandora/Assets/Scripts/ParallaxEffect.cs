/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    //this script was going to be used if there were multiple backgrounds, but there are not. the most rear image would move faster than the most frontward image as the character moved

    public Camera cam;
   // [SerializeField] private   
    public Transform target;  //following player

    Vector2 startingPosition; //

    float startingZ; // z value



    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; 
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart / parallaxFactor;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
} **/
