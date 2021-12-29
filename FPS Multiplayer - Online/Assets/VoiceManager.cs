using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.PUN;
using UnityEngine;
using UnityEngine.UI;


public class VoiceManager : MonoBehaviour
{
   
    private Button pushToTalkPrivateButton;
   
    private Text buttonText;
    
    public byte AudioGroup;
    public bool Subscribed;

    private void Start()
    {
        //pttScript = FindObjectOfType<PushToTalkScript>();
        PhotonVoiceNetwork.Instance.Client.OnStateChangeAction += OnVoiceClientStateChanged;
    }


    private void OnVoiceClientStateChanged(ClientState state)
    {

        Debug.LogFormat("VoiceClientState={0}", state);
        if (pushToTalkPrivateButton != null)
        {
            switch (state)
            {
                case ClientState.Joined:
                    pushToTalkPrivateButton.gameObject.SetActive(true);
                    Subscribed = Subscribed || PhotonVoiceNetwork.Instance.Client.OpChangeGroups(null, new byte[1] { AudioGroup });
                    Debug.Log("Voice channel opened");
                    break;
                default:
                    pushToTalkPrivateButton.gameObject.SetActive(false);
                    break;
            }
        }
    }

  

    public void PushToTalkOn()
    {
        if (Subscribed)
        {
            PhotonVoiceNetwork.Instance.Client.GlobalInterestGroup = AudioGroup;
           
        }
    }

    public void PushToTalkOff()
    {
       
    }
}
