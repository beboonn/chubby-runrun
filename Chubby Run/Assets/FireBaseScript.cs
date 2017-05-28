using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseScript : MonoBehaviour {

	public string playername;
	public bool isLogin;
	public bool isPlayed;
	public GameObject LoginMenu;
	public GameObject ServerMenu;
	public GameObject Network;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		isLogin = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayed) {
			Network.SetActive (true);
			ServerMenu.SetActive (false);
		}
		else if (isLogin) {
			ServerMenu.SetActive (true);
			Network.SetActive (false);
			LoginMenu.SetActive (false);
		} else {
			LoginMenu.SetActive (true);
		}
	}
}
