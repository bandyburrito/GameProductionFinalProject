using TreeEditor;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    private Vector2 turn;
    [SerializeField] public float MouseSensitivityX = 7;
    [SerializeField] public float MouseSensitivityY = 7;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * MouseSensitivityX;
        turn.y += Input.GetAxis("Mouse Y") * MouseSensitivityY;
        transform.eulerAngles = new Vector3(-turn.y, turn.x, 0);
        
        if (turn.y > 90)
        {
            turn.y = 90;
        }

        if (turn.y < -90)
        {
            turn.y = -90;
        }
        
    }
}
