using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NaiveAPI.Data
{
    public static class NaiveFile
    {
        public static string AssetPathToSystemPath(string path)
        {
            if (!path.StartsWith("Assets"))
                throw new Exception("Given path not StartsWith \"Assets\"");
            if (path == "Assets")
                return Application.dataPath;
            return Path.Join(Application.dataPath, path.AsSpan(7));
        }
        public static string SystemPathToAssetsPath(string path)
        {
            return path.Substring(path.IndexOf("Assets"));
        }

        public static void SaveCache(string releatedFilePath, string data, bool log = false)
        {
            var fullPath = Path.Join(Application.temporaryCachePath, releatedFilePath);
            if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            File.WriteAllText(fullPath, data);
            if (log)
                Debug.Log($"Save Cache at \"{fullPath}\"");
        }
        public static string ReadCache(string releatedFilePath)
        {
            var fullPath = Path.Join(Application.temporaryCachePath, releatedFilePath);
            if (File.Exists(fullPath))
                return File.ReadAllText(fullPath);
            return "";
        }
        public static StreamWriter CacheWriter(string releatedFilePath)
        {
            var fullPath = Path.Join(Application.temporaryCachePath, releatedFilePath);
            if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            return new StreamWriter(fullPath);
        }
    }
}
