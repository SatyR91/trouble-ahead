using UnityEngine;
using UnityEngine.UI;

public class PanelInterface : MonoBehaviour
{

    //public Sprite verticallinesprite;
    //public Sprite horizontallinesprite;
    //public Sprite squaresprite;
    //public Sprite Tsprite;
    //public Sprite ninetyTsprite;
    //public Sprite onehundredeightyTsprite;
    //public Sprite twohundredseventyTsprite;
    //public Sprite Lsprite;
    //public Sprite ninetyLsprite;
    //public Sprite onehundredeightyLsprite;
    //public Sprite twohundredseventyLsprite;
    //public Sprite flippedLsprite;
    //public Sprite ninetyflippedLsprite;
    //public Sprite onehundredeightyflippedLsprite;
    //public Sprite twohundredseventyflippedLsprite;
    //public Sprite Ssprite;
    //public Sprite ninetySsprite;
    //public Sprite flippedSsprite;
    //public Sprite ninetyflippedSsprite;
    //public Image patternimage;
    public Text patternText;
    public Color transparent;

    public TetronimoDisplay display;

    void Awake()
    {
        UIReset();
    }

    public void UIUpdate(PatternManager.PatternType type)
    {

        int[,] matrix = ZeroMatrix();
        GameObject.Find("Console").GetComponent<Console>().UseConsole("Vulnerability Detected.");
        switch (type)
        {
            case (PatternManager.PatternType.verticalline):
                matrix[0, 1] = 1;
                matrix[0, 2] = 1;
                matrix[0, 3] = 1;
                matrix[0, 0] = 1;
                //patternimage.GetComponent<Image>().sprite = verticallinesprite;
                break;
            case (PatternManager.PatternType.horizontalline):
                matrix[0, 0] = 1;
                matrix[1, 0] = 1;
                matrix[2, 0] = 1;
                matrix[3, 0] = 1;
                //patternimage.GetComponent<Image>().sprite = horizontallinesprite;
                break;
            case (PatternManager.PatternType.square):
                matrix[0, 0] = 1;
                matrix[1, 0] = 1;
                matrix[0, 1] = 1;
                matrix[1, 1] = 1;
                //patternimage.GetComponent<Image>().sprite = squaresprite;
                break;
            case (PatternManager.PatternType.T):
                matrix[0, 1] = 1;
                matrix[1, 1] = 1;
                matrix[2, 1] = 1;
                matrix[1, 0] = 1;
                //patternimage.GetComponent<Image>().sprite = Tsprite;
                break;
            case (PatternManager.PatternType.ninetyT):
                matrix[1, 1] = 1;
                matrix[0, 0] = 1;
                matrix[0, 1] = 1;
                matrix[0, 2] = 1;
                //patternimage.GetComponent<Image>().sprite = ninetyTsprite;
                break;
            case (PatternManager.PatternType.onehundredeightyT):
                matrix[0, 0] = 1;
                matrix[1, 0] = 1;
                matrix[2, 0] = 1;
                matrix[1, 1] = 1;
                //patternimage.GetComponent<Image>().sprite = onehundredeightyTsprite;
                break;
            case (PatternManager.PatternType.twohundredseventyT):
                matrix[0, 1] = 1;
                matrix[1, 0] = 1;
                matrix[1, 1] = 1;
                matrix[1, 2] = 1;
                //patternimage.GetComponent<Image>().sprite = twohundredseventyTsprite;
                break;
            case (PatternManager.PatternType.L):
                matrix[0, 0] = 1;
                matrix[0, 1] = 1;
                matrix[0, 2] = 1;
                matrix[1, 0] = 1;
                //patternimage.GetComponent<Image>().sprite = Lsprite;
                break;
            case (PatternManager.PatternType.ninetyL):
                matrix[0, 0] = 1;
                matrix[1, 0] = 1;
                matrix[2, 0] = 1;
                matrix[2, 1] = 1;
                //patternimage.GetComponent<Image>().sprite = ninetyLsprite;
                break;
            case (PatternManager.PatternType.onehundredeightyL):
                matrix[1, 0] = 1;
                matrix[1, 1] = 1;
                matrix[1, 2] = 1;
                matrix[2, 0] = 1;
                //patternimage.GetComponent<Image>().sprite = onehundredeightyLsprite;
                break;
            case (PatternManager.PatternType.twohundredseventyL):
                matrix[0, 1] = 1;
                matrix[1, 1] = 1;
                matrix[2, 1] = 1;
                matrix[0, 0] = 1;
                //patternimage.GetComponent<Image>().sprite = twohundredseventyLsprite;
                break;
            case (PatternManager.PatternType.flippedL):
                matrix[1, 0] = 1;
                matrix[1, 1] = 1;
                matrix[1, 2] = 1;
                matrix[0, 0] = 1;
                //patternimage.GetComponent<Image>().sprite = flippedLsprite;
                break;
            case (PatternManager.PatternType.ninetyflippedL):
                matrix[0, 1] = 1;
                matrix[1, 1] = 1;
                matrix[2, 1] = 1;
                matrix[2, 0] = 1;
                //patternimage.GetComponent<Image>().sprite = ninetyflippedLsprite;
                break;
            case (PatternManager.PatternType.onehundredeightyflippedL):
                matrix[0, 0] = 1;
                matrix[0, 1] = 1;
                matrix[0, 2] = 1;
                matrix[1, 2] = 1;
                //patternimage.GetComponent<Image>().sprite = onehundredeightyflippedLsprite;
                break;
            case (PatternManager.PatternType.twohundredseventyflippedL):
                matrix[0, 1] = 1;
                matrix[1, 1] = 1;
                matrix[2, 1] = 1;
                matrix[0, 0] = 1;
                //patternimage.GetComponent<Image>().sprite = twohundredseventyflippedLsprite;
                break;
            case (PatternManager.PatternType.S):
                matrix[0, 0] = 1;
                matrix[1, 0] = 1;
                matrix[1, 1] = 1;
                matrix[2, 1] = 1;
                //patternimage.GetComponent<Image>().sprite = Ssprite;
                break;
            case (PatternManager.PatternType.ninetyS):
                matrix[1, 0] = 1;
                matrix[1, 1] = 1;
                matrix[0, 1] = 1;
                matrix[0, 2] = 1;
                //patternimage.GetComponent<Image>().sprite = ninetySsprite;
                break;
            case (PatternManager.PatternType.flippedS):
                matrix[2, 0] = 1;
                matrix[1, 0] = 1;
                matrix[1, 1] = 1;
                matrix[0, 1] = 1;
                //patternimage.GetComponent<Image>().sprite = flippedSsprite;
                break;
            case (PatternManager.PatternType.ninetyflippedS):
                matrix[0, 0] = 1;
                matrix[0, 1] = 1;
                matrix[1, 1] = 1;
                matrix[1, 2] = 1;
                //patternimage.GetComponent<Image>().sprite = ninetyflippedSsprite;
                break;
            default:
                break;
        }
        //patternimage.GetComponent<Image>().color = Color.white;
        display.SetDisplay(matrix);
        //patternText.GetComponent<Text>().text = "DRAW THIS PATTERN !";
    }

    private int[,] ZeroMatrix()
    {
        int[,] matrix = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                matrix[i, j] = 0;
            }
        }
        return matrix;
    }

    public void UIReset()
    {
        display.SetDisplay(ZeroMatrix());
        //patternimage.GetComponent<Image>().color = transparent;
        //patternText.GetComponent<Text>().text = null;
    }
}
