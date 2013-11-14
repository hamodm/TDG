using UnityEngine;
using System.Collections;

public class CreateUnit : MonoBehaviour {
	public GameObject unit;
	public int maxUnits = 5;
	
	private int unitCount;
	private GameObject newUnit;
	private PlayerManager playerManager;
	
	// Use this for initialization
	void Start () 
	{
		playerManager = GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	void OnGUI()
	{
		if(playerManager.units.Count < maxUnits && playerManager.hasPlacedCastle)
			PromptForUnitCreation();
	}
	
	void PromptForUnitCreation()
	{
		if (GUI.Button(new Rect(0, 70, 100, 20), "Create Unit"))
        {
			newUnit = Network.Instantiate(unit, playerManager.castlePosition, Quaternion.identity, 0) as GameObject;
			newUnit.transform.parent = gameObject.transform;
			playerManager.units.Add(newUnit);
            unitCount++;
        }
	}

}
