using System.Collections;
using System.Collections.Generic;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ProfiterBackendSocketIO : MonoBehaviour {
    public static string user = "{ \"user\":{ \"email\":\"csabhimanyu@gmail.com\",\"name\":\"Abhimanyu\"}}";

    public static void socketConnectionReceiver()
    {
        var socket = IO.Socket("http://97.74.233.60:3008").Emit("join", user);
        

        socket.On("notify_user", (data) =>
        {
            Debug.Log(data);
        });
        socket.On("notify_users", (data) =>
        {
            Debug.Log(data);
        });

        socket.On("send_data_to_game", (data) =>
        {
            Debug.Log(data);
        });
        socket.On("end_game", (data) =>
        {
            Debug.Log(data);
            socket.Off();
        });
    }
    // Use this for initialization
    void Start () {
        //To be updated to take the user name and password from the user during game setup and that should be updated here.
        //socketConnectionReceiver();
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
