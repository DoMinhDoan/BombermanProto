using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isBombPressed = false;

    public Button bombButton;

    enum eMovementDirection
    {
        Empty = -1,
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    private int isInDirection = (int)eMovementDirection.Empty;

    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == bombButton)
        {
            Debug.Log("Clicked: " + bombButton.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("The mouse click was released");
        //Debug.Log("UP: " + eventData.pointerCurrentRaycast.gameObject.name);
        isBombPressed = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("The mouse click was pressed");
        //Debug.Log("DOWN: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}
