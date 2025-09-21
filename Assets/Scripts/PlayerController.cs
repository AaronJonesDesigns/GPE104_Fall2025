using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference the Player Pawn
    public PlayerPawn pawn; 
    // Update is called once per frame
    void Update()
    {
        // Local Movement Controls (WASD)
        // W key input
        if (Input.GetKey(KeyCode.W))
        {
            // PlayerPawn forward movement
            pawn.MoveForward();
        }
        // S key input
        if (Input.GetKey(KeyCode.S))
        {
            // PlayerPawn backward movement
            pawn.MoveBackward();
        }
        // A key input
        if (Input.GetKey(KeyCode.A))
        {
            // PlayerPawn rotate counter-clockwise
            pawn.TurnLeft();
        }
        // D key input
        if (Input.GetKey(KeyCode.D))
        {
            // PlayerPawn rotate clockwise
            pawn.TurnRight();
        }

        // World Movement Controls (Arrow Keys)
        // Up arrow key input 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // PlayPawn teleport up (up on 2D screen)
            pawn.MoveUpWorld();
        }
        // Down arrow key input
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // PlayPawn teleport down (down on 2D screen)
            pawn.MoveDownWorld();
        }
        // Left arrow key input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // PlayPawn teleport left (left on 2D screen)
            pawn.MoveLeftWorld();
        }
        // Right arrow key input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // PlayPawn teleport right (right on 2D screen)
            pawn.MoveRightWorld();
        }
    }
}

