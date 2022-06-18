using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 difference;
    private Vector3 resetCamera;
    private Camera mainCamera;
    public GameObject leftBoundary, rightBoundary, upperBoundary, lowerBoundary; 
    private float sens = 30f; 

    private bool drag = false;

    private void Start()
    {
        mainCamera = Camera.main;
        resetCamera = transform.position;
    }

    private void LateUpdate()
    {
        // Left click (Navigate)
        if (Input.GetMouseButton(0))
        {
            difference = (mainCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, mainCamera.nearClipPlane * sens))) - transform.position;
            if (drag == false)
            {
                drag = true;
                origin = mainCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, mainCamera.nearClipPlane * sens));
            }
        }
        else drag = false;
        if(drag)
        {
            Vector3 pos = origin - difference;
            pos = new Vector3(Mathf.Clamp(pos.x, leftBoundary.transform.position.x, rightBoundary.transform.position.x), pos.y, pos.z);
            pos = new Vector3(pos.x, Mathf.Clamp(pos.y, lowerBoundary.transform.position.y, upperBoundary.transform.position.y), pos.z);
            transform.position = pos;
        }
        
        // Rigth click (Reset)
        if (Input.GetMouseButton(1))
            transform.position = resetCamera;

        // Mouse wheel
        if (Input.mouseScrollDelta != Vector2.zero)
            transform.position = transform.position + Input.mouseScrollDelta.y * transform.forward;
    }

    public void SetBoundaries(float top, float bottom, float left, float right)
    {
        leftBoundary.transform.position = new Vector3(left, 0, 0);
        rightBoundary.transform.position = new Vector3(right, 0, 0);
        lowerBoundary.transform.position = new Vector3(0, bottom, 0);
        upperBoundary.transform.position = new Vector3(0, top, 0); 
    }
}

