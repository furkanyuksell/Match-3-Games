using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width, height;
    public GameObject tilePrefab;
    private BackgroundTile[,] allTiles;
    public GameObject[,] allDots;
    [SerializeField]DotPooling _dotPooling;
    void Start()
    {
        allTiles = new BackgroundTile[width,height];
        allDots = new GameObject[width,height];
        SetUp();
    }

    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "(" + i + ", " + j + ")";

                var dot = _dotPooling.GetDot();
                dot.transform.parent = backgroundTile.transform;
                dot.transform.position = backgroundTile.transform.position;
                dot.name = "(" + i + ", " + j + ")";
                allDots[i,j] = dot.gameObject;
            }
        }
    }
}
