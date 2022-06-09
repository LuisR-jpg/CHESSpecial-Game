using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour
{
    private bool clicked = false;
    void Update()
    {
        //print(piece); 
        //print(piece); 
        if (Input.GetMouseButton(0) && !clicked)
        {
            clicked = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    EventTracker.Instance.PlacePiece(hit.transform.gameObject);
                }
            }
            else
            {
                EventTracker.Instance.ClearPiece(); 
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            clicked = false;
        }
    }
}
