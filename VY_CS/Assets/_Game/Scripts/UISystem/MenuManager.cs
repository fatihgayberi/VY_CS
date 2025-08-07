using UnityEngine;

namespace VY_CS.UISystem
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject inGamePanel;
        [SerializeField] private GameObject mainMenuPanel;

        public void StartButton()
        {
            mainMenuPanel.SetActive(false);
            inGamePanel.SetActive(true);
            GameManager.Instance.UpdateGameState(GameState.START);
        }

        public void BackButton()
        {
            mainMenuPanel.SetActive(true);
            inGamePanel.SetActive(false);
            GameManager.Instance.UpdateGameState(GameState.EXIT);
        }
    }
}