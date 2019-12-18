using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDictionary : MonoBehaviour
{
    [SerializeField]
    private MoveLibrary[] lib;
    private Dictionary<string, SMove> dict = new Dictionary<string, SMove>();

    void Start()
    {
        for (int i = 0; i < lib.Length; i++)
            dict.Add(lib[i].name,lib[i].move);
    }

    public SMove GetMove(string move)
    {
        return this.dict[move];
    }
}
