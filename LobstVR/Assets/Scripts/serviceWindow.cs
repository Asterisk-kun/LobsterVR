using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class serviceWindow : MonoBehaviour
{
    public float finalScore;
    public Text resultText;
    private float maxScore = 105f;
    //moduleMenu scoreChoice;
    
    void Start()
    {
        finalScore = 0;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the plate has hit the service window
        if (other.gameObject.tag == "Plate")
        {
            //Reset all values
            finalScore = 0;
            //Check the plate to ignore the initial children and see if we have anything on the plate
            //If we have children then we get the total of scores off all the children
            if (other.gameObject.transform.childCount > 2)
            {
                for (int i = 2; i < other.gameObject.transform.childCount; i++)
                {
                    finalScore += other.gameObject.transform.GetChild(i).GetComponent<Cooking>().score;
                }
            }
            /*if (scoreChoice.moduleChoice == 0)
                maxScore = 53f;
            if (scoreChoice.moduleChoice == 1)
                maxScore = 420f;*/
            //Set the percentage for accuracy then display results
            float percentage = finalScore / maxScore;
            if (percentage >= 0.70f)
            {
                resultText.text = "Result: Pass\nScore: " + Mathf.RoundToInt(finalScore) + "\nPercentage: " + percentage * 100;
            }
            else
                resultText.text = "Result: Fail\nScore: " + Mathf.RoundToInt(finalScore) + "\nPercentage: " + percentage * 100;
        }
    }
}
