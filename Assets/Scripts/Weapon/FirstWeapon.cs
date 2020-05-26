using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FirstWeapon : MonoBehaviour
{
    public PhotonRigidbody2DView Bullet;
    public Transform bulletPos;
    public int Force;
    private Vector3 mousePos;
    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!photonView.IsMine) return;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var turn = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, mousePos - transform.position), Time.deltaTime * 30f);
        transform.rotation = turn;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bull = PhotonNetwork.Instantiate(Bullet.name, bulletPos.position, turn);
            bull.GetComponent<Rigidbody2D>().velocity = transform.up * 5f;
        }
    }
}
