using Complete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.Manager.GameStates
{
    public class BaseGameState
    {
        protected Dictionary<System.Object, BaseState> _StateDico = new Dictionary<System.Object, BaseState>();

        public System.Object _currentState;
        public string _scene;

        public BaseGameState(string scene)
        {
            _scene = scene;
        }
        
        protected BaseState GetState<T>(T State)
        {
            return _StateDico[State];
        }
        
        public T GetCurrentState<T>()
        {
            return (T)_currentState;
        }

        public virtual void Enter()
        {
            SceneManager.LoadScene(_scene);
        }

        public virtual void Exit()
        {
            if (SceneManager.GetSceneByName(_scene).isLoaded)
                SceneManager.UnloadSceneAsync(_scene);
            
        }
        public virtual void UpdateState() { }
        public virtual void HandleInput() { }
        public virtual void PhysicUpdate() { }

        protected void ChangingState<T>(T NewState)
        {
            GetState(_currentState).Exit();
            _currentState = NewState;
            GetState(NewState).Enter();
        }

    }
}
