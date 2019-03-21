using System;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    void Start()
    {
        Messenger<Transform>.AddListener(GameEvents.KittenPositionForCamera, OnEvent);
    }

    private void OnEvent(Transform obj)
    {
        if (transform.position.z < obj.transform.position.z)
        {
            transform.position = Vector3.forward * obj.transform.position.z;
        }
    }

    void OnDestroy()
    {
        Messenger<Transform>.RemoveListener(GameEvents.KittenPositionForCamera, OnEvent);
    }
}