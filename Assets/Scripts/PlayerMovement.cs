using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variable to hold our sprite Transform information
    private Transform tf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get the Transform from the object this script is on
        tf = GetComponent<Transform>();

        // start at the world origin point (0,0,0)
        tf.position = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // pick a random x and y value within the specified range (lower half of the play space)
            float randomX = Random.Range(-4f, 4f);
            float randomY = Random.Range(-5f, 0f);

            // set our new position to that random point along X and Y, while keeping Z locked at 0.
            tf.position = new Vector3(randomX, randomY, 0f);
            // Console confirmation that the sprites teleportation systems are functioning properly
            Debug.Log("Teleportation Systems engaged, Cap'n!");
        }
    }
}