using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public int x;
    public int y;
    public List<Player> players;
    public Player owner;
    public int captureTime = 0;
    public int captureLength = 120;
    public MeshRenderer meshRender;
    public float speedBoost;
    // Use this for initialization
    void Awake()
    {
        meshRender.material.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {

        // Is already captured
        if (owner != null)
        {
            // if another player is alone on the slot, begin neutralisation
            if (players.Count == 1 && players[0] != owner)
            {
                captureTime++;
                if (captureTime >= captureLength)
                {
                    captureTime = 0;
                    owner.patternslots.Remove(this);
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
                if (captureTime >= captureLength)
                {
                    PatternCapture(players[0]);
                }
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        GameObject parent = other.transform.parent.gameObject;
         players.Add(other.transform.parent.GetComponent<Player>());
        // speed up owner
        if (parent.GetComponent<Player>() == owner) {
            Player p = parent.GetComponent<Player>();
            // player's speed is not boosted
            if (parent.GetComponent<PlayerControl>().acceleration == parent.GetComponent<PlayerControl>().basicAcceleration)
            {
                parent.GetComponent<PlayerControl>().acceleration += speedBoost;
            }
        }
        else if (parent.GetComponent<Player>() != owner && parent.GetComponent<PlayerControl>().acceleration != parent.GetComponent<PlayerControl>().basicAcceleration) {
            parent.GetComponent<PlayerControl>().acceleration -= speedBoost;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        // Remove player from players array
        //if (other.name == "PlayerCenter")
        {
            players.Remove(other.transform.parent.GetComponent<Player>());
        
        }

        // Reset capture time
        captureTime = 0;
    }

    void Capture(Player p)
    {
        meshRender.material.SetColor("_EmissionColor", p.color);
        owner = p;
        PlayCaptureAnimation(p);
        p.gameObject.GetComponent<PlayerControl>().acceleration += speedBoost;
    }

    void PatternCapture(Player p)
    {
        meshRender.material.SetColor("_EmissionColor", p.color);
        owner = p;
        PlayCaptureAnimation(p);
        p.gameObject.GetComponent<PlayerControl>().acceleration += speedBoost;
        p.GetComponent<Player>().patternslots.Add(this);
        List<Slot> patternslot = GetComponentInParent<PatternManager>().CheckForPattern(p.GetComponent<Player>().patternslots);
    }

    void Contest()
    {

        meshRender.material.SetColor("_EmissionColor", Color.black);
    }

    void Neutral()
    {
        owner = null;
        meshRender.material.SetColor("_EmissionColor", Color.black);
    }

    void PlayCaptureAnimation(Player p)
    {
        switch (p.id) {
            case 1: //green
                transform.FindChild("Green FXCapture").GetComponent<ParticleSystem>().Play();
                break;
            case 2: //red
                transform.FindChild("Red FXCapture").GetComponent<ParticleSystem>().Play();
                break;
            case 3: //blue
                transform.FindChild("Blue FXCapture").GetComponent<ParticleSystem>().Play();
                break;
            case 4: //yellow
                transform.FindChild("Yellow FXCapture").GetComponent<ParticleSystem>().Play();
                break;
            default:
                break;
        }
    }
}
