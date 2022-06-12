using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EventTracker 
{
    private static EventTracker _instance = null;
    private static object _handle = new object();
	private Button b;
	private GameObject piece; 

    protected EventTracker() { }
	public static EventTracker Instance
	{
		get
		{
			lock (_handle)
			{
				if (_instance == null)
				{
					_instance = new EventTracker();
				}
			}

			return _instance;
		}
	}
	public void SetPiece(GameObject _piece, Button _b)
    {
		piece = _piece;
		b = _b; 
    }

	public void ClearPiece()
    {
		if (!piece) return;
		piece = null;
		b.GetComponent<Image>().color = Color.white;
		b = null; 
    }

	public void PlacePiece(GameObject cell)
	{
		if (!piece) return;
		if (cell.tag == "white" || cell.tag == "black") return; 
		GameObject p = GameObject.Instantiate(piece);
		p.transform.position = cell.transform.position;
		ClearPiece(); 
	}
}
