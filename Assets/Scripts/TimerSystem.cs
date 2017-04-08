using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour {

    public float timeLeft;
    public Text TimerGUI;
    private float timeStarted;
    private bool timerDone;
    public bool patternTime;
    public PanelInterface pui;

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
            int CastedTime = Mathf.CeilToInt(timeLeft - (Time.time - timeStarted));
            TimerGUI.text = Mathf.CeilToInt(timeLeft - (Time.time-timeStarted)).ToString();
            if (CastedTime % 20 == 0 && !patternTime)
            {
                patternTime = true;
                GetComponent<PatternManager>().currentpattern = (PatternManager.PatternType)Random.Range(0, 19);
                pui.UIUpdate(GetComponent<PatternManager>().currentpattern);
                Debug.Log("Pattern time in progress");
            }
            else if ((CastedTime % 10 == 0 && CastedTime % 20 != 0 && patternTime) || GetComponent<PatternManager>().cleaningNeeded)
            {
                patternTime = false;
                pui.UIReset();
                GetComponent<PatternManager>().cleaningNeeded = false;
                Debug.Log("Pattern time is over !");
            }
        }
	}
}
