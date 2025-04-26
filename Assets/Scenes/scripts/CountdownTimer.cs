using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Mathematics;

public class CountdownTimer : MonoBehaviour
{
    
   public float timeRemaining = 15f;
    public TextMeshProUGUI timerText;
    public string winSceneName;

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        timeRemaining -= Time.deltaTime;

        if (timerText != null)
            timerText.text = math.ceil(timeRemaining).ToString();

        if (timeRemaining <= 0f)
        {
            gameEnded = true;
            Win();
        }
    }

    void Win()
    {
        gameEnded = true;
        SceneManager.LoadScene(winSceneName);
    }

}