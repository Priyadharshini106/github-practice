using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class inputHandler : MonoBehaviour,IPointerUpHandler,IPointerDownHandler,IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        PlayerMovement.instance.OnDrag(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerMovement.instance.OnPointerUp(eventData);
        
    }

    
}
