﻿using UnityEngine;
using System.Collections;

public class WaypointTriggerLinear : MonoBehaviour {
	public GameObject nextWaypoint;
    public GameObject mapShadow;
	
	
	// Use this for initialization
	void Start () {
		this.GetComponent<Collider>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
        //check if the colliding object is the player
		if (other.tag == "Player" && nextWaypoint != null) {

			other.GetComponent<Player>().setWaypoint(nextWaypoint);
			this.GetComponent<Collider>().enabled = false; // make sure we don't continually hit this trigger

            mapShadow.GetComponent<Renderer>().enabled = false; // Hide the shadow on the map view
        }
    }

	void OnTriggerStay(Collider other) {
		Debug.Log("waypoint on trigger stay");
		if (other.tag == "Monster") {
			other.GetComponent<MonsterAI> ().changeHeadingLinear(nextWaypoint);
		}
	}
}
