using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text killsText;
    [SerializeField] private TMP_Text gameOverText;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (player != null)
        {
            hpText.text = "HP: " + player.Health;
        }

        if (gameManager != null)
        {
            killsText.text = "Kills: " + gameManager.EnemiesKilled;
        }

        if (player != null && !player.gameObject.activeSelf)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
}