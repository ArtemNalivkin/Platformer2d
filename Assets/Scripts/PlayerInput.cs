using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;
    private void Awake()
    {
         playerMovement = GetComponent<PlayerMovement>();
         shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalVars.JUMP);
        
        if (Input.GetButtonDown(GlobalVars.FIRE))
        {
            shooter.Shoot();
        }
        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
}
