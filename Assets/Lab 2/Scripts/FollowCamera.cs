using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;//позиц≥€ гравц€
    public Vector3 offset;//в≥дступ камери


    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset; 
    }
}
