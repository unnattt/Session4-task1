using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatsScripts : MonoBehaviour
{
    public GameObject bat;

    public  void OnTriggerEnter(Collider other)
    {
        Debug.Log("working");
         bat.transform.position = new Vector3(other.transform.position.x, bat.transform.position.y, bat.transform.position.z);
       // bat.transform.position = other.transform.position;  
    }

}
