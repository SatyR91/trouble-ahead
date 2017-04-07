using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour {

    public Text position1;
    public Text position2;
    public Text position3;
    public Text position4;
    public Text congratulation;
    public GameObject Scoreboard;
    public GameObject Map;
   

    private int player1score;
    private int player2score;
    private int player3score;
    private int player4score;

    private void Start()
    {
        
        Scoreboard.SetActive(false);
    }
    public void TallyScores()
    {
        Scoreboard.SetActive(true);
        List<Slot> slots = new List<Slot>(Map.GetComponentsInChildren<Slot>());
        slots = slots.FindAll(s => s.owner != null);
        player1score = slots.FindAll(s => s.owner.id == 1).Count;
        player2score = slots.FindAll(s => s.owner.id == 2).Count;
        player3score = slots.FindAll(s => s.owner.id == 3).Count;
        player4score = slots.FindAll(s => s.owner.id == 4).Count;
        position1.text = "Player 1 : " + player1score;
        position2.text = "Player 2 : " + player2score;
        position3.text = "Player 3 : " + player3score;
        position4.text = "Player 4 : " + player4score;

    }

    public void BestPlayer()
    {
        int maxscore = Mathf.Max(Mathf.Max(player1score, player2score), Mathf.Max(player3score, player4score));
        int topPlayers = 0;
        if (player1score == maxscore)
        {
            congratulation.text = "Congratulation, Player 1 !";
            congratulation.color = new Color(0f, 0.8f, 0f, 1f);
            topPlayers++;
        }
        if (player2score == maxscore)
        {
            congratulation.text = "Congratulation, Player 2 !";
            congratulation.color = new Color(0.8f, 0f, 0f, 1f);
            topPlayers++;
        }
        if (player4score == maxscore)
        {
            congratulation.text = "Congratulation, Player 3 !";
            congratulation.color = new Color(0f, 0.14f, 0.67f, 1f);
            topPlayers++;
        }
        if (player4score == maxscore)
        {
            congratulation.text = "Congratulation, Player 4 !";
            congratulation.color = new Color(0.85f, 0.8f, 0.05f, 1f);
            topPlayers++;
        }
        if (topPlayers > 1)
        {
            congratulation.text = "It's a tie !";
            congratulation.color = new Color(0f, 0f, 0f, 1f);
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
