using UnityEngine;

public class Stumps : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false; // Set isKinematic to true at first to stabilize the stumps
    }

    void OnCollisionEnter(Collision collision)
    {
        BallLaunch ball = collision.gameObject.GetComponent<BallLaunch>(); // Get the BallLaunch script component from the collided game object

        if (ball != null)
        {
            rb.isKinematic = true; // Set isKinematic to false when hit by a ball
        }
    }
}
