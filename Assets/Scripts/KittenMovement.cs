
using Assets.Scripts.KittenStates;
using UnityEngine;
using Assets.Scripts.MovementModels;

[RequireComponent(typeof(CharacterController))]
public class KittenMovement : MonoBehaviour
{
    public float firstSpeed = 15;
    public float deltaSpeed = 2;

    KittenContext context;

    void Start()
    {
        KittenState state = KittenFirstStateFactory.Create();

        var charController = GetComponent<CharacterController>();
        var animator = GetComponent<Animator>();

        // Общую анимацию начнем по разному.
        if (state.GetType() == typeof(KittenPrepareStandState))
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            animator.Play(stateInfo.fullPathHash, -1, Random.Range(0f, 1f));
        }

        RandomLerpMovementParam param = new RandomLerpMovementParam
        {
            speed0 = Random.Range(firstSpeed - Mathf.Abs(deltaSpeed), firstSpeed + Mathf.Abs(deltaSpeed)),
            speed1 = Random.Range(firstSpeed - Mathf.Abs(deltaSpeed), firstSpeed + Mathf.Abs(deltaSpeed)),
            startPos = -130,
            changePos = Random.Range(-110, 110),
            finishPos = 130,
            decelerationEndPos = 140
        };
        var movementModel = new RandomLerpMovementModel(param);
        context = new KittenContext(state, charController, animator, movementModel, name);
        Debug.LogFormat("{0}: {1}, resultTime: {2}", name, param, param.GetResultTime());
    }

    void Update()
    {
        context.Request();
    }
}