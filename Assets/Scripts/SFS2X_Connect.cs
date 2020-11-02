using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Requests;
using Sfs2X.Entities;

public class SFS2X_Connect : MonoBehaviour
{
    public string ServerIp="127.0.0.1";
    public int ServerPort=9933;
    public static SmartFox sfs;
    public string ZoneName="BasicExamples";
    public string userName="";
    public string RoomName="New";
    public string roomPassword="123";
    public static User user;
    // Start is called before the first frame update
    void Start()
    {
        sfs=new SmartFox();
        sfs.ThreadSafeMode=true;    

        sfs.AddEventListener(SFSEvent.CONNECTION,OnConnection);
        sfs.AddEventListener(SFSEvent.LOGIN,OnLogin);
        sfs.AddEventListener(SFSEvent.LOGIN_ERROR,OnLoginError);
        // sfs.AddEventListener(SFSEvent.ROOM_JOIN,OnJoinRoom);
        // sfs.AddEventListener(SFSEvent.ROOM_JOIN_ERROR,OnJoinRoomError);
        // sfs.AddEventListener(SFSEvent.PUBLIC_MESSAGE,OnPublicMessage);

        sfs.Connect(ServerIp,ServerPort);
    }
    void OnConnection(BaseEvent b){
        if((bool)b.Params["success"]){
            Debug.Log("Successfully Connected");
            sfs.Send(new LoginRequest(userName,"",ZoneName));
        }
        else
            Debug.Log("Connection Failed");
    }

    void OnLogin(BaseEvent b){
        Debug.Log("Logged In :"+b.Params["user"]);
        user=(User)b.Params["user"];
        // sfs.Send(new JoinRoomRequest(RoomName,roomPassword));
    }
    void OnLoginError(BaseEvent e){
        Debug.Log("Login Error ("+e.Params["errorCode"]+") "+e.Params["errorMessage"]);
    }

    // void OnJoinRoom(BaseEvent b){
    //     Debug.Log("Joined Room: "+b.Params["room"]);
    //     sfs.Send(new PublicMessageRequest("Hello Wolrd"));
    // }
    // void OnJoinRoomError(BaseEvent e){
    //     Debug.Log("JoinRoom Error("+e.Params["errorCode"]+") "+e.Params["errorMessage"]);
    // }
    // void OnPublicMessage(BaseEvent e){
    //     Room room=(Room)e.Params["room"];
    //     User sender=(User)e.Params["sender"];
    //     Debug.Log("["+room.Name+"] "+sender.Name+": "+e.Params["message"]);
    // }
    // Update is called once per frame
    void Update()
    {
        sfs.ProcessEvents();        
    }
    void OnApplicationQuit(){
        if(sfs.IsConnected)
            sfs.Disconnect();
    }
}
