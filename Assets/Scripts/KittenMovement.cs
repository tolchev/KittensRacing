using System;
using Assets.Scripts.KittenStates;
using UnityEngine;
using Assets.Scripts.MovementModels;

[RequireComponent(typeof(CharacterController))]
public class KittenMovement : MonoBehaviour
{
    public StartMode startMode = StartMode.Stand;
    public float firstSpeed = 15;
    public float negativeDeltaSpeed = 2;
    public float positiveDeltaSpeed = -2;
    public int fullSeconds = 18;

    KittenContext context;

    void Start()
    {
        KittenState state;
        
        switch (startMode)
        {
            case StartMode.Sit:
                state = new KittenPrepareSitState();
                break;
            case StartMode.Ithcing:
                state = new KittenPrepareIthcingState();
                break;
            default:
                state = new KittenPrepareStandState();
                break;
        }

        var charController = GetComponent<CharacterController>();
        var animator = GetComponent<Animator>();
        var movementModel = new RandomLineMovementModel(firstSpeed, negativeDeltaSpeed, positiveDeltaSpeed, fullSeconds);
        context = new KittenContext(state, charController, animator, movementModel, name);
    }

    void Update()
    {
        context.Request();
    }
}