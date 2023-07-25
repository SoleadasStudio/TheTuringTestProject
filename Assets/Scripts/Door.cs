using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Material defaultLockColor, detectedLockColor;
    [SerializeField] private MeshRenderer LockRenderer;
    [SerializeField] private Animator doorAnimator;

    private float timer = 0;
    private float waitTime = 1.0f;
    public bool isLocked = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isLocked)
        {
            timer += Time.deltaTime;

            if (other.tag == "Player")
            {
                if (timer >= waitTime)
                {
                    timer = waitTime;
                    doorAnimator.SetBool("Open", true);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetBool("Open", false);
    }
    public void LockDoor()
    {
        isLocked = true;

        LockRenderer.material = defaultLockColor;
    }
    public void unLockDoor()
    {
        isLocked = false;

        LockRenderer.material = detectedLockColor;
    }
}
