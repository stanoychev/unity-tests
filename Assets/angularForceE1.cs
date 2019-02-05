using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angularForceE1 : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb.AddForce(new Vector3(-100, 0, -500));
    }
}
