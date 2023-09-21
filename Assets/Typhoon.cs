using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typhoon : MonoBehaviour
{
    // Start is called before the first frame update
    public float intensity;
    public float speed;
    public ParticleSystem typhoon;
    private Vector3 initRotation;
    private Vector3 windDir;
    public float totalTime = 10f;
    private float currTime = 0f;
    void Start()
    {
        initRotation = transform.rotation.eulerAngles;
    }
    private void OnEnable()
    {
        typhoon.Play();
        currTime = Time.time;
    }
    private void OnDisable()
    {
        typhoon.Stop();
        LeanTween.rotate(gameObject, Vector3.zero, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(currTime - Time.time < totalTime)
        {
            windDir = intensity * new Vector3(
                Mathf.PerlinNoise(speed * Time.time, 1) - 0.5f,
                0f,
                Mathf.PerlinNoise(speed * Time.time, 3) - 0.5f);
            transform.rotation = Quaternion.Euler(initRotation) * Quaternion.Euler(windDir);
        }

    }
}
