using UnityEngine;

namespace Assets.Scripts.KittenStates
{
    static class KittenFirstStateFactory
    {
        static bool specialStateIsCreated = false;

        static KittenFirstStateFactory()
        {
            Messenger.AddListener(GameEvents.GameOver, OnGameOver);
        }

        public static KittenPrepareState Create()
        {
            if (!specialStateIsCreated)
            {
                switch (Random.Range(0, 10))
                {
                    case 0:
                        specialStateIsCreated = true;
                        return new KittenPrepareSitState();
                    case 1:
                        specialStateIsCreated = true;
                        return new KittenPrepareIthcingState();
                }
            }

            return new KittenPrepareStandState();
        }

        private static void OnGameOver()
        {
            specialStateIsCreated = false;
        }
    }
}