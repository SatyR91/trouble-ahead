using System.Collections;
using UnityEngine;

public class Shrine : MonoBehaviour
{

    public float fallSpeed = 20f;

    public bool activated = false;

    public int newCaptureSpeed = 2;
    public float bumpShieldDuration = 10f;


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
                    Debug.Log("Capture Boost");
                    break;
                case (2):
                    // superBump
                    ActivateBumpBoost(other.gameObject.GetComponentInChildren<Player>());
                    Debug.Log("Super Bump");
                    break;
                case (3):
                    // bumpShield
                    ActivateBumpShield(other.gameObject.GetComponentInChildren<Player>());
                    Debug.Log("Bump Shield");
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
        int normalCaptureSpeed = p.captureSpeed;
        p.captureSpeed = newCaptureSpeed;
        StartCoroutine(CaptureBoostCoroutine(2, p, normalCaptureSpeed));
    }

    IEnumerator CaptureBoostCoroutine(float waitTime, Player p, int normalCaptureSpeed)
    {
        yield return new WaitForSeconds(waitTime);
        p.captureSpeed = normalCaptureSpeed;
    }

    // SUPER BUMP
    void ActivateBumpBoost(Player p)
    {
        Bump bump = p.transform.GetComponentInChildren<Bump>();
        bump.superBump = true;
    }

    void ActivateBumpShield(Player p)
    {
        Bump bump = p.transform.GetComponentInChildren<Bump>();
        bump.bumpShield = true;
        Debug.Log("BumpShield");
        StartCoroutine(BumpShieldCoroutine(bumpShieldDuration, p));
    }

    IEnumerator BumpShieldCoroutine(float waitTime, Player p)
    {
        yield return new WaitForSeconds(waitTime);
        p.GetComponentInChildren<Bump>().bumpShield = false;       
    }

    // Desactivate Shrine
    void DesactivateShrine()
    {
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
