using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();

        if(destroyable != null)
        {
            destroyable.OnCollided();
        }

        Destroy(gameObject);
    }
}
