using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;
using Photon.Voice.PUN;

public class PlayerManager : MonoBehaviour
{
    PhotonView photonView;
    public byte audioGroup_one;
    public byte audioGroup_two;
  

    void Awake()
    {
        photonView = GetComponent<PhotonView>();

    }

    void Start()
    {

        if (photonView.IsMine)
        {
            CreateController();
        }
    }



    void CreateController()
    {
        if (PlayerInstance.localPlayerInstance == null)
        {
            //instantiate the correct player based on the team
            int team = (int)PhotonNetwork.LocalPlayer.CustomProperties["Team"];
            Debug.Log($"Team number {team} is being instantiated");
            //instantiate the blue player if team is 0 and red if it is not
            if (team == 0)
            {
                //get a spawn for the correct team
                Transform spawn = TeamSpawnmanager.instance.GetSpawnPosition(0);
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","Player"), spawn.position, spawn.rotation);
                PhotonVoiceNetwork.Instance.Client.GlobalInterestGroup = audioGroup_one;

            }
            else
            {
                //now for the red team
                Transform spawn = TeamSpawnmanager.instance.GetSpawnPosition(1);
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player_2"), spawn.position, spawn.rotation);
                PhotonVoiceNetwork.Instance.Client.GlobalInterestGroup = audioGroup_two;
            }

        }

    }

}
