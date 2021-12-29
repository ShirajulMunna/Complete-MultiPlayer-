using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using System.Linq;




public class ConnectedToServer : MonoBehaviourPunCallbacks
{
    public static ConnectedToServer Instance;

    void Awake()
    {
        Instance = this;
        
        
    }

    public InputField createTxt;
    public Text errorText;
    public Text roomNameText;
    public GameObject roomListItemPrefab;
    public Transform roomListContent;
    public Transform playerListContent;
    public GameObject playerListPrefab;
    public GameObject startgameButton;
    public bool offlineMode = false;



    public void Start()
    {

        Debug.Log("Connecting To Server");
        PhotonNetwork.ConnectUsingSettings();

 
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        MenuManager.Instance.OpenMenu("title");
        PhotonNetwork.NickName = "Player " + " " + Random.Range(0, 100).ToString("000");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(createTxt.text))
        {
            return;
        }
      
        PhotonNetwork.CreateRoom(createTxt.text);
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        MenuManager.Instance.OpenMenu("roommenu");

        Player[] players = PhotonNetwork.PlayerList;

        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListPrefab, playerListContent).GetComponent<PlayerList>().SetupPlayerName(players[i]);
        }

        startgameButton.SetActive(PhotonNetwork.IsMasterClient);

       


    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startgameButton.SetActive(PhotonNetwork.IsMasterClient); 
    }

    public void joinedRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("loading");


    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed: " + message;
        MenuManager.Instance.OpenMenu("errormenu");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(roomListItemPrefab,roomListContent).GetComponent<RoomListItem>().Setup(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListPrefab, playerListContent).GetComponent<PlayerList>().SetupPlayerName(newPlayer);
    }

}
