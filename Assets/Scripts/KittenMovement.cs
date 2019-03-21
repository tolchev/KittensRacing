
using Assets.Scripts.KittenStates;
using UnityEngine;
using Assets.Scripts.MovementModels;

[RequireComponent(typeof(CharacterController))]
public class KittenMovement : MonoBehaviour
{
    public StartMode startMode = StartMode.Stand;
    public float firstSpeed = 15;
    public float negativeDeltaSpeed = 2;
    public float positiveDeltaSpeed = 2;

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

        RandomLerpMovementParam param = new RandomLerpMovementParam
        {
            speed0 = Random.Range(firstSpeed - Mathf.Abs(negativeDeltaSpeed), firstSpeed + Mathf.Abs(positiveDeltaSpeed)),
            speed1 = Random.Range(firstSpeed - Mathf.Abs(negativeDeltaSpeed), firstSpeed + Mathf.Abs(positiveDeltaSpeed)),
            startPos = -130,
            changePos = Random.Range(-110, 110),
            finishPos = 130,
            decelerationEndPos = 140
        };
        var movementModel = new RandomLerpMovementModel(param);
        context = new KittenContext(state, charController, animator, movementModel, name);
        Debug.LogFormat("{0} - {1} - {2}", name, param, param.GetResultTime());
    }

    void Update()
    {
        context.Request();
    }
}