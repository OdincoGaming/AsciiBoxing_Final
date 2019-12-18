using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerDictionary : MonoBehaviour
{
    [SerializeField]
    private BoxerLibrary[] lib;
    private Dictionary<string, string> boxerDict = new Dictionary<string, string>();

    void Start()
    {
        for (int i = 0; i < lib.Length; i++)
            boxerDict.Add(lib[i].name, lib[i].text);
    }

    public string GetAnimation(string boxer)
    {
        return this.boxerDict[boxer];
    }
}
