using System.Collections;
using UnityEngine;

public class Shrine : MonoBehaviour
{

    public float fallSpeed = 20f;

    public bool activated = false;

    public int newCaptureSpeed = 2;
    public float bumpShieldDuration = 10f;

    public UIPlayers playersUI;


    // Use this for initialization
    void Awake()
    {
        
    }

    void Start()
    {
        // DROP IT !
        GetComponent<Rigidbody>().velocity = Vector3.down * fallSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            int random = Random.Range(1, 4);
            switch(random)
            {
                case (1): 
                    // speedCapture
                    ActivateCaptureBoost(other.gameObject.GetComponent<Player>());
                    other.gameObject.GetComponent<Player>().ui.EnableIcon(2);
                    break;
                case (2):
                    // superBump
                    ActivateBumpBoost(other.gameObject.GetComponent<Player>());
                    other.gameObject.GetComponent<Player>().ui.EnableIcon(3);
                    break;
                case (3):
                    // bumpShield
                    ActivateBumpShield(other.gameObject.GetComponent<Player>());
                    other.gameObject.GetComponent<Player>().ui.EnableIcon(1);
                    break;
                default:
                    break;
            }
            DesactivateShrine();
        }
    }

    // CAPTURE BOOST
    void ActivateCaptureBoost(Player p)
    {
        GameObject.Find("Console").GetComponent<Console>().UseConsole("Player " + p.id + " has acquired sensitive information. Capture boost enabled.");
        int normalCaptureSpeed = p.captureSpeed;
        p.captureSpeed = newCaptureSpeed;
        StartCoroutine(CaptureBoostCoroutine(2, p, normalCaptureSpeed));
    }

    IEnumerator CaptureBoostCoroutine(float waitTime, Player p, int normalCaptureSpeed)
    {
        yield return new WaitForSeconds(waitTime);
        p.captureSpeed = normalCaptureSpeed;
        p.ui.DisableIcon(2);
    }

    // SUPER BUMP
    void ActivateBumpBoost(Player p)
    {
        GameObject.Find("Console").GetComponent<Console>().UseConsole("Player " + p.id + " has acquired sensitive information. Bump boost enabled.");
        Bump bump = p.transform.GetComponentInChildren<Bump>();
        bump.superBump = true;
    }

    void ActivateBumpShield(Player p)
    {
        GameObject.Find("Console").GetComponent<Console>().UseConsole("Player " + p.id + " has acquired sensitive information. Shield boost enabled.");
        Bump bump = p.transform.GetComponentInChildren<Bump>();
        bump.bumpShield = true;
        Debug.Log("BumpShield");
        StartCoroutine(BumpShieldCoroutine(bumpShieldDuration, p));
    }

    IEnumerator BumpShieldCoroutine(float waitTime, Player p)
    {
        yield return new WaitForSeconds(waitTime);
        p.GetComponentInChildren<Bump>().bumpShield = false;
        p.ui.DisableIcon(1);    
    }

    // Desactivate Shrine
    void DesactivateShrine()
    {
        GetComponent<ParticleSystem>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        StartCoroutine(DestroyShrineCoroutine(15));
    }

    IEnumerator DestroyShrineCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this);
    }
}
