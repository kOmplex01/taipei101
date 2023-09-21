using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMaker : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lr;
    public Transform point;
    public bool pistonBase;
    public float pistonSize;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if(!pistonBase)
        {
            lr.SetPosition(0, transform.position + Camera.main.transform.forward.normalized / 5f);
            lr.SetPosition(1, point.position);
        }
        else
        {
            lr.SetPosition(0, transform.position);
            Vector3 newPos = Vector3.MoveTowards(transform.position, point.position, pistonSize);
            lr.SetPosition(1, newPos);
        }
    }
}
