using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetronimoDisplay : MonoBehaviour
{
    public GameObject[] display;

    public void SetDisplay(int[,] thing)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                display[i + j * 4].SetActive(thing[i, j] == 1);
            }
        }
    }

    public void Awake()
    {
        foreach (GameObject cell in display)
        {
            cell.SetActive(false);
        }
    }
}
