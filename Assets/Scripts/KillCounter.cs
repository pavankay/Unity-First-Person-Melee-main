using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public static KillCounter instance; // Singleton instance
    public TextMeshProUGUI killCounterText;
    public int killCount = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set the instance to this KillCounter object
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    public void UpdateKillCount()
    {
        killCounterText.text = "Kills: " + killCount;
    }
}
