using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerManager : MonoBehaviour {
    public float attackRadius = 10f;
    
    private GameObject[] players;
    private PlayerManager[] playerManagers;
    private bool isAttacking;
    private int targetCount;
	// Use this for initialization
	void Start () 
    {
        isAttacking = false;
        targetCount = 0;
        int i = 0;
        players = GameObject.FindGameObjectsWithTag("Player");
        playerManagers = new PlayerManager[players.Length];
        foreach (GameObject player in players)
        {
            print(i);
            playerManagers[i] = player.GetComponent<PlayerManager>();
            i++;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        foreach (PlayerManager manager in playerManagers)
        {
            print(manager.movingUnits.Count);
            if (manager.movingUnits.Count > 0)
            {
                targetCount = 0;
                for (int i = 0; i < manager.movingUnits.Count; i++)
                {
                    if (Vector3.Distance(gameObject.transform.position, manager.movingUnits[i].transform.position) < attackRadius)
                        Attack(manager.movingUnits[i]);
                }
            }
            else if (isAttacking)
                NotAttacking();

            if (isAttacking && targetCount == 0)
                NotAttacking();
        }
	}

    void Attack(GameObject target)
    {
        isAttacking = true;
        targetCount++;
        gameObject.renderer.material.color = Color.red;
        target.GetComponent<UnitManager>().DecrHealth();
    }

    void NotAttacking()
    {
        isAttacking = false;
        gameObject.renderer.material.color = Color.white;
    }
}
