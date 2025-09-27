using UnityEngine;

public class Shooter : MonoBehaviour
{
    //
    public Bullet bulletToShoot;
    public Transform firePoint;
    public void Shoot()
    {
        Shoot(bulletToShoot);
    }
    public void Shoot(Bullet bulletToShoot)
    {
        // Instantiate the bullet we plan to shoot
        Bullet theBullet = Instantiate<Bullet>(bulletToShoot, firePoint.position, firePoint.rotation);

        // TODO: Set bullet damage and speed based on player data
    }
}