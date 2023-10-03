using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyBagsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMoneyBagUI(int pickedMoneyBags)
    {
        moneyBagsText.text = "Money Bags: " + pickedMoneyBags + " / 6";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
