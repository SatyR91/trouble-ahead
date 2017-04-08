﻿using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour {

    public Text TimerGUI;
    public PanelInterface pui;
    public float timeLeft;
    public float patternOccurence;
    public float patternResolutionTime;
    public bool patternInProgress;
    public float shrineOccurence;
    private float timeStarted;
    private bool timerDone;
    private bool shrineSpawned;
    public int WallCompaction;
    public bool MapAlteration;

    private void Awake()
    {
        MapAlteration = false;
        timeStarted = Time.time;
        timerDone = false;
    }
    // Update is called once per frame
    void Update ()
    {
        if (Time.time - timeStarted > timeLeft && !timerDone)
        {
            timerDone = true;
            TimerGUI.text = "Finish";
            FindObjectOfType<ScoreManager>().TallyScores();
            FindObjectOfType<ScoreManager>().BestPlayer();
        }
        else if (timeLeft - (Time.time - timeStarted) > 0)
        {
            int CastedTime = Mathf.CeilToInt(timeLeft - (Time.time - timeStarted));
            TimerGUI.text = Mathf.CeilToInt(timeLeft - (Time.time - timeStarted)).ToString();
            if (CastedTime % patternOccurence == 0 && !patternInProgress)
            {
                patternInProgress = true;
                GetComponent<PatternManager>().currentpattern = (PatternManager.PatternType)Randform();
                //pui.UIUpdate(GetComponent<PatternManager>().currentpattern);
                Debug.Log("Pattern time in progress");
            }
            else if (CastedTime % patternResolutionTime == 0 && CastedTime % patternOccurence != 0 && patternInProgress)
            {
                patternInProgress = false;
                Debug.Log("Pattern time is over !");
            }
            if (CastedTime % shrineOccurence == 0 && !shrineSpawned)
            {
                GetComponent<SpawnShrine>().Spawn();
                shrineSpawned = true;
            }
            if (CastedTime % (shrineOccurence - 1) == 0)
                shrineSpawned = false;
            if (CastedTime % WallCompaction == 0 && !MapAlteration)
            {
                MapAlteration = true;
                GetComponent<WallManager>().AlterMap();
            }
            if (CastedTime % (WallCompaction - 1) == 0)
            {
                MapAlteration = false;
            }
        }
	}

    int Randform()
    {
        int effect = Random.Range(1 , 5);
        if (effect == 1)
        {
            return 1;
        }
        if (effect == 2)
        {
            return Random.Range(2 , 4);
        }
        if (effect == 3)
        {
            return Random.Range(4 , 12);
        }
        return Random.Range(12, 20);
    } 
}
