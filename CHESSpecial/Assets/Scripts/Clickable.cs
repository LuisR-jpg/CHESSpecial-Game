using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    private bool clicked = false;
    void Update()
    {
        if (Input.GetMouseButton(0) && !clicked)
        {
            clicked = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    ClickAction(hit.transform.gameObject);
                }
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            clicked = false;
        }
    }
   
    void ClickAction(GameObject obj)
    {
        print(obj); 
    }
}
