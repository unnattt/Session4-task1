using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPitch : MonoBehaviour
{
    public GameObject pointer;
    public GameObject ball;
    public GameObject bat;

    public Vector3 random;

    public RaycastHit hitting;
    LayerMask mask;

    public LayerMask leftPitch;
    public LayerMask rightPitch;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mask = leftPitch;
            RightBat();
            
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            mask = rightPitch;
            leftBat();   
        }
        ThrowingBallAtPoint();

        //ThrowingBallAtPoint();

        //PathOfthorwnBall();

        //if (GameObject.FindGameObjectWithTag("Player") == null)
        //{
        //    Invoke(nameof(PathOfthorwnBall), 1f);
        //}
    }

    public void PathOfthorwnBall()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(ray);

        if (Physics.Raycast(ray, out hitting, 60f, mask))
        {

          
            if (Input.GetMouseButtonDown(0) && GameObject.FindGameObjectWithTag("Player") == null)
            {
                pointer.transform.position = new Vector3(hitting.point.x, -0.0044f, hitting.point.z);
                //Debug.Log(hitting.point);

                // for thorwing ball at hittingPoints...
                //taking one gameobject and cloning balls
                Invoke(nameof(PathOfthorwnBall), 4f);
                GameObject any = Instantiate(ball, ball.transform.position, ball.transform.rotation);

                //Generating obj of another scripts..and appling rigidbody of ballLauncher class to this gameobject.
                BallLaunch Obj = any.GetComponent<BallLaunch>();

                Obj.ThrownBall(hitting.point+ Vector3.up * 3.02f);
                //for destoring Ball after some time..
                Destroy(any, 4f);

                //if (GameObject.FindGameObjectWithTag("Player") == null)
                //{
                //    Invoke(nameof(PathOfthorwnBall), 1f);
                //}
            }
           
        }


    }

    public void RightBat()
    {
        bat.transform.position = new Vector3(0.112000003f, 0.303000003f, 9.52000046f);
        bat.transform.rotation = new Quaternion(-0.0025905068f, 0.0110446848f, -0.228336141f, 0.973516345f);
    }

    public void leftBat()
    {
        bat.transform.position = new Vector3(-0.109999999f, 0.31400001f, 9.52000046f);
        bat.transform.rotation = new Quaternion(0.0025905068f, 0.0110446848f, 0.228336141f, 0.973516345f);
    }


       

    public void ThrowingBallAtPoint()
    {

        if (Input.GetKeyDown(KeyCode.G)&& GameObject.FindGameObjectWithTag("Player") == null)
        {

            if (mask == leftPitch)
            {
                random.x = Random.Range(-1.771f, -0.047f);
                random.z = Random.Range(2.045f, 8f);
                pointer.transform.position = random;
            }
            else if (mask == rightPitch)
            {
                random.x = Random.Range(0.091f, 1.752f);
                random.z = Random.Range(8.725f, 2.04f);
                pointer.transform.position = random;
            }


            GameObject any = Instantiate(ball, ball.transform.position, ball.transform.rotation);

            //Generating obj of another scripts..and appling rigidbody of ballLauncher class to this gameobject.
            BallLaunch Obj = any.GetComponent<BallLaunch>();

            Obj.ThrownBall(pointer.transform.position + Vector3.up * 3.02f);
            //for destoring Ball after some time..
            Destroy(any, 4f);
            Invoke(nameof(ThrowingBallAtPoint), 4f);
        }
    }
}

