using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyDollController : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 playerPosition;
    //[SerializeField] Transform neckPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.position.x, 0, player.position.z);
        transform.LookAt(playerPosition);
    }
}
