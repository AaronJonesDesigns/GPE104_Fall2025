using UnityEngine;

public class Bullet : MonoBehaviour
{
    public DamageOnCollision damageOnCollisionComponent;
    public BulletMover bulletMoverComponent;
    public void Awake()
    {
        // Load our component variables
        damageOnCollisionComponent = GetComponent<DamageOnCollision>();
        bulletMoverComponent = GetComponent<BulletMover>();
    }
}
