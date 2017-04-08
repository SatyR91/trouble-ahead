using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

    public int step = -1;
    public Transform instructions;
    public List<string> instructionList;
    public List<Sprite> sprites;
    public Image image;
	// Use this for initialization
	void Awake () {
        instructionList.Add("Move your player with Left Stick");
        instructionList.Add("Capture Data Nodes by staying on them");
        instructionList.Add("Bump other players with A Button"); 
        instructionList.Add("Collect Sensitive Data Folders to gain some boosts : ");
        instructionList.Add("Invulnerability to bumps for 10s");
        instructionList.Add("Faster capture speed for 2s");
        instructionList.Add("Powerful next bump");
        instructionList.Add("Draw specific patterns to hack surrounding Data Nodes");
        instructionList.Add("Lock other opponents in nodes");
        instructionList.Add("Capture surrounding nodes");
        instructionList.Add("Neutralize surrounding nodes");
        instructionList.Add("Don't forget to check your color on the right panel");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("A_1") || Input.GetButtonDown("A_2") || Input.GetButtonDown("A_3") || Input.GetButtonDown("A_4"))
        {
            step++;
            if (step > 11)
            {
                SceneManager.LoadScene("Release");
            }
            else
            {
                instructions.GetChild(step).GetComponent<Console>().UseConsole(instructionList[step]);
            }
            if (step == 1)
                image.sprite = sprites[1];
            if (step == 3)
                image.sprite = sprites[2];
            if (step == 7)
                image.sprite = sprites[3];
            if (step == 11)
                image.sprite = sprites[4];
            
        }
	}
}
