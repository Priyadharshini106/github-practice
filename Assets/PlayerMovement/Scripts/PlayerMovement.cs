using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;
    bool drag = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (drag)
        {
            transform.position += transform.forward * 0.1f;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.Rotate(Vector3.up, eventData.delta.x, Space.Self);
        drag = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        drag = false;
    }
}
