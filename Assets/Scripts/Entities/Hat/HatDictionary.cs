using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatDictionary : MonoBehaviour
{
    public HatLibrary[] lib;
    private Dictionary<string, SHat> dict = new Dictionary<string, SHat>();

    void Start()
    {
        for (int i = 0; i < lib.Length; i++)
            dict.Add(lib[i].name,lib[i].hat);
    }

    public SHat GetHat(string hat)
    {
        return this.dict[hat];
    }
}
