using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightGreenLight : MonoBehaviour
{
    [SerializeField] Transform player;
    private AudioSource audioSource;
    private float redLightTime = 5.0f;

    private Vector3 currentPlayerPosition;
    private bool isRedLight;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        StartCoroutine(WaitGreenLightEnd());
    }

    // Update is called once per frame
    void Update()
    {
        if (isRedLight)
        {
            CheckPlayerMovement();
        }
    }

    // Red Light Handle
    void ChangeToRedLight()
    {
        Debug.Log("Change to red light. Player can't move");
        // Turn to red light
        isRedLight = true;
        // Turn Back and Get player Position
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        currentPlayerPosition = player.position;
        // Wait Red Light End and Change To Green Light
        StartCoroutine(WaitRedLightEnd());
    }

    void CheckPlayerMovement()
    {
        if (currentPlayerPosition != player.position)
        {
            Debug.Log("Player have moved when red light");
        }
    }

    // The Red Light Turn On When The Doll Turn Back and Check Player Movement
    IEnumerator WaitRedLightEnd()
    {
        yield return new WaitForSeconds(redLightTime);
        ChangeToGreenLight();
    }

    // Green Light Handle
    void ChangeToGreenLight()
    {
        Debug.Log("Change To Green Light. Player can move");
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        // Wait Green Light End And Change To Red Light
        StartCoroutine(WaitGreenLightEnd());
    }

    // The Green Light Turn On when the doll is counting
    IEnumerator WaitGreenLightEnd()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        ChangeToRedLight();
    }

}
