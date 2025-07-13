using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotation : inputHandler
{
    bool onMousePressed;
    int pointerId;
    public static Vector2 RotationDelta;
    // Update is called once per frame

    void Awake()
    {

    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (onMousePressed && pointerId == eventData.pointerId)
        {
            RotationDelta = eventData.delta;
        }
        
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onMousePressed)
        {
            onMousePressed = false;
            RotationDelta = Vector2.zero;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!onMousePressed && eventData.position.x > Screen.width / 2)
        {
            RotationDelta = Vector2.zero;
            onMousePressed = true;
            pointerId = eventData.pointerId;
        }
    }
}
