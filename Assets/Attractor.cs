using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class GravitationalAttractionModel : MonoBehaviour
//{
//    public Rigidbody rb;
//    public static List<GravitationalAttractionModel> attractors;
//    public bool isProton;

//    private void FixedUpdate()
//    {
//        foreach (GravitationalAttractionModel attractor in attractors)
//        {
//            if (attractor != this)
//            {
//                Vector3 force = CalculateForce(attractor);

//                if (attractor.isProton ^ this.isProton)
//                {
//                    attractor.rb.AddForce(force * -1);
//                }
//                else
//                {
//                    attractor.rb.AddForce(force);
//                }
//            }
//        }
//    }

//    private void OnEnable()
//    {
//        if (attractors == null)
//        {
//            attractors = new List<GravitationalAttractionModel>();
//        }
//        attractors.Add(this);
//    }

//    private void OnDisable()
//    {
//        attractors.Remove(this);
//    }

//    Vector3 CalculateForce (GravitationalAttractionModel objToAttract)
//    {
//        //obsolete gravitational model
//        //Rigidbody rbToAttract = objToAttract.rb;

//        //Vector3 direction = rb.position - rbToAttract.position;
//        //float distance = direction.magnitude;

//        //float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
//        //return direction.normalized * forceMagnitude;

//        Rigidbody rbToAttract = objToAttract.rb;

//        Vector3 direction = rb.position - rbToAttract.position;
//        float distance = direction.magnitude;
//        //using the mass property as a proton/electron charge
//        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
//        return direction.normalized * forceMagnitude;
//    }
//}

public class Attractor : MonoBehaviour
{
    public Rigidbody rb;
    public static List<Attractor> attractors;
    public bool isProton;
    public float Qe = 1.6f * Mathf.Pow(10f, -19f);
    public float Qp = 1.6f * Mathf.Pow(10f, -19f);

    private void FixedUpdate()
    {
        foreach (Attractor attractor in attractors)
        {
            if (attractor != this)
            {
                Vector3 force = CalculateForce(attractor);

                if ((attractor.isProton && !this.isProton)
                    ||
                    (!attractor.isProton && this.isProton))
                {
                    attractor.rb.AddForce(force);
                }
                else if (!attractor.isProton && !this.isProton)
                {
                    attractor.rb.AddForce(force * -0.1f);
                }
            }
        }
    }

    private void OnEnable()
    {
        if (attractors == null)
        {
            attractors = new List<Attractor>();
        }
        attractors.Add(this);
    }

    private void OnDisable()
    {
        attractors.Remove(this);
    }

    Vector3 CalculateForce(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float sizeCorrectionCoeffitient =  (0.53f * Mathf.Pow(10f, -10f));

        float k = 9f * Mathf.Pow(10f, 9f);

        float thisQ = this.isProton ? this.Qp : this.Qe;
        float otherQ = objToAttract.isProton ? objToAttract.Qp : objToAttract.Qe;

        //float correctedDistance = distance / sizeCorrectionCoeffitient;
        //thisQ = thisQ * sizeCorrectionCoeffitient;
        //otherQ = otherQ * sizeCorrectionCoeffitient;
        this.rb.mass = thisQ;
        objToAttract.rb.mass = otherQ;

        float forceMagnitude = ((k * thisQ * otherQ) / (Mathf.Pow(sizeCorrectionCoeffitient/distance, 2f)))
            ;
        //* Mathf.Pow(10f, 8f);


        //Debug.Log(forceMagnitude);
        //forceMagnitude = 10;
        return direction.normalized * forceMagnitude;
    }
}