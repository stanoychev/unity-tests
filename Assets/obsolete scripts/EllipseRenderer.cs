﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(LineRenderer))]
//public class EllipseRenderer : MonoBehaviour
//{
//    LineRenderer lr;

//    [Range(3, 36)]
//    public int segments;
//    public Ellipse ellipse;

//    void Awake()
//    {
//        lr = GetComponent<LineRenderer>();
//        CalculateEllipse();
//    }

//    void CalculateEllipse()
//    {
//        Vector3[] points = new Vector3[segments + 1];
//        for (int i = 0; i < segments; i++)
//        {
//            Vector2 position2D = ellipse.Evaluate((float)i / (float)segments);
//            points[i] = new Vector3(position2D.x, 0f, position2D.y);
//        }

//        points[segments] = points[0];

//        lr.positionCount = segments + 1;
//        lr.SetPositions(points);
//    }

//    void OnValidate()
//    {
//        if (Application.isPlaying && lr != null)
//        {
//            CalculateEllipse();
//        }
//    }
//}

[RequireComponent(typeof(LineRenderer))]
public class EllipseRenderer : MonoBehaviour
{
    LineRenderer lr;

    [Range(3, 36)]
    public int segments;
    public Ellipse ellipse;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        CalculateEllipse();
    }

    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++)
        {
            Vector3 position3D = ellipse.Evaluate((float)i / (float)segments, (float)i*2 / (float)segments);
            points[i] = new Vector3(position3D.x, position3D.y, position3D.z);
        }

        points[segments] = points[0];

        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }

    void OnValidate()
    {
        if (Application.isPlaying && lr != null)
        {
            CalculateEllipse();
        }
    }
}