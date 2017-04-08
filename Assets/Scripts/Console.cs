using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    private string str;
    private string str2;
    private bool isLocked;

    public void UseConsole(string str)
    {
        if (!isLocked)
        StartCoroutine(AnimateText(str));
    }

    
    IEnumerator AnimateText(string strComplete)
    {
        isLocked = true;
        int i = 0;
        str = GetComponent<Text>().text;
        str2 = "> ";
        while (i < strComplete.Length)
        {
            str2 += strComplete[i++];
            GetComponent<Text>().text = str2 +"\n" +  str;
            yield return new WaitForSeconds(0.0211f);
        }
        isLocked = false;
    }
}
