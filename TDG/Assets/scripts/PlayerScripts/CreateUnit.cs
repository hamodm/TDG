using UnityEngine;
using System.Collections;

public class CreateUnit : MonoBehaviour {
	public GameObject unit;
	public int maxUnits = 5;
<<<<<<< HEAD
=======
	public float unitSpeed = 5.0f;
>>>>>>> 20b2cbc5d3654f0e7c8f20db6f5518f3fe14531f
	
	private int unitCount;
	private GameObject newUnit;
	private PlayerManager playerManager;
	
	// Use this for initialization
	void Start () 
	{
<<<<<<< HEAD
=======
		unitCount = 0;
>>>>>>> 20b2cbc5d3654f0e7c8f20db6f5518f3fe14531f
		playerManager = GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
<<<<<<< HEAD
=======
		if(Input.GetKey(KeyCode.R))
			DecrHealth();
		else
			StopDecrHealth();
>>>>>>> 20b2cbc5d3654f0e7c8f20db6f5518f3fe14531f
	}
	
	void OnGUI()
	{
<<<<<<< HEAD
		if(playerManager.units.Count < maxUnits && playerManager.hasPlacedCastle)
=======
		if(unitCount < maxUnits)
>>>>>>> 20b2cbc5d3654f0e7c8f20db6f5518f3fe14531f
			PromptForUnitCreation();
	}
	
	void PromptForUnitCreation()
	{
		if (GUI.Button(new Rect(0, 70, 100, 20), "Create Unit"))
        {
			newUnit = Network.Instantiate(unit, playerManager.castlePosition, Quaternion.identity, 0) as GameObject;
			newUnit.transform.parent = gameObject.transform;
			playerManager.units.Add(newUnit);
<<<<<<< HEAD
            unitCount++;
        }
	}

=======
        }
	}
	
	public void DecrHealth()
	{
		unit.renderer.material.color = Color.red;	
	}
	
	public void StopDecrHealth()
	{
		unit.renderer.material.color = Color.white;	
	}
	
	public void MoveAlongRoad(DrawRoad road)
	{
		for(int i = 0; i < road.GetVertices().Count; i++)
			MoveTo(road.GetVertices()[i]);	
	}
	
	void MoveTo(Vector3 destination)
	{
		return;	
	}
>>>>>>> 20b2cbc5d3654f0e7c8f20db6f5518f3fe14531f
}
