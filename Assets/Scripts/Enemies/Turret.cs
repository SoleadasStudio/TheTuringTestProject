using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Turret : MonoBehaviour
{
    //state design pattern
    private TurretState state = TurretState.Idle;

    [SerializeField] public Transform turretLaserPoint;
    public Transform playerTransform;

    Vector3 fwd;

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 20;


    void Start()
    {
        fwd = transform.TransformDirection(Vector3.forward);

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = lengthOfLineRenderer;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
    }

    private void Update()
    {
        if (state == TurretState.Idle)
        {
            Idle();
        }
        else if(state == TurretState.Attack) 
        {
            Attack();
        }
     
    }

    private void Idle() 
    {
        if (Physics.Raycast(turretLaserPoint.position, fwd, out RaycastHit hit,10))
        {           
            if (hit.transform.CompareTag("Player"))
            {
                state = TurretState.Attack;
                
            }

        }
    }

    private void Attack()
    {
        if (Physics.Raycast(turretLaserPoint.position, fwd, out RaycastHit hit, 10))
        {
            if (hit.transform.CompareTag("Player"))
            {
                LineRenderer lineRenderer = GetComponent<LineRenderer>();
                if (lineRenderer == null)
                {
                    lineRenderer = gameObject.AddComponent<LineRenderer>();
                }

                // Set the line renderer's position count to 2, as we only need two points (start and end) for a laser
                lineRenderer.positionCount = 2;

                // Set the start position (index 0) to be the turret's position
                lineRenderer.SetPosition(0, turretLaserPoint.position);

                // Set the end position (index 1) to be where the raycast hit
                lineRenderer.SetPosition(1, hit.point);

            }

        }
                
    }

}
