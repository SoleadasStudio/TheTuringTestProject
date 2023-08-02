using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaunchProjectile : MonoBehaviour
{
    [SerializeField] public GameObject orangeProjectile;
    [SerializeField] public GameObject blueProjectile;
    [SerializeField] public GameObject spawnPoint;
    [SerializeField] public ObjectPool bulletPool;
    [SerializeField] public ObjectPool bulletPool2;

    [SerializeField] private float shootVelocity;
    [SerializeField] private float finalShootVelocity;

    private PlayerInput input;
    private IShootStrategy currentShootStrategy;

    void Start()
    {
        input = PlayerInput.GetInstance();
    }

    void Update()
    {
        Interact();
    }

    public void Interact()
    {
        if (currentShootStrategy == null)
        {
            currentShootStrategy = new OrangeShootStrategy(this);
        }
        if (input.launcher1Pressed)
        {
            currentShootStrategy = new OrangeShootStrategy(this);
        }
        if (input.launcher2Pressed)
        {
            currentShootStrategy = new BlueShootStrategy(this);
        }

        //
        if (input.mousePress && currentShootStrategy != null)
        {
            currentShootStrategy.Shoot();
        }

    }
}
