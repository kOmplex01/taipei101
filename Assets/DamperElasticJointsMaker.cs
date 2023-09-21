using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamperElasticJointsMaker : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody[] upperSupports;
    public Rigidbody[] lowerSupports;
    public Vector2 springConst;
    public Vector2 springDamper;
    public bool HingeU = false, FixedU = false;
    public bool HingeL = false, FixedL = false;


    void Start()
    {
        for (int i = 0; i < upperSupports.Length; i++)
        {
            if(HingeU && !FixedU)
            { 
                HingeJoint hingeJoint = gameObject.AddComponent<HingeJoint>();
                hingeJoint.connectedBody = upperSupports[i];
                JointSpring hingeSpring = hingeJoint.spring;
                hingeSpring.spring = springConst.x;
                hingeSpring.damper = springDamper.x;
                hingeJoint.spring = hingeSpring;
                hingeJoint.useSpring = true;
                hingeJoint.autoConfigureConnectedAnchor = true;
            
                //hingeJoint.connectedAnchor = new Vector3(0, -1f, 0);
                Vector3 anchorPoint = -transform.position + upperSupports[i].position;
                anchorPoint.y = 0;
                hingeJoint.anchor = anchorPoint;
            }
            else if(FixedU && !HingeU)
            {
                FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.connectedBody = upperSupports[i];
            }
            else
            {
                ConfigurableJoint confiJoint = gameObject.AddComponent<ConfigurableJoint>();
                confiJoint.connectedBody = upperSupports[i];
                confiJoint.xMotion = ConfigurableJointMotion.Locked;
                confiJoint.yMotion = ConfigurableJointMotion.Locked;
                confiJoint.zMotion = ConfigurableJointMotion.Locked;
                confiJoint.angularXMotion = ConfigurableJointMotion.Free;
                confiJoint.angularYMotion = ConfigurableJointMotion.Free;
                confiJoint.angularZMotion = ConfigurableJointMotion.Free;
            }
        }

        for (int i = 0; i < lowerSupports.Length; i++)
        {
            if(HingeL && !FixedL)
            { 
                HingeJoint hingeJoint = gameObject.AddComponent<HingeJoint>();
                hingeJoint.connectedBody = lowerSupports[i];
                JointSpring hingeSpring = hingeJoint.spring;
                hingeSpring.spring = springConst.x;
                hingeSpring.damper = springDamper.x;
                hingeJoint.spring = hingeSpring;
                hingeJoint.useSpring = true;
                hingeJoint.autoConfigureConnectedAnchor = true;
            
                //hingeJoint.connectedAnchor = new Vector3(0, -1f, 0);
                Vector3 anchorPoint = -transform.position + upperSupports[i].position;
                anchorPoint.y = 0;
                hingeJoint.anchor = anchorPoint;
            }
            else if(FixedL && !HingeL)
            {
                FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.connectedBody = lowerSupports[i];
            }
            else
            {
                ConfigurableJoint confiJoint = gameObject.AddComponent<ConfigurableJoint>();
                confiJoint.connectedBody = lowerSupports[i];
                confiJoint.xMotion = ConfigurableJointMotion.Locked;
                confiJoint.yMotion = ConfigurableJointMotion.Locked;
                confiJoint.zMotion = ConfigurableJointMotion.Locked;
                confiJoint.angularXMotion = ConfigurableJointMotion.Free;
                confiJoint.angularYMotion = ConfigurableJointMotion.Free;
                confiJoint.angularZMotion = ConfigurableJointMotion.Free;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
