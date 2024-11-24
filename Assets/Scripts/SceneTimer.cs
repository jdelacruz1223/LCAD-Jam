using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class SceneTimer : MonoBehaviour
{
    [SerializeField] private float timeLimit = 90f; 
    private float remainingTime;

    [SerializeField] private Text timerText; // Optional: Link a UI Text element to display the timer

    void Start()
    {
        remainingTime = timeLimit;
    }

    void Update()
    {
        
        remainingTime -= Time.deltaTime;
        
        if (timerText != null) timerText.text = Mathf.Ceil(remainingTime).ToString();
        
        if (remainingTime <= 0) OnTimeUp();
 
    }

    private void OnTimeUp()
    {
        Debug.Log("Time up");

        SceneManager.LoadScene("EndGame");

    }
}