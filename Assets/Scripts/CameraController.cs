using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 zOffsett = new Vector3(0, 0, -10);

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z) + zOffsett;

    }
}
