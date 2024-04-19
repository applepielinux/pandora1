using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    //pixel per sec
    public Vector3 moveSpeed = new Vector3(0, 75, 0);
    public float timeToFade = 1f;

    private float timeElapsed = 0f;
    private Color startColor;

    //Rect tarnsnsform since UI element
    RectTransform textTransform;
    TextMeshProUGUI textMeshPro;

    private Color color;

    private void Awake()
    {
        textTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        startColor = textMeshPro.color;
    }
    private void Update()
    {
        //apply percentage of moveSpeed to pos on every second
        //time. helps move consistent amount
       textTransform.position += moveSpeed * Time.deltaTime;

        timeElapsed += Time.deltaTime;

        if(timeElapsed < timeToFade)
        {
            float fadeAlpha = startColor.a *(1 - (timeElapsed / timeToFade));
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, fadeAlpha);
        } else
        {
            Destroy(gameObject);
        }
    }


}
