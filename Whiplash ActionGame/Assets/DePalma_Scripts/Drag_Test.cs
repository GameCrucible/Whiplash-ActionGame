using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Test : MonoBehaviour
{
    Vector3 mousePosition; //Keeps track of mousePosition

    private Vector3 findMouse()
    {
        //When called returns position of the camera in relation to the WorldPoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        //When mouse is clicked it drags the item with this scripts
        mousePosition = gameObject.transform.position - findMouse();
    }

    private void OnMouseDrag()
    {
        //Makes object follow the mouse
        transform.position = findMouse() + mousePosition;
    }
}

