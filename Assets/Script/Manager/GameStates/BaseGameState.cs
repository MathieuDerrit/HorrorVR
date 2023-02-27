using Complete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static MainMenuManager;

namespace Assets.Script.Manager.GameStates
{
    public class BaseGameState
    {
        protected Dictionary<System.Object, BaseState> _StateDico = new Dictionary<System.Object, BaseState>();

        public object _currentState;

        protected BaseState GetState<T>(T State)
        {
            return _StateDico[State];
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void UpdateState() { }
        public virtual void HandleInput() { }
        public virtual void PhysicUpdate() { }

        protected void ChangingState<T>(T CurrentState, T NewState)
        {
            GetState(CurrentState).Exit();
            _currentState = NewState;
            GetState(NewState).Enter();
        }

    }
}
