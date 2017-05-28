using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase.Database;
using Firebase;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : MonoBehaviour {
    DatabaseReference mDatabase;
    public InputField playername;
    public InputField password;
	public Button button;
	public GameObject LoginMenu;
	public GameObject ServerMenu;
	public GameObject MrLogin;
	public Text name;
    // Use this for initialization
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://test-d747c.firebaseio.com/");
		button = gameObject.GetComponent<Button> ();
        // Get the root reference location of the database.
        mDatabase = FirebaseDatabase.DefaultInstance.RootReference;
		button.onClick.AddListener (OnClick);
        
    }

    void OnClick()
    {
        Loginn(playername.text, password.text);
    }

    public void Loginn(string playerName, string password)
    {
        // Check Login and password

        FirebaseDatabase.DefaultInstance
            .GetReference("Player").Child(playerName)
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("Error");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    if (snapshot.Value == null)
                    {
                        Debug.Log("This ID is not exist");
                    }
                    else
                    {
                        var stat = snapshot.Value as Dictionary<string, object>;
                        foreach (var item in stat)
                        {
                            if (item.Key == "password")
                            {
                                if (item.Value.ToString() != password)
                                {
                                    Debug.Log("Wrong password");
                                }
                                else
                                {
										MrLogin.GetComponent<FireBaseScript>().playername = playerName;
										MrLogin.GetComponent<FireBaseScript>().isLogin = true;
										name.text = playerName;
										Debug.Log("Success");
										ServerMenu.SetActive(true);
										LoginMenu.SetActive(false);
                                }
                            }

                        }
                    }

                }
            });

    }
}
