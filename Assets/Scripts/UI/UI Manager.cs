using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    private HealthSystem playerHealth;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject endScreen;

    // Start is called before the first frame update
    private void Start()
    {
        playerHealth = PlayerInput.Instance.GetComponent<HealthSystem>();
        playerHealth.OnLifeChange += UpdateHealthText;
        playerHealth.onDead += DisplayDeathScreen;
    }

    void DisplayDeathScreen()
    {
        deathScreen.SetActive(true);
        gameplayUI.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
    }

    public void DisplayEndScreen()
    { 
        endScreen.SetActive(true);
        gameplayUI.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void UpdateHealthText(float healthToDisplay)
    {
        healthText.text = "Health " + healthToDisplay; 
    }
}
