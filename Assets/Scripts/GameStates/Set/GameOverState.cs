using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameStates
{
    class GameOverState : GameState
    {
        public override void Handle()
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("RacingScene");
            }
        }
    }
}