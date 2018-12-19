using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

enum eMovementDirection
{
    Empty = -1,
    Up = 0,
    Down = 1,
    Left = 2,
    Right = 3
}

public class TouchController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    
    public static bool isBombPressed = false;
    public static int isInDirection = (int)eMovementDirection.Empty;

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("UP: " + eventData.pointerCurrentRaycast.gameObject.name);
        if(eventData.pointerCurrentRaycast.gameObject.name.Contains("BombIcon"))
        {
            isBombPressed = true;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name.Contains("TouchPad"))
        {
            isInDirection = (int)eMovementDirection.Empty;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name.Contains("TouchPadLeft"))
        {
            isInDirection = (int)eMovementDirection.Left;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name.Contains("TouchPadRight"))
        {
            isInDirection = (int)eMovementDirection.Right;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name.Contains("TouchPadUp"))
        {
            isInDirection = (int)eMovementDirection.Up;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name.Contains("TouchPadDown"))
        {
            isInDirection = (int)eMovementDirection.Down;
        }
    }
}
