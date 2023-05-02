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

    public CharacterController charControl;

    public PlayerMovement moveScript;

    // This stores a reference to the collider for the grapple hook itself
    public GameObject grappleCollider;
    
    public GrappleStrafe strafeScript;

    public Rigidbody rb;

    // This is the max distance of our grapple
    public float maxDistance;

    [Header("Dynamic")]
    // This is a reference to the point that the hook is connected to
    private Vector3 grapplePoint;
    // This is the joint grapple itself
    private SpringJoint joint;
    // This is a reference to the line renderer that I am using for testing
    private LineRenderer lineRend;



    void Awake()
    {
        // Finds the line renderer on the hand
        lineRend = GetComponent<LineRenderer>();

    }

    void Update()
    {
        if(joint)
        {
            Vector3 midPoint = Vector3.Lerp(armTip.position, grapplePoint, 0.5f);
            grappleCollider.transform.position = midPoint;
            grappleCollider.transform.LookAt(grapplePoint);
            float distance = Vector3.Distance(grapplePoint, armTip.position);
            grappleCollider.transform.localScale = new Vector3(0, 0, distance);
        }

        // Checks if left click is pressed and starts the grapple if it is
        if (Input.GetMouseButtonDown(0))
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
        // Stops from drawing the line renderer when there is no spring joint
        if(!joint)
        {return;}

        lineRend.SetPosition(0, armTip.position);
        lineRend.SetPosition(1, grapplePoint);
    }

    // Starts the grapple
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, grappleable))
        {
            moveScript.enabled = false;
            charControl.enabled = false;
            strafeScript.enabled = true;
            moveScript.isSwinging = true;
            
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

            lineRend.positionCount = 2;
        }
        grappleCollider.SetActive(true);
    }

    // Stops the grapple
    void StopGrapple()
    {
        lineRend.positionCount = 0;
        Destroy(joint);
        charControl.enabled = true;
        moveScript.enabled = true;
        grappleCollider.SetActive(false);
        strafeScript.enabled = false;
        moveScript.isSwinging = false;

        // Calculate swing direction based on the player's position and grapple point
        moveScript.swingDirection = (player.position - grapplePoint).normalized;
        // Set the rigidbody velocity at 0 (DO NOT mess with this value)
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 0);
    }

    public bool isGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplingPoint()
    {
        return grapplePoint;
    }
}
