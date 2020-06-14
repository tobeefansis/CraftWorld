using UnityEngine;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using System;
using UnityEngine.Events;

[Serializable]
public class ItemList
{
    [SerializeField]
    public List<Item> _items = new List<Item>();
    [Range(0, 64)] public int MaxCount;
    public UnityEvent OnChangeInventery;

    

    public bool AddItem(Item item)
    {
        if (_items.Count < MaxCount)
        {
            _items.Add(item);
            OnChangeInventery.Invoke();

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddItem(List<Item> item)
    {
        if (_items.Count < MaxCount)
        {
            _items.AddRange(item);
            OnChangeInventery.Invoke();

            return true;
        }
        else
        {
            return false;
        }
    }

    public Item GetItem(int index)
    {
        if (index >= 0 && index < _items.Count)
        {
            return _items[index];
        }
        else
        {
            return null;
        }
    }

    public List<Item> GetItems()
    {
        return _items;
    }

    public bool IsContainsToRecept(CraftRecipe craftRecipe)
    {
        if (craftRecipe)
        {
            var input = new List<Item>();
            var TempItems = new List<Item>();
            craftRecipe.Input.ForEach(n => input.Add(n));
            _items.ForEach(n => TempItems.Add(n));
            for (int i = 0; i < input.Count; i++)
            {
                if (TempItems.Contains(input[i]))
                {
                    TempItems.Remove(input[i]);
                    input.RemoveAt(i);
                    i--;
                }
            }
            return input.Count == 0;
        }
        else
        {
            return false;
        }
        
    }

    public void RemoveFromRecept(CraftRecipe craftRecipe)
    {

        var input = new List<Item>();
        craftRecipe.Input.ForEach(n => input.Add(n));
        for (int i = 0; i < input.Count; i++)
        {
            if (_items.Contains(input[i]))
            {
                _items.Remove(input[i]);
                input.RemoveAt(i);
                i--;
            }
        }
        OnChangeInventery.Invoke();
    }
}
