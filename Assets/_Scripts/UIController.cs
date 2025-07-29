using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI sceneNameText;
    public TextMeshProUGUI scoreText;

    

    private int score = 0;

    private void Awake()
    {
        sceneNameText.text = SceneManager.GetActiveScene().name;
    }

    public void OnScoreIncrease()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void OnScoreDecrease()
    {
        score--;
        scoreText.text = score.ToString();
    }

    public void SwitchSceneByName(String sceneName)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }

    public void SendHelloToJSMessage()
    {
        JavascriptHook jh = FindAnyObjectByType<JavascriptHook>();
        jh.SendToReact("HIHIHIHIHI");
    }

    //[DllImport("__Internal")]
    //private static extern void SendPointsToReact(int points);
}
