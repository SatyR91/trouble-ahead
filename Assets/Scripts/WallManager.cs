using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {

    public GameObject ExternalWallLeft;
    public GameObject ExternalWallRight;
    public GameObject ExternalWallUp;
    public GameObject ExternalWallDown;
    public GameObject InternalWallLeft;
    public GameObject InternalWallRight;
    public GameObject InternalWallUp;
    public GameObject InternalWallDown;

    public float timeToScale;
    public int timesscaled = 0;

    public void AlterMap()
    {
        timesscaled++;
        StartCoroutine(ScaleOverTime(timeToScale));
    }

    private IEnumerator ScaleOverTime(float timeToScale)
    {
        Vector3 originalLeftInternScale = InternalWallLeft.transform.localScale;
        Vector3 originalRightInternScale = InternalWallRight.transform.localScale;
        Vector3 originalUpInternScale = InternalWallUp.transform.localScale;
        Vector3 originalDownInternScale = InternalWallDown.transform.localScale;
        Vector3 originalLeftExternScale = ExternalWallLeft.transform.localScale;
        Vector3 originalRightExternScale = ExternalWallRight.transform.localScale;
        Vector3 originalUpExternScale = ExternalWallUp.transform.localScale;
        Vector3 originalDownExternScale = ExternalWallDown.transform.localScale;
        Vector3 originalLeftInternPosition = InternalWallLeft.transform.position;
        Vector3 originalRightInternPosition = InternalWallRight.transform.position;
        Vector3 originalUpInternPosition = InternalWallUp.transform.position;
        Vector3 originalDownInternPosition = InternalWallDown.transform.position;
        Vector3 originalLeftExternPosition = ExternalWallLeft.transform.position;
        Vector3 originalRightExternPosition = ExternalWallRight.transform.position;
        Vector3 originalUpExternPosition = ExternalWallUp.transform.position;
        Vector3 originalDownExternPosition = ExternalWallDown.transform.position;

        float currentTime = 0.0f;
        do
        {
            if (timesscaled <= 3)
            {
                if (timesscaled == 1)
                {

                    InternalWallLeft.transform.localScale = Vector3.Lerp(originalLeftInternScale, new Vector3(16.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    InternalWallRight.transform.localScale = Vector3.Lerp(originalRightInternScale, new Vector3(16.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    InternalWallUp.transform.localScale = Vector3.Lerp(originalUpInternScale, new Vector3(16.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    InternalWallDown.transform.localScale = Vector3.Lerp(originalDownInternScale, new Vector3(16.0f, 0.001f, 0.3f), currentTime / timeToScale);
                }
                else if (timesscaled == 2)
                {
                    InternalWallLeft.transform.localScale = Vector3.Lerp(originalLeftInternScale, new Vector3(8.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    InternalWallRight.transform.localScale = Vector3.Lerp(originalRightInternScale, new Vector3(8.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    InternalWallUp.transform.localScale = Vector3.Lerp(originalUpInternScale, new Vector3(8.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    InternalWallDown.transform.localScale = Vector3.Lerp(originalDownInternScale, new Vector3(8.0f, 0.001f, 0.3f), currentTime / timeToScale);
                }
                else if (timesscaled == 3)
                {
                    InternalWallLeft.transform.localScale = Vector3.Lerp(originalLeftInternScale, new Vector3(0, 0.001f, 0.3f), currentTime / timeToScale);
                    InternalWallRight.transform.localScale = Vector3.Lerp(originalRightInternScale, new Vector3(0, 0.001f, 0.3f), currentTime / timeToScale);
                    InternalWallUp.transform.localScale = Vector3.Lerp(originalUpInternScale, new Vector3(0, 0.001f, 0.3f), currentTime / timeToScale);
                    InternalWallDown.transform.localScale = Vector3.Lerp(originalDownInternScale, new Vector3(0, 0.001f, 0.3f), currentTime / timeToScale);
                }
                InternalWallLeft.transform.position = Vector3.Lerp(originalLeftInternPosition, originalLeftInternPosition + Vector3.right * 2, currentTime / timeToScale);
                InternalWallRight.transform.position = Vector3.Lerp(originalRightInternPosition, originalRightInternPosition + Vector3.left * 2, currentTime / timeToScale);
                InternalWallUp.transform.position = Vector3.Lerp(originalUpInternPosition, originalUpInternPosition + Vector3.back * 2, currentTime / timeToScale);
                InternalWallDown.transform.position = Vector3.Lerp(originalDownInternPosition, originalDownInternPosition + Vector3.forward * 2, currentTime / timeToScale);
            }
            else if (timesscaled <= 7 && timesscaled > 4)
            {
                if(timesscaled == 5)
                {
                    ExternalWallLeft.transform.localScale = Vector3.Lerp(originalLeftExternScale, new Vector3(20.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    ExternalWallRight.transform.localScale = Vector3.Lerp(originalRightExternScale, new Vector3(20.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    ExternalWallUp.transform.localScale = Vector3.Lerp(originalUpExternScale, new Vector3(20.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    ExternalWallDown.transform.localScale = Vector3.Lerp(originalDownExternScale, new Vector3(20.0f, 0.001f, 0.3f), currentTime / timeToScale);
                }
                else if (timesscaled == 6)
                {
                    ExternalWallLeft.transform.localScale = Vector3.Lerp(originalLeftExternScale, new Vector3(16.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    ExternalWallRight.transform.localScale = Vector3.Lerp(originalRightExternScale, new Vector3(16.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    ExternalWallUp.transform.localScale = Vector3.Lerp(originalUpExternScale, new Vector3(16.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    ExternalWallDown.transform.localScale = Vector3.Lerp(originalDownExternScale, new Vector3(16.0f, 0.001f, 0.3f), currentTime / timeToScale);
                }
                else if (timesscaled == 7)
                {
                    ExternalWallLeft.transform.localScale = Vector3.Lerp(originalLeftExternScale, new Vector3(12.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    ExternalWallRight.transform.localScale = Vector3.Lerp(originalRightExternScale, new Vector3(12.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    ExternalWallUp.transform.localScale = Vector3.Lerp(originalUpExternScale, new Vector3(12.0f, 0.001f, 0.3f), currentTime / timeToScale);
                    ExternalWallDown.transform.localScale = Vector3.Lerp(originalDownExternScale, new Vector3(12.0f, 0.001f, 0.3f), currentTime / timeToScale);
                }
                ExternalWallLeft.transform.position = Vector3.Lerp(originalLeftExternPosition, originalLeftExternPosition + Vector3.right * 2, currentTime / timeToScale);
                ExternalWallRight.transform.position = Vector3.Lerp(originalRightExternPosition, originalRightExternPosition + Vector3.left * 2, currentTime / timeToScale);
                ExternalWallUp.transform.position = Vector3.Lerp(originalUpExternPosition, originalUpExternPosition + Vector3.back * 2, currentTime / timeToScale);
                ExternalWallDown.transform.position = Vector3.Lerp(originalDownExternPosition, originalDownExternPosition + Vector3.forward * 2, currentTime / timeToScale);
            }
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= timeToScale);
        if(timesscaled == 3)
        {
            GameObject.Find("InternWall").SetActive(false);
        }
        GetComponent<TimerSystem>().MapAlteration = false;
    }
}
