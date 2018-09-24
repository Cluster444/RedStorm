using Unity.Entities;
using UnityEngine;

namespace RedStorm.Initialization
{
    public abstract class BaseInitializer : MonoBehaviour, ISceneInitializer
    {
        protected World World;
        protected EntityManager EntityManager;

        public void Setup()
        {}

        public abstract void Initialize();

        protected void SetupWorld(string name)
        {
            if (World != null) return;

            World = new World("MapGeneration");
            World.Active = World;

            EntityManager = World.CreateManager<EntityManager>();

            PlayerLoopManager.RegisterDomainUnload(DomainUnload);
            ScriptBehaviourUpdateOrder.UpdatePlayerLoop(World);
        }

        private void DomainUnload()
        {
            World.Dispose();
            ScriptBehaviourUpdateOrder.UpdatePlayerLoop();
        }
    }
}
