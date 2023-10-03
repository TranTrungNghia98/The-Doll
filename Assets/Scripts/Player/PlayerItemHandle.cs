using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHandle : MonoBehaviour
{
    public int maxMoneyBag {get; private set;}
    public int pickedUpMoneyBag { get; private set; }

    [SerializeField] GameObject doll;
    [SerializeField] GameObject youWin;

    [SerializeField] MainUIHandle mainUIHandleScript;
    // Start is called before the first frame update
    void Start()
    {
        maxMoneyBag = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUpMoneyBag == maxMoneyBag)
        {
            Destroy(doll);
            youWin.SetActive(true);
            DisplayMouse();
            Destroy(gameObject);
        }
    }


    void DisplayMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
