using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public Text positionone;
    public Text positiontwo;
    public Text positionthree;
    public Text positionfour;
    public GameObject Scoreboard;
    public GameObject Map;

    private void Start()
    {
        Scoreboard.SetActive(false);
    }
    public void TallyScores()
    {
        Scoreboard.SetActive(true);
        List<Slot> slots = new List<Slot>(Map.GetComponentsInChildren<Slot>());
        slots = slots.FindAll(s => s.owner != null);
        int player1score = slots.FindAll(s => s.owner.id == 1).Count;
        int player2score = slots.FindAll(s => s.owner.id == 2).Count;
        int player3score = slots.FindAll(s => s.owner.id == 3).Count;
        int player4score = slots.FindAll(s => s.owner.id == 4).Count;
        positionone.text = "Player 1 : " + player1score;
        positiontwo.text = "Player 2 : " + player2score;
        positionthree.text = "Player 3 : " + player3score;
        positionfour.text = "Player 4 : " + player4score;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
