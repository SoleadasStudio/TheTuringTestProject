using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    public UnityEvent onCubePlaced;
    public UnityEvent onCubeRemoved;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickCube"))
        {
            onCubePlaced?.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickCube"))
        {
            onCubeRemoved?.Invoke();
        }
    }
}
