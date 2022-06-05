using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board: MonoBehaviour
{

    public GameObject whiteCell;
    public GameObject blackCell;
    public int nRows = 8;
    public int nCols = 8;
    void Start()
    {
        //Instantiate(whiteCell, new Vector3(0, 0, 0), Quaternion.identity);

        // GameObject a = Instantiate(blackCell);
        // Vector3 newRotation = new Vector3(-90, 0, 0);
        // a.transform.position = new Vector3(0.5f, 0, 0.5f);
        // a.transform.eulerAngles = newRotation;
        GameObject cell;
        for(int i = 0; i < nRows; i++){
            for(int j = 0; j < nCols; j++){
                cell = Instantiate(((i + j) % 2 == 1)? blackCell: whiteCell);
                cell.name = (char)(i + 'A') + (j + 1).ToString();
                cell.transform.position = new Vector3(i - 3.5f, 0, j - 3.5f);
                cell.transform.eulerAngles = new Vector3(-90, 0, 0);
            }
        }
    }

}
