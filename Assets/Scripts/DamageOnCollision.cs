using UnityEngine;


public class DamageOnCollision : MonoBehaviour
{
    public float damageDone = 1.0f;
    public void OnCollisionEnter2D(Collision2D collisionData)
    {
        // Get the pawn on the other object
        Health otherObjectHealth = collisionData.gameObject.GetComponent<Health>();

        // if that pawn exists!
        if (otherObjectHealth != null)
        {
            // Tell it to take damage
            otherObjectHealth.TakeDamage(damageDone);
        }

    }
}
