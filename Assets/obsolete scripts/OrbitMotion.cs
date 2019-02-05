using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class OrbitMotion : MonoBehaviour
//{
//    public Transform orbitObject;
//    public Ellipse orbitPath;

//    [Range(0f, 1f)]
//    public float orbitProgress;
//    public float orbitPeriod = 3f;
//    public bool orbitActive = true;

//    void Start()
//    {
//        if (orbitObject == null)
//        {
//            orbitActive = false;
//            return;
//        }

//        SetOrbitObjectPosition();
//        StartCoroutine(AnimateOrbit());
//    }

//    void SetOrbitObjectPosition()
//    {
//        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
//        orbitObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
//    }

//    IEnumerator AnimateOrbit()
//    {
//        if (orbitPeriod < 0.1f)
//        {
//            orbitPeriod = 0.1f;
//        }
//        float orbitSpeed = 1f / orbitPeriod;

//        while (orbitActive)
//        {
//            orbitProgress += Time.deltaTime * orbitSpeed;
//            orbitProgress %= 1f;
//            SetOrbitObjectPosition();
//            yield return null;
//        }
//    }
//}

public class OrbitMotion : MonoBehaviour
{
    public Transform orbitObject;
    public Ellipse orbitPath;

    [Range(0f, 1f)]
    public float orbitProgress;
    [Range(0f, 1f)]
    public float orbitProgress2;
    public float orbitPeriod = 3f;
    public bool orbitActive = true;

    void Start()
    {
        if (orbitObject == null)
        {
            orbitActive = false;
            return;
        }

        SetOrbitObjectPosition();
        StartCoroutine(AnimateOrbit());
    }

    void SetOrbitObjectPosition()
    {
        Vector3 orbitPos = orbitPath.Evaluate(orbitProgress, orbitProgress2);
        orbitObject.localPosition = new Vector3(orbitPos.x, orbitPos.y, orbitPos.z);
    }

    IEnumerator AnimateOrbit()
    {
        if (orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }
        float orbitSpeed = 1f / orbitPeriod;

        while (orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;

            orbitProgress2 += Time.deltaTime * orbitSpeed*2;
            orbitProgress2 %= 1f;

            SetOrbitObjectPosition();
            yield return null;
        }
    }
}