using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform Player;
    void Start()
    {
        Player = GameManager.instance.PlayerCameraPosition;
        transform.LookAt(Player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 3 * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
