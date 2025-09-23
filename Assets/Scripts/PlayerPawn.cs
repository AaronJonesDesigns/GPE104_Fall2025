using UnityEngine;

public class PlayerPawn : Pawn
{
    // Variable to hold our sprite Transform information
    private Transform tf;
    // Variable to hold editable Local Movement (WASD) Units per second
    public float moveSpeed = 5f;
    // Variable to hold editable World Movement (Arrow Keys) Units per second
    public float worldMoveSpeed = 5f;
    // Variable to hold editable Turbo Speed
    public float turboSpeed = 10f;
    // Variable to hold degree rotation per frame
    public float turnSpeed = 200f;
    // Sets the min and max X and Y values to public, so they can be edited in the Player Movement component
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4.5f;
    public float maxY = -4.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get the Transform from the object this script is on
        tf = GetComponent<Transform>();
        // start at the world origin point (0,0,0)
        tf.position = Vector3.zero;

    }
    // Local Movement (relative)
    // Forward movement (Local) relative to the direction the sprite is facing 
    public void MoveForward()
    {
        tf.position = tf.position + (tf.up * moveSpeed * Time.deltaTime);
    }
    // Backward movement (Local) relative to the direction the sprite is facing 
    public void MoveBackward()
    {
        tf.position = tf.position - (tf.up * moveSpeed * Time.deltaTime);
    }
    // Counter-clockwise rotation (Local) along Z axis 
    public void TurnLeft()
    {
        tf.Rotate(0f, 0f, turnSpeed * Time.deltaTime);
    }
    // Clockwise rotation (Local) along Z axis
    public void TurnRight()
    {
        tf.Rotate(0f, 0f, -turnSpeed * Time.deltaTime);
    }

    // World Movement (absolute)
    // Slide forward (up on 2D screen)
    public void MoveUpWorld()
    {
        tf.position = tf.position + (Vector3.up * worldMoveSpeed * Time.deltaTime);
    }
    // Slide backward (down on 2D screen)
    public void MoveDownWorld()
    {
        tf.position = tf.position + (Vector3.down * worldMoveSpeed * Time.deltaTime);
    }
    // Strafe left
    public void MoveLeftWorld()
    {
        tf.position = tf.position + (Vector3.left * worldMoveSpeed * Time.deltaTime);
    }
    // Strafe right
    public void MoveRightWorld()
    {
        tf.position = tf.position + (Vector3.right * worldMoveSpeed * Time.deltaTime);
    }
    // Random Teleportation function
    public void TeleportRandom()
    {
        // pick a random x and y value within the specified range (in the inspector)
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        // set our new position to that random point along X and Y, while keeping Z locked at 0.
        tf.position = new Vector3(randomX, randomY, 0f);
        // Console confirmation that the sprites teleportation systems are functioning properly
        Debug.Log("Teleportation Systems engaged, Cap'n!");
    }
    // Turbo forward movement (Local) relative to facing direction
    public void TurboForward()
    {
        tf.position = tf.position + (tf.up * turboSpeed * Time.deltaTime);
    }

}