using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour {

    public float timeLeft;
    public Text TimerGUI;
    private float timeStarted;
    private bool timerDone;

    private void Awake()
    {
        timeStarted = Time.time;
        timerDone = false;
    }
    // Update is called once per frame
    void Update () {
		if(Time.time-timeStarted > timeLeft && !timerDone)
        {
            timerDone = true;
            TimerGUI.text = "Round over !";
            FindObjectOfType<ScoreManager>().TallyScores();
            FindObjectOfType<ScoreManager>().BestPlayer();
        }
        else if (timeLeft - (Time.time-timeStarted) >0)
        {
            TimerGUI.text = Mathf.CeilToInt(timeLeft - (Time.time-timeStarted)).ToString();
        }
	}
}
