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
    void Start()
    {
        GameObject cell;
        for(int i = 0; i < nRows; i++){
            for(int j = 0; j < nCols; j++){
                cell = Instantiate(((i + j) % 2 == 1)? blackCell: whiteCell);
                cell.name = (char)(i + 'A') + (j + 1).ToString();
                cell.transform.position = new Vector3(i - (float)nRows/2 - 0.5f, 0, j - (float)nCols/2 - 0.5f);
                cell.transform.eulerAngles = new Vector3(-90, 0, 0);
                if(cell.name == "A1"){ 
                    GameObject p = Instantiate(piece);
                    p.transform.position = cell.transform.position;
                    StartCoroutine(Move(p));
                }
            }
        }
    }
    IEnumerator Move(GameObject p)
    {
        while(true) {
            float prevX = p.transform.position.x;
            p.GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
            print("hola");
            yield return new WaitUntil(() => p.transform.position.x >= prevX + 1f);
            p.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            print("adios");
            yield return new WaitForSeconds(1);
        }
    }
}
