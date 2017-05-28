using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase.Database;
using Firebase;
using Firebase.Unity.Editor;
using UnityEngine.UI;

public class Register : MonoBehaviour
{

    DatabaseReference mDatabase;
	public InputField playername;
	public InputField password;
	public Button button;
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://test-d747c.firebaseio.com/");
		button = gameObject.GetComponent<Button> ();

        // Get the root reference location of the database.
		mDatabase = FirebaseDatabase.DefaultInstance.RootReference;
		button.onClick.AddListener (OnClick);
        
    }
	void OnClick(){
		RegisNewPlayer (playername.text, password.text);
	}
    public void RegisNewPlayer(string playerName, string password)
    {
        // Create new entry at /user-scores/$userid/$scoreid and at
        // /leaderboard/$scoreid simultaneously

        FirebaseDatabase.DefaultInstance
            .GetReference("Player").Child(playerName)
            .GetValueAsync().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Debug.Log("Error");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    if (snapshot.Value == null)
                    {
                        Stat playerStat = new Stat(1, 0, 0);
                        Player player = new Player(playerName, password, playerStat);
                        string json = JsonUtility.ToJson(player);
                        mDatabase.Child("Player").Child(playerName).SetRawJsonValueAsync(json);
                        json = JsonUtility.ToJson(playerStat);
                        mDatabase.Child("Player").Child(playerName).Child("playerStat").SetRawJsonValueAsync(json);
                    }
                    else
                    {
                        Debug.Log("This ID Already used");
                    }
                }

            });

    }

}
public class Player
{
    public string ID;
    public string password;
    public Stat playerstat;
    public Player(string ID, string password, Stat playerstat)
    {
        this.ID = ID;
        this.password = password;
        this.playerstat = playerstat;
    }
}
public class Stat
{
    public int level;
    public int win;
    public int lose;

    public Stat(int level, int lose, int win)
    {
        this.win = win;
        this.lose = lose;
        this.level = level;
    }
}
