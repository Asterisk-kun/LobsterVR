using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moduleMenu : MonoBehaviour
{
    //This script is located on the moduleMenu canvas
    //Declare our starting values and list of ingredients
    //Will update the ingredients list manually
    public GameObject[] ingredients;
    public int moduleChoice = 0;
    
    //Use this function to get the value from the dropdown
    public void selectModule()
    {
        moduleChoice = this.transform.GetChild(2).gameObject.GetComponent<Dropdown>().value;
    }

    //Use this function to look at what value is from the dropdown and spawn the objects
    public void startModule()
    {
        //Delete all existing food in the scene to begin a new module
        GameObject[] food = GameObject.FindGameObjectsWithTag("Food");
        for (int i = 0; i < food.Length; i++)
        {
            GameObject.Destroy(food[i]);
        }

        if (moduleChoice == 0)
        {
            //Spawn ingredients for Lobster Menu Option
            Instantiate(ingredients[0], new Vector3(-1, 1.2f, -3.158f), Quaternion.Euler(-90, 0f, 0f));
            Instantiate(ingredients[3], new Vector3(-0.7f, 1.2f, -3.1f), Quaternion.identity);
            Instantiate(ingredients[3], new Vector3(-0.5f, 1.2f, -3.1f), Quaternion.identity);
        }
        if(moduleChoice == 1)
        {
            //Spawn ingredients for Admiral's Feast
            Instantiate(ingredients[1], new Vector3(0, 1.2f, -3.1f), Quaternion.identity);
            Instantiate(ingredients[1], new Vector3(0, 1.2f, -3.2f), Quaternion.identity);
            Instantiate(ingredients[1], new Vector3(0, 1.2f, -3.3f), Quaternion.identity);
            Instantiate(ingredients[1], new Vector3(0, 1.2f, -3.4f), Quaternion.identity);
            Instantiate(ingredients[1], new Vector3(0, 1.2f, -3.0f), Quaternion.identity);
            Instantiate(ingredients[1], new Vector3(0, 1.2f, -2.9f), Quaternion.identity);

            Instantiate(ingredients[2], new Vector3(-1, 1.2f, -3.1f), Quaternion.identity);

            Instantiate(ingredients[3], new Vector3(-0.7f, 1.2f, -3.1f), Quaternion.identity);
            Instantiate(ingredients[3], new Vector3(-0.5f, 1.2f, -3.1f), Quaternion.identity);
        }
    }
}
