using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider mass;
    private Rigidbody rb;
    public float m;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass.onValueChanged.AddListener((l) =>
        {
            rb.mass = m * l;
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
