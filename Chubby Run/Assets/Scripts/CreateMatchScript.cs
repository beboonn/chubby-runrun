using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class CreateMatchScript : MonoBehaviour {

	// Use this for initialization

	public Button button;
	public GameObject network;
	public GameObject ServerMenu;
	public GameObject MrLogin;
	void Start () {
		button = gameObject.GetComponent<Button> ();
		button.onClick.AddListener (OnClick);
	}
	void OnClick(){
		network.SetActive (true);
		ServerMenu.SetActive (false);
		MrLogin.GetComponent<FireBaseScript> ().isPlayed = true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
