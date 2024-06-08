using NaiveAPI.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [System.Serializable]
    public class data : NaiveJsonCache
    {
        public override string FilePath => "testCache.json";
        public int value;
        public float value2;
    }
    public data datata;
    void Start()
    {
        datata = new data();
        datata.Load();
        Debug.Log(testConfig.instance.power);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        datata.Save();
    }
}
