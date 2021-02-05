using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public Tiles tilesHolder;
    private int numTiles;
    private Vector3 lastTilePos = new Vector3(0, 0, 0);

    private void Awake()
    {
        numTiles = tilesHolder.tiles.Length;
    }

    private void Start()
    {
        //Start the game with 5 tiles.
        for (int i = 0; i < 5; i++)
            GenerateTile();
    }

    //Generates a random tile object at the end of the map.
    private void GenerateTile()
    {
        int randomInt = Random.Range(0, tilesHolder.tiles.Length);

        //Base Case
        if (lastTilePos == new Vector3(0, 0, 0))
            GetTileLocation((tilesHolder.tiles[randomInt].tileLength / 2) - 15);

        //Generate tile at lastTilePos
        GameObject newTile = Instantiate(tilesHolder.tiles[randomInt].tileObject, lastTilePos, Quaternion.identity);
        newTile.transform.SetParent(this.gameObject.transform);

        //Set new LastTilePos
        lastTilePos = GetTileLocation(tilesHolder.tiles[randomInt].tileLength);
    }
   
    //Adds the tileLength of the parameter to the z value of lastTilePos
    private Vector3 GetTileLocation(float tileLength)
    {
        lastTilePos += new Vector3(0, 0, tileLength);

        return lastTilePos;
    }
}
