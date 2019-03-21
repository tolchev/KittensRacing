using Assets.Scripts.KittenStates;
using UnityEngine;

namespace Assets.Scripts.MovementModels
{
    class RandomLerpMovementModel : IMovementModel
    {
        enum State
        {
            None,
            Speed0,
            Speed1,
            Continue
        }

        readonly RandomLerpMovementParam param;
        bool isStarted;
        State state;

        float startTime;

        public float LastSpeed
        {
            get { return param.speed1; }
        }

        public RandomLerpMovementModel(RandomLerpMovementParam param)
        {
            this.param = param;
            isStarted = false;
            state = State.Speed0;
        }

        public float GetMove()
        {
            if (!isStarted)
            {
                isStarted = true;
                startTime = Time.time;
            }

            float move;
            switch (state)
            {
                case State.Speed0:
                    move = GetRunMove(param.speed0, param.startPos, param.changePos);
                    if (move == param.changePos)
                    {
                        startTime = Time.time;
                        state = State.Speed1;
                    }
                    return move;
                case State.Speed1:
                    move = GetRunMove(param.speed1, param.changePos, param.finishPos);
                    if (move == param.finishPos)
                    {
                        startTime = Time.time;
                        state = State.Continue;
                    }
                    return move;
                case State.Continue:
                    // Просто продолжаем с той же скоростью, контекст котов сам переключит состояние.
                    move = GetRunMove(param.speed1, param.finishPos, param.decelerationEndPos);
                    if (move == param.decelerationEndPos)
                    {
                         state = State.None;
                    }
                    return move;
                default:
                    return param.decelerationEndPos;
            }
        }

        private float GetRunMove(float speed, float start, float end)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / (end - start);
            return Mathf.Lerp(start, end, fracJourney);
        }
    }
}