using UnityEngine;

namespace RedStorm.Initialization
{
    public static class Bootstrap
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void BeforeSceneLoad()
        {
            Debug.Log("Begin Loading " + Time.realtimeSinceStartup);

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void AfterSceneLoad()
        {
            GameObject initializerGO = GameObject.Find("Initializer");

            if (initializerGO == null)
            {
                Debug.LogWarning("No Initializer GameObject found");
                return;
            }

            ISceneInitializer initializer = initializerGO.GetComponent<ISceneInitializer>();

            if (initializer == null)
            {
                Debug.LogWarning("No SceneInitializer found on Initializer GameObject");
                return;
            }

            Debug.Log($"Initializing {initializer.GetType().Name}");
            initializer.Setup();
            initializer.Initialize();
            Debug.Log("Loading Complete " + Time.realtimeSinceStartup);
        }
    }
}
