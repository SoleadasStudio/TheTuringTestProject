using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private Camera _camera;
    [SerializeField] private float interactionDistance;
    [SerializeField] private LayerMask interactionLayerMask;

    [Header("Pick and Drop")]
    [SerializeField] LayerMask pickupLayerMask;
    [SerializeField] float pickupDistance;
    [SerializeField] Transform attachTransform;

    //Raycast
    private RaycastHit raycastHit;

    private ISelectable selectable;

    // Pick and Drop
    private bool isPicked = false;
    private IPickable pickable;

    private PlayerInput input;

    void Start()
    {
        input = PlayerInput.GetInstance();
    }

    void Update()
    {
        Interact();
        PickAndDrop();
    }
    void Interact()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out raycastHit, interactionDistance, interactionLayerMask))
        {
            selectable = raycastHit.transform.GetComponent<ISelectable>();

            if (selectable != null)
            {
                selectable.OnHoverEnter();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    selectable.OnSelect();
                }
            }
        }

        if (selectable != null && raycastHit.transform == null)
        {
            selectable.OnHoverExit();
            selectable = null;
        }
    }

    void PickAndDrop()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));


        if (Physics.Raycast(ray, out raycastHit, pickupDistance, pickupLayerMask))
        {

            if (input.activatedPress && !isPicked)
            {
                pickable = raycastHit.transform.GetComponent<IPickable>();
                if (pickable != null)
                {
                    pickable.OnPicked(attachTransform);
                    isPicked = true;
                    return;
                }
            }
            if (input.activatedPress && isPicked)
            {
                pickable.OnDropped();
                isPicked = false;
            }

        }


    }
}
