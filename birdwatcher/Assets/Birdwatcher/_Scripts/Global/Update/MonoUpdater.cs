using UnityEngine;

namespace Birdwatcher.Global.Updating {

    public abstract class MonoUpdater : MonoBehaviour, IUpdatable {

        public bool ShouldUpdate { get; set; } = true;
        public virtual UpdatableTypes UpdatableTypes { get; }

        public virtual void OnUpdate () { }
        public virtual void OnFixedUpdate () { }
        public virtual void OnLateUpdate () { }
    }
}