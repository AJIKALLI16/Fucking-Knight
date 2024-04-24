using UnityEngine;

public class Camera_on_player : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -30f);
    }
}
