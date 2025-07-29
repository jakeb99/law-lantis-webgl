using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MessageData
{
    public string type;
    public string data;
}

public class JavascriptHook : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SendMessageToReact(string message);

    [DllImport("__Internal")]
    private static extern void InitializeReactListener();

    void Start()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            InitializeReactListener();
        #endif

        DontDestroyOnLoad(this);
    }

    // Call this method to send a message to React
    public void SendToReact(string message)
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            SendMessageToReact(message);
        #endif

        Debug.Log("Sent to React: " + message);
    }

    // This method will be called automatically when React sends a message
    public void ReceiveFromReact(string message)
    {
        Debug.Log("Received from React: " + message);

        // Handle your incoming messages here
        try
        {
            MessageData data = JsonUtility.FromJson<MessageData>(message);
            Debug.Log($"Parsed JSON - type: {data.type}, data: {data.data}");
            HandleJsonMessage(data);
        } catch
        {
            // reg string msg
            // It's a regular string message
            Debug.Log("String message: " + message);
            HandleStringMessage(message);
        }
    }

    private void HandleJsonMessage(MessageData data)
    {
        switch (data.type)
        {
            case "LOAD_SCENE":
                Debug.Log($"Scene Name: {data.data}");
                SceneManager.LoadScene(data.data); 
                break;
            default:
                Debug.Log("Unknown JSON message type: " + data.type);
                break;
        }
    }

    private void HandleStringMessage(string message)
    {

    }
}
