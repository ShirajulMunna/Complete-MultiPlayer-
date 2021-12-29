/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class TeamMasterClient : MonoBehaviour
{
    public static TeamMasterClient instance;
    public PhotonView photonView;
    public int myTeamNumber;
    public GameObject photonPlayer;



    public void Awake()
    {
        instance = this;

    }

    void Start()
    {

        if (photonView.IsMine)
        {
            photonView.RPC("RPC_GetTeam", RpcTarget.MasterClient);
        }

     
    }

    void Update()
    {
        if (photonPlayer == null && myTeamNumber != 0) 
        {

            if (myTeamNumber == 1)
            {
                if (photonView.IsMine) 
                {
                    Transform spawnPoint = TeamSpawnmanager.instance.GetSpawnPosition(0);
                    photonPlayer = PhotonNetwork.Instantiate(Path.Combine("Photonprefabs", "Player"), spawnPoint.position, spawnPoint.rotation);

                }
             
            }

            else
            {
                if (photonView.IsMine) 
                {
                    Transform spawnPoint = TeamSpawnmanager.instance.GetSpawnPosition(1);
                    photonPlayer = PhotonNetwork.Instantiate(Path.Combine("Photonprefabs", "SecondPlayer"), spawnPoint.position, spawnPoint.rotation);


                }


            }

        }
        
    }

    [PunRPC]
    void RPC_GetTeam()
    {
        myTeamNumber = TeamSelection.instance.selectedTeam;
        Debug.Log("my Team Number is " + myTeamNumber);
        TeamSelection.instance.UpdateTeamStatus(myTeamNumber);
        photonView.RPC("RPC_Sent", RpcTarget.OthersBuffered, myTeamNumber);


    }

    [PunRPC]
    void RPC_SentTeam(int whichTeam)
    {
        myTeamNumber = whichTeam;

    }
}
*/