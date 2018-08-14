using System.Collections;
using System.Collections.Generic;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ProfiterBackendSocketIO
{
    public static string user = "{ \"user\":{ \"email\":\"csabhimanyu@gmail.com\",\"name\":\"Abhimanyu\"}}";
    public static Quobject.EngineIoClientDotNet.ComponentEmitter.Emitter socketEmitter;
    public static void socketConnectionReceiver()
    {
        socketEmitter = IO.Socket("http://97.74.233.60:3008").Emit("join", user);


        socketEmitter.On("notify_user", (data) =>
        {
            Debug.Log(data);
        });
        socketEmitter.On("notify_users", (data) =>
        {
            Debug.Log(data);
        });

        socketEmitter.On("send_game_init_data", (data) =>
        {
            /*
             *Code for Dijkstra init with connected roads and also waypoints
             *
             */
            Debug.Log(data);
        });

        socketEmitter.On("send_spcial_event_data", (data) =>
        {
            /*
             *Code for special events
             *
             */
            Debug.Log(data);
        });

        socketEmitter.Emit("user_score", "UserScore");
        socketEmitter.Emit("card_selection", "cardSelection");


        socketEmitter.On("send_data_to_game", (data) =>
        {
            Debug.Log(data);
        });
        socketEmitter.On("end_game", (data) =>
        {
            Debug.Log(data);
            socketEmitter.Off();
        });
    }
    // Use this for initialization
    void Start()
    {
        //To be updated to take the user name and password from the user during game setup and that should be updated here.
        socketConnectionReceiver();
    }


    // Update is called once per frame
    void Update()
    {
        //socketConnectionReceiver();

    }
}
