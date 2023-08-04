using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeShootStrategy : IShootStrategy
{
    private PlayerLaunchProjectile launchInteractor;
    private Transform shootPoint;

    //Constructor
    public OrangeShootStrategy(PlayerLaunchProjectile launchInteractor)
    {
        this.launchInteractor = launchInteractor;
        shootPoint = launchInteractor.spawnPoint.transform;

        //change color
        launchInteractor.spawnPoint.gameObject.GetComponentInParent<MeshRenderer>().material.color = launchInteractor.orangeProjectile.GetComponent<MeshRenderer>().sharedMaterial.color;
    }


    public void Shoot()
    {
        PooledObject projectile = launchInteractor.bulletPool.GetPooledObject();
        projectile.gameObject.SetActive(true);
        projectile.transform.position = launchInteractor.spawnPoint.transform.position;

        // Calculate the shooting direction
        Vector3 shootingDirection = Quaternion.Euler(-30, 0, 0) * launchInteractor.spawnPoint.transform.forward;

        // Apply the direction to the projectile
        projectile.transform.rotation = Quaternion.LookRotation(shootingDirection);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(shootingDirection * 1000);

        launchInteractor.bulletPool.DestroyPooledObject(projectile, 5.0f);
    }
}
