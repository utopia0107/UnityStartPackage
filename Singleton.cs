using UnityEngine;
/// <summary>
/// Singleton pattern.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : Component
{
    protected static T _instance;
    protected static bool benable = true;
    /// <summary>
    /// Singleton design pattern
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance
    {
        get
        {
            if (_instance == null && benable)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// On awake, we initialize our instance. Make sure to call base.Awake() in override if you need awake.
    /// </summary>
    protected virtual void Awake()
    {
        _instance = this as T;
    }
    protected void OnDisable()
    {
        benable = false;
    }
}