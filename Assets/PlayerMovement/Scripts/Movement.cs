using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : inputHandler
{
    bool onMousePressed;
    public static Vector2 direction;
    int pointerId;
    // Update is called once per frame

    void Awake()
    {
        
    }
    void Update()
    {
        
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (onMousePressed && pointerId == eventData.pointerId)
        {
            direction = eventData.delta.normalized;
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if(onMousePressed)
        {
            direction = Vector2.zero;
            onMousePressed = false;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!onMousePressed && eventData.position.x < Screen.width / 2)
        {
            direction = Vector2.zero;
            onMousePressed = true;
            pointerId = eventData.pointerId;
        }
    }
}
