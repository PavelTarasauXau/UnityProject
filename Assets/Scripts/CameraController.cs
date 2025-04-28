using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset; 

    void Start()
    {
        offset = transform.position - player.position;//calculated as a distance between player and camera
    }

    //new place for camera
    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        //camera wont move by x and y axes. In z parameter the sum of offset and player position
        transform.position = newPosition; //move camera to calculated position
    }
}