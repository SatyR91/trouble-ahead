using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public int x;
    public int y;
    public List<Player> players;
    public Player owner;
    public int captureTime = 0;
    public List<Material> glowMaterials;
    //public int captureLength = 120;
    public MeshRenderer meshRender;
    public ColorUsageAttribute test;
    private TimerSystem timersys;

    [HideInInspector]
    public bool locked = false;
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
                if (captureTime >= players[0].captureSpeed)
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
            if (players.Count == 1 && !locked)
            {
                captureTime++;
                if (captureTime >= players[0].captureSpeed)
                {
                    PatternCapture(players[0]);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.transform.parent != null)
        {
            GameObject parent = other.transform.parent.gameObject;
            players.Add(other.transform.parent.GetComponent<Player>());
            // speed up owner
            if (parent.GetComponent<Player>() == owner)
            {
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
            else if (parent.GetComponent<Player>() != owner && locked)
            {
                Stun(parent.GetComponent<Player>());
            }
        }
        

    }

    void OnTriggerExit(Collider other)
    {
        if( other.transform.parent != null)
        {
            players.Remove(other.transform.parent.GetComponent<Player>());

            // Reset capture time
            captureTime = 0;
        }
        
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
        if (timersys.patternInProgress)
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

    void Stun(Player p)
    {
        p.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    // OnMessageReceived : Unlock
    void Unlock()
    {
        if (players.Count != 0)
        {
            foreach( Player p in players)
            {
                p.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                p.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
        }
    }

    public void Flash()
    {
        StartCoroutine(FlashCoroutine(0.1f));
    }

    IEnumerator FlashCoroutine(float waitTime)
    {
        for (int i = 0; i < 3; i++)
        {
            meshRender.material = glowMaterials[0];
            Debug.Log("FLASH");
            yield return new WaitForSeconds(waitTime);
            Debug.Log("wait over");
            meshRender.material = glowMaterials[owner.id];
            DynamicGI.SetEmissive(meshRender, glowMaterials[owner.id].color);
            yield return new WaitForSeconds(waitTime);
        }
        
    }
}
