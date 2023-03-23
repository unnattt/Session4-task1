using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHitScripts : MonoBehaviour
{

    public GameObject bat;
    public float swingForce;

    public  Rigidbody batRb;

    void Update()
     {
    if (Input.GetKeyDown(KeyCode.Space)) {
        SwingBat();
    }
    }
    
    public void ResetBatPosition() {
    bat.transform.position = new Vector3(0.00200000009f,0.395999998f,9.38700008f);
    bat.transform.rotation = new Quaternion(-0.536465287f,-0.131347746f,-0.0849677771f,0.829296827f);
}
    void SwingBat() 
     {
    // Apply force to the bat in the direction of the swing
    Vector3 force = transform.forward * swingForce;
    batRb.AddForce(force, ForceMode.Impulse);

    // Rotate the bat to simulate the swinging motion
    Quaternion targetRotation = Quaternion.Euler(25f,0 , 0f);
    StartCoroutine(RotateBat(targetRotation, 0.5f));
     StartCoroutine(ResetBatAfterSwing(1.0f));
}

IEnumerator RotateBat(Quaternion targetRotation, float duration) {
    float elapsedTime = 0f;
    Quaternion startRotation = batRb.transform.rotation;
    while (elapsedTime < duration) {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        batRb.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
        yield return null;
    }
}
IEnumerator ResetBatAfterSwing(float delay) {
    yield return new WaitForSeconds(delay);
    ResetBatPosition();

}
}
