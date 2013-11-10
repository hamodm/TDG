using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour {
    public float moveSpeed = 50f;
    private PlayerManager playerManager;
    private bool isSelectingRoadForMovement;
    private bool isMoving;
    private bool canMove;
    private List<Vector3> destinations;
    private List<Rect> buttons;
    private int yellowRoad = 0;
	// Use this for initialization
	void Start () 
    {
        playerManager = gameObject.transform.parent.GetComponent<PlayerManager>();
        isSelectingRoadForMovement = false;
        isMoving = false;
        canMove = true;
        destinations = new List<Vector3>();
        buttons = new List<Rect>();
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (isMoving && destinations.Count > 0)
            Move();
        else if (isMoving)
        {
            isMoving = false;
            playerManager.movingUnits.Remove(gameObject);
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            Vector3 mouse = Input.mousePosition;
            mouse.y = Screen.height - mouse.y;
            print(mouse.x + ", " + mouse.y + ", " + buttons[i].x + ", " + buttons[i].y);
            int roadNumber = (int)(buttons[i].y - 90) / 20;
            if (mouse.x >= buttons[i].x && mouse.x <= (buttons[i].x+buttons[i].width) && mouse.y >= buttons[i].y && mouse.y <= (buttons[i].y + buttons[i].height))
            {
                playerManager.roadLines[roadNumber].renderer.material.color = Color.yellow;
                yellowRoad = roadNumber;
            }
            else
                playerManager.roadLines[roadNumber].renderer.material.color = Color.blue;
        }

	}

    void OnGUI()
    {
        if (playerManager.units.Count > 0 && !isMoving && canMove)
            PromptForMovement();
        if (isSelectingRoadForMovement && !isMoving && canMove)
            SelectRoad();
        else
            buttons = new List<Rect>();
    }


    void PromptForMovement()
    {
        if (GUI.Button(new Rect(0, 90, 100, 20), "Move Units"))
        {
            isSelectingRoadForMovement = true;
        }
    }

    void SelectRoad()
    {
        buttons = new List<Rect>();
        for (int i = 0; i < playerManager.roads.Count; i++)
        {
            Rect button = new Rect(120, 90 + (20 * i), 100, 20);
            buttons.Add(button);
            if (GUI.Button(button, "Move Along Road " + i))
            {
                MoveAlongRoad(i);
                isSelectingRoadForMovement = false;
            }
        }
    }

    public void DecrHealth()
    {
        gameObject.renderer.material.color = Color.red;
    }

    public void StopDecrHealth()
    {
        gameObject.renderer.material.color = Color.white;
    }

    public void MoveAlongRoad(int road)
    {
        print(playerManager.roads[road].Count);
        for (int i = 0; i < playerManager.roads[road].Count; i++)
        {
            print(i);
            print(playerManager.roads[road][i].z);
            isMoving = true;
            playerManager.movingUnits.Add(gameObject);
            destinations.Add(playerManager.roads[road][i]);
        }
    }

    float GetDistance(Vector3 origin, Vector3 destination)
    {
        return (float)Math.Sqrt(Math.Pow(origin.x - destination.x, 2) + Math.Pow(origin.y - destination.y, 2) + Math.Pow(origin.z - destination.z, 2));
    }

    void Move()
    {
        print("From: " + gameObject.transform.position.x + ", " + gameObject.transform.position.z + " To: " + destinations[0].x + ", " + destinations[0].z);
        float rate = moveSpeed / GetDistance(gameObject.transform.position, destinations[0]);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destinations[0], rate);
        if (gameObject.transform.position == destinations[0])
            destinations.Remove(destinations[0]);
        canMove = false;
        playerManager.roadLines[yellowRoad].renderer.material.color = Color.blue;
        print(gameObject.transform.position.z);
    }
}
