using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefs;
    public CameraController cameraController;
    private Text playerName;

    void Start()
    {
        var playerPref = PhotonNetwork.Instantiate(PlayerPrefs.name, new Vector2(Random.Range(-4, 4), Random.Range(-4, 4)), Quaternion.identity);
        cameraController.SetTarget(playerPref.transform);
        playerName = playerPref.GetComponent<PlayerController>().SetText();
        playerName.text = PhotonNetwork.LocalPlayer.NickName;

    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player entered room", newPlayer.NickName);
        print("is worked");
        
    }

}
