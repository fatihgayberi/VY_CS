using System;
using UnityEngine;
using Wonnasmith.Singleton;

namespace VY_CS
{
    public class GameManager : Singleton<GameManager>
    {
        public Action GamePlaying;
        public Action GameStart;
        public Action GameExit;

        private GameState _currentGameState = GameState.NONE;

        public bool IsPlaying => _currentGameState == GameState.PLAYING;

        public void UpdateGameState(GameState newGameState)
        {
            if (_currentGameState == newGameState) return;


            if (newGameState == GameState.START)
            {
                _currentGameState = GameState.START;
                Debug.Log("_currentGameState" + _currentGameState);
                GameStart?.Invoke();
                
                _currentGameState = GameState.PLAYING;
                Debug.Log("_currentGameState" + _currentGameState);
                GamePlaying?.Invoke();
            }
            else if (newGameState == GameState.EXIT)
            {
                _currentGameState = GameState.EXIT;
                Debug.Log("_currentGameState" + _currentGameState);
                GameExit?.Invoke();

                _currentGameState = GameState.NONE;
                Debug.Log("_currentGameState" + _currentGameState);
            }
        }
    }
}