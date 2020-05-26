using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47Weapon : MonoBehaviour
{

    public Rigidbody2D Bullet;
    public Transform bulletPos;
    public int Force;
    private Rigidbody2D rb;
    private Vector3 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var turn = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, mousePos - transform.position), Time.deltaTime * 30f);
        rb.MoveRotation(turn.eulerAngles.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bull = Instantiate(Bullet, bulletPos.position, turn);
            bull.velocity = bull.transform.up * Force;
        }
    }
}
