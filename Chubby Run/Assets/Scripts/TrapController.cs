using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

	// Use this for initialization
	public float timeleft;
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
	void OnCollisionEnter(Collision c){
		ChubbyBoyController hitter = c.gameObject.GetComponent<ChubbyBoyController> ();
		if (hitter != null)
			hitter.isDeath = 1;
	}
}
