using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flooder : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float dethBeforeSubmerged = 1f;
    public float displacementAmount = 3f;

    private void FixedUpdate()
    {
        if (transform.position.y < 0f){
            float displacementMultiplier = Mathf.Clamp01(-transform.position.y / dethBeforeSubmerged) * displacementAmount;
            rigidBody.AddForce (new Vector3(0f, Mathf.Abs(Physics.gravity.y) *displacementMultiplier, 0f));   
            }
    }
}
