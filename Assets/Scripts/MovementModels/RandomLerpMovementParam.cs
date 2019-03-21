using System;

namespace Assets.Scripts.MovementModels
{
    class RandomLerpMovementParam
    {
        /// <summary>
        /// Начальная скорость.
        /// </summary>
        public float speed0;
        /// <summary>
        /// Скорость после прохождения точки changePos.
        /// </summary>
        public float speed1;

        /// <summary>
        /// Стартовая точка.
        /// </summary>
        public float startPos;
        /// <summary>
        /// Точка, после которой происходит изменение скорости.
        /// </summary>
        public float changePos;
        /// <summary>
        /// Точка финиша.
        /// </summary>
        public float finishPos;
        /// <summary>
        /// Точка до которой происходит замедление.
        /// </summary>
        public float decelerationEndPos;

        public override string ToString()
        {
            return string.Format("speed0: {0}, speed1: {1}, changePos: {2}", speed0, speed1, changePos);
        }

        public float GetResultTime()
        {
            return (changePos - startPos) / speed0 + (finishPos - changePos) / speed1;
        }
    }
}