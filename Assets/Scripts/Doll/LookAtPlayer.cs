using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject dollModel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If hasn't been seen then look at player
        if (!CheckPlayerView.hasBeenSeen)
        {
            transform.LookAt(player.position, Vector3.up);
            dollModel.transform.localRotation = transform.localRotation;
        }

    }
}
