using Assets.Scripts.GameStates;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject prizePrefab;

    // Абсциссы (X) финишируемых котов.
    private List<float> finishedKittenAbscissae = new List<float>();
    private int stopedCount = 0;

    private GameContext context;

    void Start()
    {
        context = new GameContext { State = new GamePrepareState() };

        Messenger<Transform>.AddListener(GameEvents.KittenFinished, OnKittenFinishedEvent);
        Messenger.AddListener(GameEvents.KittenStoped, OnKittenStopedEvent);
    }

    void Update()
    {
        context.Request();
    }

    private void OnKittenFinishedEvent(Transform obj)
    {
        finishedKittenAbscissae.Add(obj.transform.position.x);
    }

    private void OnKittenStopedEvent()
    {
        stopedCount++;

        if (stopedCount == 3)
        {
            float scale = 8;
            foreach (var x in finishedKittenAbscissae)
            {
                GameObject p = Instantiate(prizePrefab) as GameObject;
                p.transform.position = new Vector3(x, 15, 152);
                p.transform.localScale = new Vector3(scale, scale, scale);
                scale -= 2;
            }            
        }
    }

    void OnDestroy()
    {
        Messenger<Transform>.RemoveListener(GameEvents.KittenFinished, OnKittenFinishedEvent);
        Messenger.RemoveListener(GameEvents.KittenStoped, OnKittenStopedEvent);
    }
}