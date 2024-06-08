#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using NaiveAPI.Data;
using System.IO;

namespace NaiveEditorAPI.Data
{
    public abstract class NaiveScriptableConfig<T> : ScriptableObject
        where T : NaiveScriptableConfig<T>
    {
        protected abstract string DefaultAssetFilePath { get; }
        public static T instance
        {
            get
            {
                if(m_instance == null)
                {
                    var loaded = Resources.LoadAll<T>("");
                    if (loaded.Length > 0)
                    {
                        m_instance = loaded[0];
                        m_instance.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }
                    else
                    {
                        m_instance = CreateInstance<T>();
#if UNITY_EDITOR
                        Directory.CreateDirectory(NaiveFile.AssetPathToSystemPath(m_instance.DefaultAssetFilePath));
                        AssetDatabase.CreateAsset(m_instance, m_instance.DefaultAssetFilePath);
                        AssetDatabase.Refresh();
                        Debug.Log($"ScriptableConfig of Type \"{typeof(T).Name}\" not found. Create Asset at \"{m_instance.DefaultAssetFilePath}\"");
#else
                        Debug.LogError($"ScriptableConfig of Type \"{typeof(T).Name}\" not found. A empty instance generated.");
#endif
                    }
                }
                return m_instance;
            }
        }
        protected static T m_instance;
    }
}
