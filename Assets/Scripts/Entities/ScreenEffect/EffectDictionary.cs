using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDictionary : MonoBehaviour
{
    public EffectLibrary[] lib;
    private Dictionary<string, SEffect> dict = new Dictionary<string, SEffect>();

    void Start()
    {
        for (int i = 0; i < lib.Length; i++)
            dict.Add(lib[i].name,lib[i].effect);
    }

    public SEffect GetEffect(string effect)
    {
        return this.dict[effect];
    }
}
