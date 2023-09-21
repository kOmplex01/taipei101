using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Ropes[] ropes;
    public bool ropesOn = false;
    public bool broken = false;
    public Rigidbody[] building;
   
    // Start is called before the first frame update
    void Start()
    {
        StopRope();
    }

    // Update is called once per frame
    void Update()
    {
        if (ropesOn)
        {
            StartRope();
        }
        else
        {
            StopRope();
        }

        if(broken)
        {
            BuildingBreak();
        }
    }

    public void StopRope()
    {
        Physics.gravity = Vector3.zero;

        foreach (var rope in ropes)
        {
            rope.enabled = false;
        }
    }

    public void StartRope()
    {
        Physics.gravity = new Vector3 (0, -9.8f, 0);

        foreach (var rope in ropes)
        {
            rope.enabled = true;
        }
    }

    void BuildingBreak()
    {
        foreach(Rigidbody rb in building)
        {
            rb.isKinematic = true;
        }
    }
}
