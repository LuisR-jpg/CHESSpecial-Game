using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour
{
    private bool clicked = false;
    private List<GameObject> indicators;
    void Start()
    {

    }
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
                    if(hit.transform.gameObject.tag == "white" || hit.transform.gameObject.tag == "black") return;
                    EventTracker.Instance.PlacePiece(hit.transform.gameObject);
                    if (indicators == null) indicators = Clickable.GetIndicators();
                    foreach (var indicator in indicators)
                        indicator.transform.localScale = Vector3.zero;
                }
            }
            else
            {
                EventTracker.Instance.ClearPiece();
                if (indicators == null) indicators = Clickable.GetIndicators();
                foreach (var indicator in indicators)
                    indicator.transform.localScale = Vector3.zero;
            }
            
        }
        else if (!Input.GetMouseButton(0))
        {
            clicked = false;
        }
    } 

    public static List<GameObject> GetIndicators()
    {
            var ind = new List<GameObject>();
            int nCols = GameObject.Find("ScriptHolder").GetComponent<Board>().nCols;
            for (int i = 0; i < nCols; i++)
            {
                ind.Add(GameObject.Find("indicator" + i));
            }
        return ind;
    }
}
