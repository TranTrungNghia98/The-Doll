using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRoomHandle : MonoBehaviour
{
    [SerializeField] GameObject doll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doll.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doll.SetActive(false);
        }
    }
}
