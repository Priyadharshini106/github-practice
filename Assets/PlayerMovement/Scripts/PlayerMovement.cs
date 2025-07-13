using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    Animator PlayerAnim;
    float MovementX, MovementY;
    public float PlayerRotateSpeed;
    Vector3 MoveDirection;
    float currentX ,currentY= 0;
    public float PlayerMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        PlayerAnim = GetComponent<Animator>();
        MovementX = PlayerAnim.GetFloat("MovementX");
        MovementY = PlayerAnim.GetFloat("MovementY");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementDir();
        PlayerRotation();
    }

    void PlayerRotation()
    {
        transform.Rotate(Vector3.up, Rotation.RotationDelta.x * PlayerRotateSpeed, Space.Self);
    }
    void PlayerMovementDir()
    {
        MovementX = Movement.direction.x;
        MovementY = Movement.direction.y;
        currentX = Mathf.Lerp(currentX, MovementX, Time.deltaTime *10f );
        currentY = Mathf.Lerp(currentY, MovementY, Time.deltaTime *10f);
        
        PlayerAnim.SetFloat("MovementX", currentX);
        PlayerAnim.SetFloat("MovementY", currentY);

        MoveDirection = transform.TransformDirection(new Vector3(MovementX, 0, MovementY));
        characterController.Move(PlayerMoveSpeed * MoveDirection);
    }
}
