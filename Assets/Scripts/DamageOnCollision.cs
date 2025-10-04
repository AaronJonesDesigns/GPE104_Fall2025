using UnityEngine;


public class DamageOnCollision : MonoBehaviour
{
    // destroy object on collision
    public bool selfDestructOnCollision = false;
    // public float for controlling the amount of damage
    public float damageDone = 1.0f;
    // function called when an object collides with another
    public void OnCollisionEnter2D(Collision2D collisionData)
    {
        Debug.Log(gameObject.name + " collided with " + collisionData.gameObject.name);

        // Try to get health
        Health otherObjectHealth = collisionData.gameObject.GetComponent<Health>();
        // if the other object has health...
        if (otherObjectHealth != null)
        {
            // ...subtract damageDone from objects health
            otherObjectHealth.TakeDamage(damageDone);
            // Show result in console
            Debug.Log(collisionData.gameObject.name + " took " + damageDone + " damage!");
        }
        else
        {
            // if the other object doesn't have a health component print this to console
            Debug.Log(collisionData.gameObject.name + " has no Health component.");
        }
    }
}