using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;

public class CustomMonoBehaviour : MonoBehaviour
{
    private void Awake()
    {
        Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();
        Transform[] gameObjects = transform.GetComponentsInChildren<Transform>(true);
        foreach (var obj in gameObjects)
        {
            if (!dictionary.ContainsKey(obj.name)) dictionary.Add(obj.name, obj.gameObject);
        }

        FieldInfo[] objectFields =
            this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        for (int i = 0; i < objectFields.Length; i++)
        {
            BindComponet attribute =
                Attribute.GetCustomAttribute(objectFields[i], typeof(BindComponet)) as BindComponet;
            if (attribute != null && !string.IsNullOrEmpty(attribute.GameObejectName))
            {
#if UNITY_EDITOR && DEV
                Debug.Log(attribute.GameObejectName);
#endif
                try
                {
                    if (dictionary.ContainsKey(attribute.GameObejectName))
                    {
                        Type type = objectFields[i].FieldType;
                        Component component = null;
                        if (type == typeof(GameObject))
                        {
                            objectFields[i].SetValue(this, dictionary[attribute.GameObejectName]);
                        }
                        else if (dictionary[attribute.GameObejectName].TryGetComponent(type, out component))
                        {
                            objectFields[i].SetValue(this, component);
                        }
                        else
                        {
                            Debug.LogWarning(attribute.GameObejectName + " Not Conver");
                        }
                    }
                }
                catch
                {
                    Debug.LogWarning(attribute.GameObejectName + "Not Exist");
                }
            }
        }

        Init();
    }

    public virtual void Init()
    {
    }
}