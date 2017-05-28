	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class myNetworkManager : NetworkManager {


	// Use this for initialization
	void Start () {
		if (this.matchMaker == null)
			Debug.Log ("no matchmaker");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
