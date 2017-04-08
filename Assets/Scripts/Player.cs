using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int id;
    public Color color;
    public int captureSpeed;

    private void Awake()
    {
        GetComponent<PlayerControl>().SetAxisName(id);
        GetComponentInChildren<Bump>().SetBumpColor(id);
        
    }
    public List<Slot> patternslots = new List<Slot>(); 
}
