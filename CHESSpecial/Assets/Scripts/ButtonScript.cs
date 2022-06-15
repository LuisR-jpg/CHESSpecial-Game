using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private Button b;
    public GameObject piece;

    void Start()
    {
        b = GetComponent<Button>();
        b.interactable = true;
        b.onClick.AddListener(Click);
    }
    void Update()
    {
        PieceBaseController script = piece.GetComponent<PieceBaseController>();
		if(script) b.interactable = CoinsManager.Instance.canAfford(script.cost);
    }
    void Click()
    {
        EventTracker.Instance.ClearPiece();
        b.GetComponent<Image>().color = Color.green; 
        EventTracker.Instance.SetPiece(piece, b); 
    }

}
