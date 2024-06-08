using UnityEngine;

namespace NaiveAPI.Data
{
    public abstract class NaiveCache
    {
        public abstract string FilePath { get; }
        protected abstract string encode();
        protected abstract void decode(string data);
        public void Save() { NaiveFile.SaveCache(FilePath, encode()); }
        public void Load() { decode(NaiveFile.ReadCache(FilePath)); }
    }
    public abstract class NaiveJsonCache : NaiveCache
    {
        protected override void decode(string data)
        {
            JsonUtility.FromJsonOverwrite(data, this);
        }

        protected override string encode()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
