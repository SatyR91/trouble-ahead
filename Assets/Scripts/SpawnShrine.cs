using System.Collections.Generic;
using UnityEngine;

public class SpawnShrine : MonoBehaviour {

    public Transform slotsParent;
    public GameObject shrine;
    public List<Slot> slots;

	// Use this for initialization
	void Start () {
        foreach (Transform child in slotsParent)
        {
            slots.Add(child.GetComponent<Slot>());
        }        
    }
	
	// Update is called once per frame
	/*void Update () {
		if (Input.GetKeyDown(KeyCode.A))
        {
            Spawn();
        }
	}*/

    public void Spawn()
    {
        List<Slot> emptySlots = slots.FindAll(s => s.owner == null);
        Slot randomSlot = emptySlots[Random.Range(0, emptySlots.Count)];
        Vector3 offset = new Vector3(0, 10, 0);
        Vector3 pos = randomSlot.transform.position + offset;

        Instantiate(shrine, pos, shrine.transform.rotation);
        Debug.Log(randomSlot);
    }
}
