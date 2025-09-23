using UnityEngine;

public class DeathRecenter : Death
{
    public override void Die()
    {
        // Move back to center point
        transform.position = Vector3.zero;
    }
}
