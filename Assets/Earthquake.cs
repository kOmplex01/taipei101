using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Earthquake : MonoBehaviour
{
    // Start is called before

    public float speed = 5.0f;
    public float intensity = 0.1f;
    public float heightDisp = 0.1f;
    public Vector2 rangeFromBuilding;
    public float distanceFromBuilding;
    public float totalTime = 10f;
    private float currTime = 0f;

    Vector3 initialDir;
    float currSpeed;
    Vector2 epicentre;

    void Start()
    {
        initialDir = transform.position;
    }

    private void OnEnable()
    {
        currTime = Time.time;
    }

    private void OnDisable()
    {
        LeanTween.move(gameObject, initialDir, 1f);
    }

    void Update()
    {
        if (currTime - Time.time < totalTime)
        {
            transform.localPosition = initialDir +  intensity * new Vector3(
                Mathf.PerlinNoise(speed * Time.time, 1),
                0f,
                Mathf.PerlinNoise(speed * Time.time, 2));
        }
    }

}
