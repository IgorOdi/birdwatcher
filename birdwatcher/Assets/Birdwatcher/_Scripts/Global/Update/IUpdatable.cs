namespace Birdwatcher.Global.Updating {

    public interface IUpdatable {

        UpdatableTypes UpdatableTypes { get; }

        void OnUpdate ();
        void OnFixedUpdate ();
        void OnLateUpdate ();
    }
}