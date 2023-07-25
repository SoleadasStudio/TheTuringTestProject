using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaunchProjectile : MonoBehaviour
{
    [SerializeField] private GameObject orangeProjectile;
    [SerializeField] private GameObject blueProjectile;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private float shootVelocity;
    [SerializeField] private float finalShootVelocity;

    private PlayerInput input;
   // private IShootStrategy currentShootStrategy;


    //Added refernce to objectpool
    //[SerializeField] public ObjectPool _bulletPool;

    ////Added refernce to objectpool
    //[SerializeField] public ObjectPool _bulletPool2;

    void Start()
    {
        input = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
       // Interact();
    }

    //public void Interact()
    //{
    //    if (currentShootStrategy == null)
    //    {
    //        currentShootStrategy = new RedShootStrategy(this);
    //    }
    //    if (input.launcher1Pressed)
    //    {
    //        currentShootStrategy = new RedShootStrategy(this);
    //    }
    //    if (input.launcher2Pressedd)
    //    {
    //        currentShootStrategy = new YellowShootStrategy(this);
    //    }

    //    //
    //    if (input.mousePress && currentShootStrategy != null)
    //    {
    //        currentShootStrategy.Shoot();
    //    }

    //}
}
