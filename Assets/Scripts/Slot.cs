using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public int x;
    public int y;
    public List<Player> players;
    public Player owner;
    public int captureTime = 0;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");

    }
	
	// Update is called once per frame
	void Update () {

        // Is already captured
        if (owner != null)
        {
            // if another player is alone on the slot, begin neutralisation
            if (players.Count == 1 && players[0] != owner)
            {
                captureTime++;
                if (captureTime >= 120)
                {
                    captureTime = 0;
                    Neutral();
                }
            }
        }
        // if not already captured
        else
        {
            // if only one player is on the slot, begin capture
            if (players.Count == 1)
            {
                captureTime++;
                if (captureTime >= 120)
                {
                    Capture(players[0]);
                }
            }
        }
        
        
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            players.Add(other.GetComponent<Player>());
        }
    }

    void OnTriggerExit(Collider other) {
        // Remove player from players array
        if (other.tag == "Player") {
            players.Remove(other.GetComponent<Player>());
        }

        // Reset capture time
        captureTime = 0;
    }

    void Capture(Player p)
    {
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", p.color);
        owner = p;
    }

    void Contest()
    {

        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
    }

    void Neutral()
    {
        owner = null;
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
    }
}
