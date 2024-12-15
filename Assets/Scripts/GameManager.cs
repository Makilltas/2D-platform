using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public Text coinCounterText; 
    private int coinCount = 0; 

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinCounter(); 
    }

    private void UpdateCoinCounter()
    {
        coinCounterText.text = "Gems: " + coinCount.ToString();
    }
}
