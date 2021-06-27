using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position+offset;
    }
}
