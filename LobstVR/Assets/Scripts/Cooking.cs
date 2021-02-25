using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cooking : MonoBehaviour
{
    public Material[] mats;
    public float timer;
    float COOKED = 10f;
    float FIRE = 20f;
    float BURNT = 30f;
    public float score;
    public TextMeshPro scoreText;
    public Vector3 start;
    public Quaternion Rotation;

    void Start()
    {
        //Set the initial values for each ingredient
        timer = 0f;
        start = this.gameObject.transform.position;
        GetComponent<MeshRenderer>().material = mats[0];
        Rotation = Quaternion.identity;
    }

    //Check the cook time of the object and update the material
    void Update()
    {
        if (timer >= BURNT)
        {
            GetComponent<MeshRenderer>().material = mats[3];
        }
        else if(timer >= FIRE)
        {
            GetComponent<MeshRenderer>().material = mats[2];
        }
        else if(timer >= COOKED)
        {
            GetComponent<MeshRenderer>().material = mats[1];
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Look to see if we are on the heat source for cooking
        if (other.gameObject.tag == "Stove")
        {
            //Since we are on the heat source we increase our cooking time by time
            timer += Time.deltaTime;
            if (timer >= BURNT)
            {
                //Decrease score since we have burnt our food
                score -= Time.deltaTime*3;
            }
            else
            {
                score += Time.deltaTime * 1.8f;
            }
        }
        //Look to see if the food has interacted with the garbage
        if (other.gameObject.tag == "garbage" && this.gameObject.tag == "Food")
        {
            //If garbage is interacted we will reset and respawn the object back into the scene.
            this.score = 0;
            this.GetComponent<MeshRenderer>().material = mats[0];
            Instantiate(this.gameObject, start, Rotation);
            GameObject.Destroy(this.gameObject);

        }
    }
}

