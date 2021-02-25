using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapHold : MonoBehaviour
{
    public Transform parent;
    Rigidbody myRig;

   
    // Start is called before the first frame update
    void Start()
    {
        myRig = gameObject.GetComponent<Rigidbody>();
    }
    //https://docs.unity3d.com/ScriptReference/Transform.SetParent.html

    private void OnTriggerEnter(Collider other)
    {
       
       
        if (other.gameObject.tag == "snapPlate")
        {
            Debug.Log("plate");
            this.gameObject.transform.SetParent(parent, true);
            //this.gameObject.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 0.08f, other.transform.position.z);
            //this.gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            myRig.isKinematic = true;
            //making a child
        }
 
    }
    // Update is called once per frame
    void Update()
    {
        parent = GameObject.FindGameObjectWithTag("Plate").transform;
    }
}
