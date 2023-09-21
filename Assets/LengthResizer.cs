using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class LengthResizer : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider mainSlider;
    public float speed = 1f;
    private Vector3 initPos;


    void Start()
    {

        initPos = transform.position;
        transform.position = new Vector3(initPos.x, initPos.y - mainSlider.value * speed, initPos.z);
        initPos = new Vector3(initPos.x, initPos.y - mainSlider.value, initPos.z); ;
        mainSlider.onValueChanged.AddListener((l) =>
        {
            float dist = l;
            transform.position = new Vector3(initPos.x, initPos.y - dist * speed, initPos.z);
        });

    }

    private void OnDisable()
    {
        mainSlider.onValueChanged.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
