using NaiveEditorAPI.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testConfig : NaiveScriptableConfig<testConfig>
{
    protected override string DefaultAssetFilePath => "Assets/Resources/testC.asset";
    public int power;
}
