using UnityEngine;


public class DamageOnCollision : MonoBehaviour
{
    public bool selfDestructOnCollision = false;
    public float damageDone = 1.0f;
    public void OnCollisionEnter2D(Collision2D collisionData)
{
    Debug.Log(gameObject.name + " collided with " + collisionData.gameObject.name);

    // Try to get health
    Health otherObjectHealth = collisionData.gameObject.GetComponent<Health>();

    if (otherObjectHealth != null)
    {
        otherObjectHealth.TakeDamage(damageDone);
        Debug.Log(collisionData.gameObject.name + " took " + damageDone + " damage!");
    }
    else
    {
        Debug.Log(collisionData.gameObject.name + " has no Health component.");
    }
}

}