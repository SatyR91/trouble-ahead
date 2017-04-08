using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip[] audioclips;
    private AudioSource audsrc;
	// Use this for initialization
	void Start () {
        audsrc = GetComponent<AudioSource>();
	}
	
    public void PlayPatternStart()
    {
        audsrc.clip = audioclips[1];
        audsrc.Play();
    }
    public void PlaySeize()
    {
        audsrc.clip = audioclips[2];
        audsrc.Play();
        while (audsrc.isPlaying)
        {

        }
        audsrc.clip = audioclips[3];
        audsrc.Play();
    }
    public void PlayExpand()
    {
        audsrc.clip = audioclips[2];
        audsrc.Play();
        while(audsrc.isPlaying)
        {

        }
        audsrc.clip = audioclips[4];
        audsrc.Play();
    }
    public void PlayDefrag()
    {
        audsrc.clip = audioclips[2];
        audsrc.Play();
        while (audsrc.isPlaying)
        {

        }
        audsrc.clip = audioclips[5];
        audsrc.Play();
    }
    public void PlayIsolate()
    {
        audsrc.clip = audioclips[2];
        audsrc.Play();
        while (audsrc.isPlaying)
        {

        }
        audsrc.clip = audioclips[6];
        audsrc.Play();
    }

    public void PlayGameEndWarning()
    {
        audsrc.clip = audioclips[7];
        audsrc.Play();
    }
    public void PlayGameEnd()
    {
        audsrc.clip = audioclips[8];
        audsrc.Play();
    }
}
