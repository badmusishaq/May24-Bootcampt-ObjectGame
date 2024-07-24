using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text txtHealth;
    [SerializeField] private TMP_Text txtScore;
    [SerializeField] private Player player;


    // Start is called before the first frame update
    void Start()
    {
        //Subscribe to the method
        player.health.OnHealthUpdate += UpdateHealth;
    }

    private void OnDisable()
    {
        //Unsubcribe form the action
        player.health.OnHealthUpdate -= UpdateHealth;
    }

    public void UpdateHealth(float currentHealth)
    {
        txtHealth.SetText(currentHealth.ToString());
    }

    public void UpdateScore()
    {
        txtScore.SetText(GameManager.GetInstance().scoreManager.GetScore().ToString());
    }
}
