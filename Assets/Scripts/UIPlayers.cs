using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayers : MonoBehaviour
{
    //public Transform ui;
    public List<GameObject> childrenz;
    private void Awake()
    {
        //childrenz = new List<CanvasRenderer>(gameObject.GetComponentsInChildren<CanvasRenderer>(true));
    }
    public void EnableIcon(int boost)
    {
        boost--;
        //transform.GetChild(boost).gameObject.SetActive(true);
        childrenz[boost].gameObject.SetActive(true);

    }

    public void DisableIcon(int boost)
    {
        boost--;

        childrenz[boost].gameObject.SetActive(false);

        //transform.GetChild(boost).gameObject.SetActive(false);
    }
}
