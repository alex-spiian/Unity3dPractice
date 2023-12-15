using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.SceneController
{
    public class SceneController : MonoBehaviour
    {
        public void LoadLobbyScene()
        {
            SceneManager.LoadScene(GlobalConstants.LOBBY_SCENE_NAME);
        }

        public void LoadSelectHeroScene()
        {
            SceneManager.LoadScene(GlobalConstants.SELECT_HERO_SCENE_NAME);
        }
    }
}