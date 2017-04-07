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
    public List<Material> glowMaterials;
    public int captureLength = 120;
    public MeshRenderer meshRender;
    public ColorUsageAttribute test;
    private TimerSystem timersys;
    // Use this for initialization
    void Awake()
    {
        //meshRender.material.color = test.;
        //meshRender.material.pro
        meshRender.material = glowMaterials[0];
        DynamicGI.SetEmissive(meshRender, glowMaterials[0].color);
        //meshRender.material.EnableKeyword("_EMISSION");
        x = Mathf.FloorToInt(transform.position.x / 2);
        y = Mathf.FloorToInt(transform.position.z / 2);
        timersys = GetComponentInParent<TimerSystem>();
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
        if (parent.GetComponent<Player>() == owner)
        {
            Player p = parent.GetComponent<Player>();
            // player's speed is not boosted
            if (!parent.GetComponent<PlayerControl>().isBoosted)
            {
                parent.GetComponent<PlayerControl>().SetBoost(true);
            }
        }
        else if (parent.GetComponent<Player>() != owner && parent.GetComponent<PlayerControl>().isBoosted/* != parent.GetComponent<PlayerControl>().basicAcceleration*/)
        {
            parent.GetComponent<PlayerControl>().SetBoost(false);
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

    public void Capture(Player p)
    {
        meshRender.material = glowMaterials[p.id];
        DynamicGI.SetEmissive(meshRender, glowMaterials[p.id].color);
        owner = p;
        PlayCaptureAnimation(p);
        p.gameObject.GetComponent<PlayerControl>().SetBoost(true);
    }

    public float SqrMagnitude(Slot other)
    {
        return Mathf.Pow(other.x - this.x, 2) + Mathf.Pow(other.y - this.y, 2);
    }

    void PatternCapture(Player p)
    {
        //meshRender.material.SetColor("_EmissionColor", p.color);
        Capture(p);
        if (timersys.patternTime)
        {
            p.GetComponent<Player>().patternslots.Add(this);
            GetComponentInParent<PatternManager>().CheckForPattern(ref p.GetComponent<Player>().patternslots);
        }
    }

    void Contest()
    {
        meshRender.material.SetColor("_EmissionColor", Color.black);
    }

    public void Neutral()
    {
        owner = null;
        meshRender.material = glowMaterials[0];
    }

    void PlayCaptureAnimation(Player p)
    {
        switch (p.id)
        {
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
