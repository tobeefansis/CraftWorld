using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class CraftRecipe : ScriptableObject
{
    [SerializeField] List<Item> _input = new List<Item>();
    [SerializeField] List<Item> _output = new List<Item>();

    [Range(0, 10)] public float timeToCreate;

    public List<Item> Input { get => _input; set => _input = value; }
    public List<Item> Output { get => _output; set => _output = value; }

   
  
}
