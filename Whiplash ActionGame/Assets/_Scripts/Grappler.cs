using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    [Header("Inscribed")]
    // These layer masks decide what is grappleable (i.e. player goes to the point) 
    // and what is pullable (i.e. point comes to player)
    public LayerMask grappleable;
    public LayerMask pullable;

    public Transform armTip;

    public Transform camera;

    public Transform player;

    // This is the max distance of our grapple
    public float maxDistance;

    // This is a reference to the line renderer that I am using for testing
    private LineRenderer lineRend;

    [Header("Dynamic")]
    // This is a reference to the point that the hook is connected to
    private Vector3 grapplePoint;
    // This is the joint grapple itself
    private SpringJoint joint;


    void Awake()
    {
        // Finds the line renderer on the hand
        lineRend = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Checks if left click is pressed and starts the grapple if it is
        if(Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        // Checks if left click is released and stops the grapple if it is
        else if(Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void DrawRope()
    {
        lineRend.SetPosition(0, armTip.position);
        lineRend.SetPosition(1, grapplePoint);
    }

    // Starts the grapple
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, grappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            // This is the distance the grapple will try to keep from the grapple point
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            // Mess with these values for different feels for the hook
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
        }
    }

    // Stops the grapple
    void StopGrapple()
    {

    }
}
