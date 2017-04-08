using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour
{

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
    void Update()
    {
        if (Time.time - timeStarted > timeLeft && !timerDone)
        {
            timerDone = true;
            TimerGUI.text = "";
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
                pui.UIUpdate(GetComponent<PatternManager>().currentpattern);
                Debug.Log("Pattern time in progress");
            }
            else if ((CastedTime % 10 == 0 && CastedTime % 20 != 0 && patternInProgress) || GetComponent<PatternManager>().cleaningNeeded)
            {
                patternInProgress = false;
                pui.UIReset();
                GetComponent<PatternManager>().cleaningNeeded = false;
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
        int effect = Random.Range(0, 5);
        if (effect == 1)
        {
            return 0;
        }
        if (effect == 2)
        {
            return Random.Range(1, 3);
        }
        if (effect == 3)
        {
            return Random.Range(3, 11);
        }
        return Random.Range(11, 19);
    }
}

//public class TimerSystem : MonoBehaviour
//{

//    public float timeLeft;
//    public Text TimerGUI;
//    private float timeStarted;
//    private bool timerDone;
//    public bool patternTime;
//    public PanelInterface pui;

//    private void Awake()
//    {
//        timeStarted = Time.time;
//        timerDone = false;
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if (Time.time - timeStarted > timeLeft && !timerDone)
//        {
//            timerDone = true;
//            TimerGUI.text = "Round over !";
//            FindObjectOfType<ScoreManager>().TallyScores();
//            FindObjectOfType<ScoreManager>().BestPlayer();
//        }
//        else if (timeLeft - (Time.time - timeStarted) > 0)
//        {
//            int CastedTime = Mathf.CeilToInt(timeLeft - (Time.time - timeStarted));
//            TimerGUI.text = Mathf.CeilToInt(timeLeft - (Time.time - timeStarted)).ToString();
//            if (CastedTime % 20 == 0 && !patternTime)
//            {
//                patternTime = true;
//                GetComponent<PatternManager>().currentpattern = (PatternManager.PatternType)Random.Range(0, 19);
//                pui.UIUpdate(GetComponent<PatternManager>().currentpattern);
//                Debug.Log("Pattern time in progress");
//            }
//            else if ((CastedTime % 10 == 0 && CastedTime % 20 != 0 && patternTime) || GetComponent<PatternManager>().cleaningNeeded)
//            {
//                patternTime = false;
//                pui.UIReset();
//                GetComponent<PatternManager>().cleaningNeeded = false;
//                Debug.Log("Pattern time is over !");
//            }
//        }
//    }
//}
