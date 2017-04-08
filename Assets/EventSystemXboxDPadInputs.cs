using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventSystemXboxDPadInputs : MonoBehaviour
{
    public GameObject currentButton;
    private AxisEventData currentAxis;
    public Color selectedColor;
    public Color unselectedColor;
    public Color clickedColor;

    //timer
    private float timeBetweenInputs = 0.15f; //in seconds
    private float timer = 0;
    public string leftXAxis;
    public string leftYAxis;
    public string aButton;

    public GameObject buttons;
    
    void Update()
    {
        currentButton = EventSystem.current.currentSelectedGameObject;
        Text buttonText = currentButton.transform.GetChild(0).GetComponent<Text>();
        buttonText.color = selectedColor;

        if (Input.GetButton(aButton))
        {
            currentButton = EventSystem.current.currentSelectedGameObject;
            buttonText.color = clickedColor;
        }
        else {
            if (timer == 0)
            {
                currentAxis = new AxisEventData(EventSystem.current);
                
                if (Input.GetAxis(leftYAxis) > 0 && buttonText != (buttons.transform.GetChild(0)).transform.GetChild(0).GetComponent<Text>()) // move up
                {
                    currentAxis.moveDir = MoveDirection.Up;
                    ExecuteEvents.Execute(currentButton, currentAxis, ExecuteEvents.moveHandler);
                    buttonText.color = unselectedColor;
                    timer = timeBetweenInputs;
                    
                }
                else if (Input.GetAxis(leftYAxis) < 0 && buttonText != (buttons.transform.GetChild(buttons.transform.childCount - 1)).transform.GetChild(0).GetComponent<Text>()) // move down
                {
                    currentAxis.moveDir = MoveDirection.Down;
                    ExecuteEvents.Execute(currentButton, currentAxis, ExecuteEvents.moveHandler);
                    buttonText.color = unselectedColor;
                    timer = timeBetweenInputs;
                   
                }
                else if (Input.GetAxis(leftXAxis) > 0) // move right
                {
                    currentAxis.moveDir = MoveDirection.Right;
                    ExecuteEvents.Execute(currentButton, currentAxis, ExecuteEvents.moveHandler);
                    timer = timeBetweenInputs;
                    
                }
                else if (Input.GetAxis(leftXAxis) < 0) // move left
                {
                    currentAxis.moveDir = MoveDirection.Left;
                    ExecuteEvents.Execute(currentButton, currentAxis, ExecuteEvents.moveHandler);
                    timer = timeBetweenInputs;
                 
                }
            }
        }


        //timer counting down
        if (timer > 0) { timer -= Time.deltaTime; } else { timer = 0; }
    }
}