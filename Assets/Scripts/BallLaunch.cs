using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLaunch : MonoBehaviour
{
    // Vector3 Target;
    //Vector3 startPosition;
    Rigidbody rb;
    public float ballspeed;


    public void Start()
    {
        // startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    public void ThrownBall(Vector3 hittingPoint)
    {

        Rigidbody ball = GetComponent<Rigidbody>();
        ball.AddForce((hittingPoint - transform.position)* ballspeed);

        //Target = pointer.transform.position;
        //Vector3 direction = Target - startPosition;
        //rb.AddForce(direction * ballspeed, ForceMode.Impulse);
        // Instantiate(ball, ball.transform.position, ball.transform.rotation);

        //Destroy(ball, 2f);
    }

    public void HitBall(Vector3 direction, float force) 
    {
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
}
