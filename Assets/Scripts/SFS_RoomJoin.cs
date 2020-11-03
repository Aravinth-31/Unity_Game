using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Requests;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;

public class SFS_RoomJoin : MonoBehaviour
{
    public string RoomName="Rummy";
    public string roomPassword="";
    SmartFox sfs;

    // Start is called before the first frame update
    void Start()
    {
        sfs=SFS2X_Connect.sfs;
        Debug.Log(sfs);
        if(sfs!=null){
            sfs.AddEventListener(SFSEvent.ROOM_JOIN,OnJoinRoom);
            sfs.AddEventListener(SFSEvent.ROOM_JOIN_ERROR,OnJoinRoomError);
            sfs.AddEventListener(SFSEvent.PUBLIC_MESSAGE,OnPublicMessage);
            sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE,OnExtensionResponse);

            sfs.Send(new JoinRoomRequest(RoomName,roomPassword));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(sfs!=null)
            sfs.ProcessEvents();        
    }

    void OnJoinRoom(BaseEvent b){
        // sfs.Send(new PublicMessageRequest("Hello Wolrd"));
        Debug.Log("Joined Room: "+b.Params["room"]);
        Room room=(Room)b.Params["room"];

        List<string> deck=Solitaire.deck;
        User user=SFS2X_Connect.user;
        ISFSObject objOut=new SFSObject();
        objOut.PutInt("userId",user.Id);
        objOut.PutInt("roomId",room.Id);
        for(int i=0;i<4;i++){
            objOut.PutInt("card"+i.ToString(),Solitaire.UpdatePoint(deck[i].Substring(1,deck[i].Length-1)));
        }
        sfs.Send(new ExtensionRequest("OnJoinRoom",objOut));
    }
    void OnExtensionResponse(BaseEvent b){
        string cmd=(string)b.Params["cmd"];
        ISFSObject objIn=(SFSObject)b.Params["params"];
        if(cmd=="OnJoinRoom"){
            Debug.Log(objIn);
        }
    }

    void OnJoinRoomError(BaseEvent e){
        Debug.Log("JoinRoom Error("+e.Params["errorCode"]+") "+e.Params["errorMessage"]);
    }
    void OnPublicMessage(BaseEvent e){
        Room room=(Room)e.Params["room"];
        User sender=(User)e.Params["sender"];
        Debug.Log("["+room.Name+"] "+sender.Name+": "+e.Params["message"]);
    }
}
