using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private void Awake()
    {
         playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxisRaw("Horizontal");
        bool isJumpButtonPressed = Input.GetButtonDown("Jump");
        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
}
