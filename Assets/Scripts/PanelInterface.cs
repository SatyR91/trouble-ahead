using UnityEngine;
using UnityEngine.UI;

public class PanelInterface : MonoBehaviour {

    public Sprite verticallinesprite;
    public Sprite horizontallinesprite;
    public Sprite squaresprite;
    public Sprite Tsprite;
    public Sprite ninetyTsprite;
    public Sprite onehundredeightyTsprite;
    public Sprite twohundredseventyTsprite;
    public Sprite Lsprite;
    public Sprite ninetyLsprite;
    public Sprite onehundredeightyLsprite;
    public Sprite twohundredseventyLsprite;
    public Sprite flippedLsprite;
    public Sprite ninetyflippedLsprite;
    public Sprite onehundredeightyflippedLsprite;
    public Sprite twohundredseventyflippedLsprite;
    public Sprite Ssprite;
    public Sprite ninetySsprite;
    public Sprite flippedSsprite;
    public Sprite ninetyflippedSsprite;
    public Image patternimage;
    public Text patternText;
    public Color transparent;

    void Awake()
    {
        UIReset();
    }

    public void UIUpdate(PatternManager.PatternType type)
    {

        switch(type)
        {
            case (PatternManager.PatternType.verticalline):
                patternimage.GetComponent<Image>().sprite = verticallinesprite;
                break;
            case (PatternManager.PatternType.horizontalline):
                patternimage.GetComponent<Image>().sprite = horizontallinesprite;
                break;
            case (PatternManager.PatternType.square):
                patternimage.GetComponent<Image>().sprite = squaresprite;
                break;
            case (PatternManager.PatternType.T):
                patternimage.GetComponent<Image>().sprite = Tsprite;
                break;
            case (PatternManager.PatternType.ninetyT):
                patternimage.GetComponent<Image>().sprite = ninetyTsprite;
                break;
            case (PatternManager.PatternType.onehundredeightyT):
                patternimage.GetComponent<Image>().sprite = onehundredeightyTsprite;
                break;
            case (PatternManager.PatternType.twohundredseventyT):
                patternimage.GetComponent<Image>().sprite = twohundredseventyTsprite;
                break;
            case (PatternManager.PatternType.L):
                patternimage.GetComponent<Image>().sprite = Lsprite;
                break;
            case (PatternManager.PatternType.ninetyL):
                patternimage.GetComponent<Image>().sprite = ninetyLsprite;
                break;
            case (PatternManager.PatternType.onehundredeightyL):
                patternimage.GetComponent<Image>().sprite = onehundredeightyLsprite;
                break;
            case (PatternManager.PatternType.twohundredseventyL):
                patternimage.GetComponent<Image>().sprite = twohundredseventyLsprite;
                break;
            case (PatternManager.PatternType.flippedL):
                patternimage.GetComponent<Image>().sprite = flippedLsprite;
                break;
            case (PatternManager.PatternType.ninetyflippedL):
                patternimage.GetComponent<Image>().sprite = ninetyflippedLsprite;
                break;
            case (PatternManager.PatternType.onehundredeightyflippedL):
                patternimage.GetComponent<Image>().sprite = onehundredeightyflippedLsprite;
                break;
            case (PatternManager.PatternType.twohundredseventyflippedL):
                patternimage.GetComponent<Image>().sprite = twohundredseventyflippedLsprite;
                break;
            case (PatternManager.PatternType.S):
                patternimage.GetComponent<Image>().sprite = Ssprite;
                break;
            case (PatternManager.PatternType.ninetyS):
                patternimage.GetComponent<Image>().sprite = ninetySsprite;
                break;
            case (PatternManager.PatternType.flippedS):
                patternimage.GetComponent<Image>().sprite = flippedSsprite;
                break;
            case (PatternManager.PatternType.ninetyflippedS):
                patternimage.GetComponent<Image>().sprite = ninetyflippedSsprite;
                break;
            default:
                break;
        }
        patternimage.GetComponent<Image>().color = Color.white;
        patternText.GetComponent<Text>().text = "DRAW THIS PATTERN !";
    }


    public void UIReset()
    {
        patternimage.GetComponent<Image>().color = transparent;
        patternText.GetComponent<Text>().text = null;
    }
}
