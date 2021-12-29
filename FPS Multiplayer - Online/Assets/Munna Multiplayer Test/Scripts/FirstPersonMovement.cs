using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FirstPersonMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 25f;
    PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
        
    }

    void Start()
    {
        if (!photonView.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }

       
    }

    void Update()
    {
        if (!photonView.IsMine) 
        {
            return;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }

   

    
}
