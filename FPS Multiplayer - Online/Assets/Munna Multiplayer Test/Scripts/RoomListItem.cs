using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour
{
    public Text infoText;
    public RoomInfo info;

    public void Setup(RoomInfo _info)
    {
        info = _info;

        infoText.text = _info.Name;
    }

    public void OnClick()
    {
        ConnectedToServer.Instance.joinedRoom(info);
    }
}
