using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class batResetPosition : MonoBehaviour
{

    public void OnCollisionExit(Collision collision)
    {

        transform.rotation = new Quaternion(0, 0, 0, 1);
    }

}
