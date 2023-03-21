using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThorwn : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject pointer;

    public RaycastHit hitting;
    public LayerMask mask;
    public GameObject ball;

    Vector3 Target;
    Vector3 startPosition;
    public float ballspeed;
    //bool isball = false;

    private void Start()
    {
        startPosition = transform.position;
    }


    void FixedUpdate()
    {

        PathOfthorwnBall();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ThrownBall();
        }

    }



    void PathOfthorwnBall()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Debug.Log(ray);


        if (Physics.Raycast(ray, out hitting, 100f, mask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                pointer.transform.position = hitting.point;
                //if (isball == false)
                //{
                //    isball = true;
                // Instantiate(ball, ball.transform.position, ball.transform.rotation);
                //}
            }

        }

    }
   void ThrownBall()
    {
        
        Target = pointer.transform.position;
        Vector3 direction = Target - startPosition;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(direction * ballspeed, ForceMode.Impulse);

            Destroy(ball, 5f);

    }

}


