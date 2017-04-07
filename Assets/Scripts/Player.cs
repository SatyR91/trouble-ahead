using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int id;
    public Color color;
    private void Awake()
    {
        GetComponent<PlayerControl>().SetAxisName(id);
        GetComponentInChildren<Bump>().SetBumpColor(id);
        
    }
    public List<Slot> patternslots = new List<Slot>(); 
}
