using Unity.VisualScripting;
using UnityEngine;

namespace Complete
{
    public abstract class BaseState
    {
        #region Methods
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void UpdateState() { }
        public virtual void HandleInput() { }
        public virtual void PhysicUpdate() { }

        #endregion
    }
}