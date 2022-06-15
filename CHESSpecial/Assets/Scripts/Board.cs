using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board: MonoBehaviour
{

    public GameObject whiteCell, blackCell;
    public GameObject pawn, rook, knight, bishop, queen, king;
    public GameObject wall;
    public GameObject coinsText;
    public int nRows = 8;
    public int nCols = 8;
    public int difficulty; // max level of pieces that should appear
    private List<GameObject> spawningCells;
    private GameObject[] pieces;
    private float step = 1f;

    void Start()
    {
        spawningCells = new List<GameObject>();
        difficulty = Mathf.Min(difficulty, 6);
        difficulty = Mathf.Max(difficulty, 1); 
        pieces = new GameObject[] { pawn, rook, knight, bishop, queen, king }; 
        for(int i = 0; i < nRows; i++){
            for(int j = 0; j < nCols; j++){
                GameObject cell = Instantiate(((i + j) % 2 == 1)? blackCell: whiteCell);
                cell.name = (char)(i + 'A') + (j + 1).ToString();
                cell.transform.position = new Vector3(i - (float)nRows/2 - 0.5f, 0, j - (float)nCols/2 - 0.5f);
                cell.transform.eulerAngles = new Vector3(-90, 0, 0);
                if(i != 0) cell.layer = LayerMask.NameToLayer("Ignore Raycast");
                if (i == nRows - 1) spawningCells.Add(cell); 
            }
        }

        var coins = CoinsManager.Instance;
        coins.SetText(coinsText);

        var wallB = Instantiate(wall);
        wallB.tag = "black";
        wallB.transform.position = new Vector3(-(float)nRows / 2 - 1.25f, 1f, - 1f);
        wallB.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        wallB.transform.localScale = new Vector3(0.5f, 2f, nCols);

        var wallW = Instantiate(wall);
        wallW.tag = "white";
        wallW.transform.position = new Vector3((float)nRows / 2 - 0.75f, 1f, -1f);
        wallW.transform.localScale = new Vector3(0.5f, 2f, nCols);
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while(true)
        {
            int idx = Random.Range(0, difficulty);
            var cell = spawningCells[Random.Range(0, nCols)];
            var piece = Instantiate(pieces[idx]);
            piece.transform.position = cell.transform.position;
            if (idx != 0) piece.transform.eulerAngles = new Vector3(piece.transform.eulerAngles.x, piece.transform.eulerAngles.y + 180, piece.transform.eulerAngles.z);
            yield return new WaitForSeconds(ProgressionF(step));
            step += 0.1f; 
        }
    }

    float ProgressionF(float x)
    {
        return 10 / x;
    }

}
