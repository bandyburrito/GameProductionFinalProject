using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class RestartButton : MonoBehaviour
{

    public Button restart;


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DontDestroyOnLoad(gameObject);
    }

    
    public void TaskOnClick()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
