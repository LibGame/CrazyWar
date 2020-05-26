using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Force;

    void Update()
    {
        if (this.transform.position.y + this.transform.position.y <= -150 || this.transform.position.y + this.transform.position.y >= 150
           || this.transform.position.x + this.transform.position.x <= -150 || this.transform.position.x + this.transform.position.x >= 150)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
