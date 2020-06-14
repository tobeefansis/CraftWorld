using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu()]
public class Item : ScriptableObject
{
    public string Name;

    [TextArea(2, 8)] public string Description;
    public Sprite icon;
}
