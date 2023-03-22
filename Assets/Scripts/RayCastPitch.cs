using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPitch : MonoBehaviour
{
    public GameObject pointer;
    public GameObject ball;

    public RaycastHit hitting;
    public LayerMask mask;


    void Update()
    {
        PathOfthorwnBall();

    }

    public void PathOfthorwnBall()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(ray);

        if (Physics.Raycast(ray, out hitting, 60f, mask))
        {

          
            if (Input.GetMouseButtonDown(0))
            {
                pointer.transform.position = new Vector3(hitting.point.x, 0.025f, hitting.point.z);
                //Debug.Log(hitting.point);

                // for thorwing ball at hittingPoints...
                //taking one gameobject and cloning balls 
                GameObject any = Instantiate(ball, ball.transform.position, ball.transform.rotation);

                //Generating obj of another scripts..and appling rigidbody of ballLauncher class to this gameobject.
                BallLaunch Obj = any.GetComponent<BallLaunch>();

                Obj.ThrownBall(hitting.point);
                //for destoring Ball after some time..
                Destroy(any, 4f);
            }
        }
    }
}

