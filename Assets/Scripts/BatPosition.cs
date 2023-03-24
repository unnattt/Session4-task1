using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatPosition : MonoBehaviour
{
    public GameObject bat;

    Quaternion obj;

    public void Start()
    {
        bat.transform.rotation = new Quaternion(0, 0, 0, 1);
    }

    public  void OnTriggerEnter(Collider other)
    {
        Debug.Log("working");
         bat.transform.position = new Vector3(other.transform.position.x, bat.transform.position.y, bat.transform.position.z);
        // bat.transform.position = other.transform.position;
        obj = new Quaternion(0.284838438f, 0, 0, + 0.958575547f);
        bat.transform.rotation = obj;
        Debug.Log(bat.transform.rotation.z);
        Debug.Log(other.transform.rotation.z);
        

    }
    

}
