using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject Box1;
    public GameObject Box2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Destroy(Box1);
            Destroy(Box2);
        }
    }
}
