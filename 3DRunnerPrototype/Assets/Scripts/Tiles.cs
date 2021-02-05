using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    [System.Serializable]
    public class TileList
    {
        public string tileName;
        public float tileLength;
        public GameObject tileObject;
    }

    public TileList[] tiles;
}
