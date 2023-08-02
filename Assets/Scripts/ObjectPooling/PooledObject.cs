using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PooledObject : MonoBehaviour

{
    private float timer;    
    private float destroyTime = 0;
    private bool setToDestroy = false;
    private ObjectPool associatedObjectPool;

    [SerializeField] private UnityEvent OnReset;

    public void SetdObjectPool(ObjectPool pool)
    {
        associatedObjectPool = pool;
        timer = 0;
        destroyTime = 0;
        setToDestroy = false;
    }

    void Update()
    {

        if (setToDestroy)
        {
            timer += Time.deltaTime;
        }

        if (timer >= destroyTime)
        {
            setToDestroy = false;
            timer = 0;
            Destroy();
        }
    }

    public void ResteObject()
    {
        OnReset?.Invoke();
    }

    public void Destroy()
    {
        if (associatedObjectPool != null)
        {
            associatedObjectPool.RestoreObject(this);
        }
    }

    public void Destroy(float time)
    {
        setToDestroy = true;
        destroyTime = time;
    }

    public void ResetObject()
    {
        OnReset?.Invoke();
    }
}
