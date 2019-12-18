using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanceDictionary : MonoBehaviour
{
    [SerializeField]
    private StanceLibrary[] stances;
    private Dictionary<string, SStance> stancesDict = new Dictionary<string, SStance>();

    void Start()
    {
        for (int i = 0; i < stances.Length; i++)
            stancesDict.Add(stances[i].name,stances[i].stance);
    }

    public SStance GetStance(string stance)
    {
        return this.stancesDict[stance];
    }
}
