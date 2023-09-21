using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behavior : MonoBehaviour
{
    public GameObject g1;
    public GameObject g2;
    public float k;
    public Rigidbody rb;

    private float length;

    // Start is called before the first frame update
    void Start()
    {
        length = (g1.transform.position - g2.transform.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 normalizedForce = (g1.transform.position - g2.transform.position).normalized;
        float kDeltaX = -k * ((g1.transform.position - g2.transform.position).magnitude - length);
        rb.AddForce(kDeltaX * normalizedForce.x, kDeltaX * normalizedForce.y, kDeltaX * normalizedForce.z);
    }
}