using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public LevelManager levelManager;
    public bool gameOver = false;
    public bool timePassed = false;
    public bool levelWon = false;
    public bool isRunning = false;

    public GameObject building;
    public Slider massSlider;
    public Slider lengthSlider;
    public Slider stiffSlider;

    public Vector2 quakeScaleRange;
    public TMP_Text earthqaukeScale;
    public Vector2 quakeDistRange;
    public TMP_Text earthqaukeDist;
    public Vector2 typhoonWindRange;
    public TMP_Text windVel;
    public Vector2 timeRange;
    public TMP_Text timeText;
    public Button retryButton;
    public Button playButton;

    Earthquake quake;
    Typhoon phoon;
    float time, earthquake, dist, typhoon;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        quake = building.GetComponent<Earthquake>();
        phoon = building.GetComponent<Typhoon>();

        playButton.onClick.AddListener(() =>
        {
            SendDisaster();
        });

        retryButton.onClick.AddListener(() =>
        {
            StartCoroutine(GenerateDisaster(0f));
        });
        StartCoroutine(GenerateDisaster(0f));

    }

    void Update()
    {
        if (time > 0 && isRunning)
        {
            timePassed = false;
            time -= Time.deltaTime;
        }
        timeText.text = Mathf.Round(time).ToString();

        if(time < 0)
        {
            time = 0;
            timePassed = true;
            quake.enabled = false;
            phoon.enabled = false;
            levelWon = true;
        }

        if(levelWon)
        {
            levelWon = false;
            StartCoroutine(GenerateDisaster(6f));
        }

        if (gameOver)
        {
            Debug.Log("OUT!");
        }
    }

    IEnumerator GenerateDisaster(float t)
    {
        yield return new WaitForSeconds(t);
        levelManager.ropesOn = false;
        isRunning = false;

        massSlider.interactable = true;
        lengthSlider.interactable = true;
        stiffSlider.interactable = true;

        earthquake = UnityEngine.Random.Range(quakeScaleRange.x, quakeScaleRange.y);
        Vector2 epicentre = new Vector2 (UnityEngine.Random.Range(-quakeDistRange.x, quakeDistRange.x), 
            UnityEngine.Random.Range(-quakeDistRange.y, quakeDistRange.y));
        dist = Vector2.Distance(epicentre,
            new Vector2(building.transform.position.x, building.transform.position.z));
        typhoon = UnityEngine.Random.Range(typhoonWindRange.x, typhoonWindRange.y);
        time = Mathf.Round(UnityEngine.Random.Range(timeRange.x, timeRange.y));

        earthqaukeScale.text = Math.Round(earthquake,2).ToString();
        earthqaukeDist.text = Math.Round(dist,2).ToString();
        windVel.text = Math.Round(typhoon,2).ToString();
        timeText.text = time.ToString();
    }    

    void SendDisaster()
    {
        levelManager.ropesOn = true;
        isRunning = true;
        
        massSlider.interactable = false;
        lengthSlider.interactable = false;
        stiffSlider.interactable = false;
        
        quake.enabled = true;
        phoon.enabled = true;

        quake.intensity = earthquake;
        quake.distanceFromBuilding = dist;
        phoon.intensity = typhoon;
        quake.totalTime = time;
        phoon.totalTime = time;
    }

    public void StartGeneratingDisaster()
    {
        StartCoroutine(GenerateDisaster(0f));
    }
}
