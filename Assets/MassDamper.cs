using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassDamper : MonoBehaviour
{
    Vector3 initPos;
    bool once = false;
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if(GameManager.Instance.timePassed && !once)
        //{
        //    once = true;
        //    LeanTween.move(gameObject, initPos, 2f).setOnComplete(() =>
        //    {
        //        GameManager.Instance.StartGeneratingDisaster();
        //    });
        //}
    }
}
