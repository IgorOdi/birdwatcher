using Birdwatcher.Global.Updating;

namespace Birdwatcher.Controller {

    public class BaseController : MonoUpdater {

        void Awake () => Initialize ();
        public virtual void Initialize () => this.RegisterUpdatable (UpdatableTypes);
        void OnDestroy () => this.UnregisterUpdatable ();
    }
}