using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerView : MonoBehaviour
{
    public static bool hasBeenSeen { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameVisible()
    {
        hasBeenSeen = true;
    }

    private void OnBecameInvisible()
    {
        hasBeenSeen = false;
    }

}
