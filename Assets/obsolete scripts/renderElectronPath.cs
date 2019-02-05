using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class renderElectronPath : MonoBehaviour
//{
//    public LineRenderer lr;
//    public int segmentCount = 20;
//    public float segmentScale = 1;

//    public Rigidbody rb;
//    public 
//    void FixedUpdate()
//    {
//        Vector3[] segments = new Vector3[segmentCount];

//        segments[0] = rb.transform.position;
//        Vector3 segVelocity = (rb.transform.up + rb.transform.right + rb.transform.forward) * rb.mass * Time.deltaTime;

//        lr.startColor = Color.red;

//        lr.positionCount = segmentCount;
//        for (int i = 0; i < segmentCount; i++)
//        {
//            lr.SetPosition(i, segments[i]);
//        }
//    }
//}

public class renderElectronPath : MonoBehaviour
{
    private Vector3 prevLoc;

    //public renderElectronPath()
    //{
    //    this.prevLoc = Vector3.zero;
    //}

    private void Start()
    {
        //this.prevLoc = Vector3.zero;
    }

    public Rigidbody rb;
    public void FixedUpdate()
    {
        //Vector3 currPos = new Vector3
        //    (rb.transform.position.x,
        //    rb.transform.position.y,
        //    rb.transform.position.z);

        //Debug.DrawLine(this.prevLoc, currPos, Color.red);

        //this.prevLoc = currPos;
    }

    private void Update()
    {
        if (this.prevLoc == null)
        {
            this.prevLoc = Vector3.zero;
        }

        Vector3 currPos = new Vector3
            (rb.transform.position.x,
            rb.transform.position.y,
            rb.transform.position.z);

        Debug.DrawLine(this.prevLoc, currPos, Color.red);

        this.prevLoc = new Vector3(currPos.x, currPos.y, currPos.z);
    }
}
