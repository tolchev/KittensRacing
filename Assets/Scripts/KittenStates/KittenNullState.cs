using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.KittenStates
{
    class KittenNullState : KittenState
    {
        public override void Handle(KittenContext context)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("RacingScene");
            }
        }
    }
}