using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private float moveDistance;
    [SerializeField] private bool isUp;
    [SerializeField] private float speed;
    [SerializeField] private GameObject player;

    private float distanceThreshold = 2;
    private bool isMoving;
    private Vector3 targetPosition;
    private CharacterController controller;

    public void ToggleLift()
    {
        if (isUp)
        {
            targetPosition = transform.localPosition - new Vector3(0, moveDistance, 0);
            isUp = false;
        }
        else
        {
            targetPosition = transform.localPosition + new Vector3(0, moveDistance, 0);
            isUp = true;
        }
    }
    
    void Start()
    {
        targetPosition = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.localPosition, targetPosition) < distanceThreshold)
        {
            EnablePlayerCharacterController();
            isMoving = false;
        }
        else
        {
            DisablePlayerCharacterController();
            isMoving = true;
        }
    }
    private void DisablePlayerCharacterController()
    {
        player.transform.SetParent(transform);
        player.GetComponent<CharacterController>().enabled = false;
    }

    private void EnablePlayerCharacterController()
    {
        player.transform.SetParent(null);
        player.GetComponent<CharacterController>().enabled = true;
    }
}
