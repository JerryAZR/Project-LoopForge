using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoreMountains.Tools
{
	/// <summary>
	/// Scene-specific singleton pattern.
	/// </summary>
	public class MMSceneSingleton<T> : MonoBehaviour where T : Component
	{
		private static readonly Dictionary<int, T> _instances = new();
		public static bool HasInstance(int key) => _instances.ContainsKey(key);


        /// <summary>
        /// Returns the singleton instance for a given Scene.
        /// </summary>
        public static T GetForScene(Scene scene)
        {
            if (!scene.IsValid()) return null;
            return _instances.GetValueOrDefault(scene.handle, null);
        }

        /// <summary>
        /// Returns the singleton instance for the scene containing the given GameObject.
        /// </summary>
        public static T GetFor(GameObject obj)
        {
            if (obj == null) return null;
            return GetForScene(obj.scene);
        }

        /// <summary>
        /// Returns the singleton instance for the scene containing the given Component.
        /// </summary>
        public static T GetFor(Component component)
        {
            if (component == null) return null;
            return GetForScene(component.gameObject.scene);
        }


        /// <summary>
        /// On awake, we initialize our instance. Make sure to call base.Awake() in override if you need awake.
        /// </summary>
        protected virtual void Awake()
        {
            InitializeSingleton();
        }

        protected virtual void OnDestroy()
        {
            // Remove instance from dictionary if it's the registered one
            if (GetFor(this) == this)
            {
                _instances.Remove(gameObject.scene.handle);
            }
            else
            {
                Debug.LogWarning(
                    $"MMSceneSingleton: An instance of {typeof(T).Name} " +
                    $"in scene {gameObject.scene.name} was destroyed, " +
                    "but it was not the registered singleton instance.");
            }
        }

        /// <summary>
        /// Initializes the singleton.
        /// </summary>
        protected virtual void InitializeSingleton()
		{
			if (!Application.isPlaying)
			{
				return;
			}
            // Will panic if there are multiple instances in the same scene
			_instances.Add(gameObject.scene.handle, this as T);
		}
	}
}