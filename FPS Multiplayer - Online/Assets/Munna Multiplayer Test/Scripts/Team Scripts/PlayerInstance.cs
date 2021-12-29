using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInstance : MonoBehaviour
{
    //static instance that is set to dont destroy so we dont get re-cloned when level reloads
    public static GameObject localPlayerInstance;
    PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            localPlayerInstance = gameObject;
        }
        //now dont destroy!!
        DontDestroyOnLoad(gameObject);
    }
}
