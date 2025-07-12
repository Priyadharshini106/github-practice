using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : inputHandler
{
    public GameObject player;
    CharacterController characterController;
    bool drag;
    Vector3 direction;
    // Update is called once per frame

    void Awake()
    {
        characterController = player.GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        if (drag && direction != Vector3.zero)
        {
            characterController.Move(5f * Time.deltaTime * direction );
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (eventData.position.x > Screen.width / 2)
        {
            drag = false;
            direction = Vector3.zero;
            player.transform.Rotate(Vector3.up, eventData.delta.x * 0.2f);
        }
        else if (eventData.position.x < Screen.width / 2)
        {
            drag = true;
            direction = player.transform.TransformDirection( new Vector3(eventData.delta.x, 0, eventData.delta.y)).normalized; //player.transform.TransformDirection(new Vector3(eventData.delta.x, 0, eventData.delta.y)).normalized;
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector3.zero;
        drag = false;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        direction = Vector3.zero;
        drag = false;
    }
}
