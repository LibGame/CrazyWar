using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int Speed;
    private bool _isRight = true;
    private PhotonView photonView;
    public Text textName;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    public Text SetText()
    {
        return textName;
    }

    private void Update()
    {

        if (!photonView.IsMine) return;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }

        float moveX = Input.GetAxis("Horizontal");

        if (moveX > 0 && !_isRight)
            Flip();
        else if (moveX < 0 && _isRight)
            Flip();

        Vector3 cameraToObject = transform.position - Camera.main.transform.position;
        // отрицание потому что игровые объекты в данном случае находятся ниже камеры по оси y
        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).y;

        // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        float x_left = leftBot.x + 0.5f;
        float x_right = rightTop.x - 0.5f;
        float y_top = rightTop.y -1.2f;
        float y_bot = leftBot.y + 1.4f;

        // ограничиваем объект в плоскости XZ
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        clampedPos.y = Mathf.Clamp(clampedPos.y, y_bot, y_top);
        transform.position = clampedPos;
    }

    private void Flip()
    {
        _isRight = !_isRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
