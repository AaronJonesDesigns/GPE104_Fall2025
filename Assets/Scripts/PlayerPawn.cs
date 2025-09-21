using UnityEngine;

public class PlayerPawn : MonoBehaviour
{
    // Variable to hold our sprite Transform information
    private Transform tf;
    // Variable to hold editable Local Movement (WASD) Units per second
    public float moveSpeed = 5f;
    // Variable to hold editable World Movement (Arrow Keys) Units per second
    public float worldMoveSpeed = 5f;
    // Variable to hold degree rotation per frame
    public float turnSpeed = 200f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get the Transform from the object this script is on
        tf = GetComponent<Transform>();

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
    // Teleport forward (up on 2D screen)
    public void MoveUpWorld()
    {
        tf.position = tf.position + (Vector3.up * worldMoveSpeed * Time.deltaTime);
    }
    // Teleport backward (down on 2D screen)
    public void MoveDownWorld()
    {
        tf.position = tf.position + (Vector3.down * worldMoveSpeed * Time.deltaTime);
    }
    // Teleport left
    public void MoveLeftWorld()
    {
        tf.position = tf.position + (Vector3.left * worldMoveSpeed * Time.deltaTime);
    }
    // Teleport right
    public void MoveRightWorld()
    {
        tf.position = tf.position + (Vector3.right * worldMoveSpeed * Time.deltaTime);
    }
}