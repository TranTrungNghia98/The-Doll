using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHandle : MonoBehaviour
{
    public int maxMoneyBag {get; private set;}
    public int pickedUpMoneyBag { get; private set; }

    [SerializeField] MainUIHandle mainUIHandleScript;
    // Start is called before the first frame update
    void Start()
    {
        maxMoneyBag = 9;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money Bag"))
        {
            Destroy(other.gameObject);
            pickedUpMoneyBag++;
            mainUIHandleScript.UpdateMoneyBagUI(pickedUpMoneyBag);
        }
    }
}
