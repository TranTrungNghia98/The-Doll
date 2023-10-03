using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    [SerializeField] GameObject doorModel;
    [SerializeField] PlayerItemHandle playerItemHandle;
    [SerializeField] GameObject doorNotification;
    [SerializeField] TextMeshProUGUI doorNotificationText;
    [SerializeField] float requiredMoneyBags;
    private Animator doorModelAnimator;
    // Start is called before the first frame update
    void Start()
    {
        doorModelAnimator = doorModel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Open The Door when player collide with the door and the door are not opening
        if (other.gameObject.CompareTag("Player"))
        {
            // Only Open Door when player have required money bags
            int pickedUpMoneyBag = playerItemHandle.pickedUpMoneyBag;
            if (pickedUpMoneyBag >= requiredMoneyBags)
            {
                doorModelAnimator.SetTrigger("openDoor");
                doorNotificationText.SetText("The doll will follow you. If you don't look at it on this room");
                doorNotification.SetActive(true);
            }

            // If player doesn't have enough money bags required. Don't open the door and notification to find more bags
            else
            {
                doorNotificationText.SetText("You need to have " + requiredMoneyBags + " money bags to open this door.");
                doorNotification.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        // Close The Door when player collide with the door and the door are not closing
        if (other.gameObject.CompareTag("Player"))
        {
            // Hide Notification when player move out of the door
            doorNotification.SetActive(false);
            doorModelAnimator.SetTrigger("closeDoor");
        }
    }
}
