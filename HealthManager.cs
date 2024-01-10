using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthManager : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public GameObject healthCanvas;
    TextMeshProUGUI healthText; 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthText = healthCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthText.text = "Health: " + currentHealth.ToString();

        if (currentHealth <= 0)
        {
            healthText.text = "DEAD";
        }
    }
}
