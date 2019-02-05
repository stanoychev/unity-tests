using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public class Ellipse
//{
//    public float xAxis;
//    public float yAxis;

//    public Ellipse(float xAxis, float yAxis)
//    {
//        this.xAxis = xAxis;
//        this.yAxis = yAxis;
//    }

//    //vector3 za space shit
//    public Vector3 Evaluate(float t)
//    {
//        float angle = Mathf.Deg2Rad * 360f * t;
//        float x = Mathf.Sin(angle) * xAxis;
//        float y = Mathf.Cos(angle) * yAxis;
//        float z = (y - x);

//        return new Vector3(x, y, z);
//    }
//}

[System.Serializable]
public class Ellipse
{
    public float xAxis;
    public float yAxis;

    public Ellipse(float xAxis, float yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;
    }

    //vector3 za space shit
    public Vector3 Evaluate(float t, float secondT = 0f)
    {
        float angle = Mathf.Deg2Rad * 360f * t;
        float x = Mathf.Sin(angle);
        float y = 0;
        float z = Mathf.Cos(angle);

        float x1 = Mathf.Sin(angle);
        float y1 = Mathf.Cos(angle);
        float z1 = 0;

        float x2 = 0;
        float y2 = Mathf.Sin(angle);
        float z2 = Mathf.Cos(angle);

        Vector3 v = new Vector3(x, y, z);
        Vector3 v1 = new Vector3(x1, y1, z1);
        Vector3 v2 = new Vector3(x2, y2, z2);

        //Debug.DrawLine(Vector3.zero, v, Color.green);
        //Debug.DrawLine(Vector3.zero, v1, Color.blue);
        //Debug.DrawLine(Vector3.zero, v2, Color.red);
        return v;
    }
}