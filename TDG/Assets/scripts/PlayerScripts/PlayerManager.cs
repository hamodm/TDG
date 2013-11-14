using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {
    public bool hasPlacedCastle;
    public Vector3 castlePosition;
    //holds the list of all roads, which are each a list of vertices
    public List<List<Vector3>> roads;
    public List<LineRenderer> roadLines;
	public List<GameObject> units;
    public List<GameObject> towers;
    public List<GameObject> movingUnits;
	// Use this for initialization
	void Start () 
    {
        hasPlacedCastle = false;
        castlePosition = new Vector3(0, 0, 0);
        roads = new List<List<Vector3>>();
        roadLines = new List<LineRenderer>();
        units = new List<GameObject>();
        towers = new List<GameObject>();
        movingUnits = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	}
}
