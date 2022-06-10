using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board: MonoBehaviour
{

    public GameObject whiteCell;
    public GameObject blackCell;
    public GameObject piece;
    public int nRows = 8;
    public int nCols = 8;
    private List<GameObject> spawningCells; 
    void Start()
    {
        spawningCells = new List<GameObject>(); 
        for(int i = 0; i < nRows; i++){
            for(int j = 0; j < nCols; j++){
                GameObject cell = Instantiate(((i + j) % 2 == 1)? blackCell: whiteCell);
                cell.name = (char)(i + 'A') + (j + 1).ToString();
                cell.transform.position = new Vector3(i - (float)nRows/2 - 0.5f, 0, j - (float)nCols/2 - 0.5f);
                cell.transform.eulerAngles = new Vector3(-90, 0, 0);
                if(i != 0) cell.layer = LayerMask.NameToLayer("Ignore Raycast");
                if (i == nRows - 1) spawningCells.Add(cell); 
                //if(cell.name == "A1"){ 
                //    GameObject p = Instantiate(piece);
                //    p.transform.position = cell.transform.position;
                //    StartCoroutine(Move(p));
                //}
            }
        }

        foreach(var cell in spawningCells)
        {
            GameObject p = Instantiate(piece);
            p.transform.position = cell.transform.position;
        }
    }
}
