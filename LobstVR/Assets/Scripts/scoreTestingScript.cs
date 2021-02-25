using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTestingScript : MonoBehaviour
{
    public Text scoreText;
    public float totalScore;
    
    void Start()
    {
        
    }

    void Update()
    {
        //Find the location of the text on the UI and display the current score
        scoreText = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        scoreText.text = "Score: " + Mathf.RoundToInt(score());
    }

    public float score()
    {
        //Gather all the ingredients in the scene and set total score to equal 0
        Cooking[] cooks = GameObject.FindObjectsOfType<Cooking>();
        totalScore = 0;
        //For every ingredient in the scene get the score
        //Take that score and add it together
        for (int i = 0; i < cooks.Length; i++)
        {
            totalScore += cooks[i].score;
        }
        return totalScore;
    }
}
