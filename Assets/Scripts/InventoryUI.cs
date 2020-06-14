using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    GameManager _gameManager;
    PlayerSettings _playerSettings;
    public Transform Target;
    public ItemCell ItemCellPrefub;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.GetFromScene();
        _playerSettings = _gameManager.settings;
        _playerSettings.Items.OnChangeInventery.AddListener(Refresh);
        Refresh();
    }

    public void Refresh()
    {
        RemoveAllItem();

        for (int i = 0; i < _playerSettings.Items.MaxCount; i++)
        {
            if (_playerSettings.Items.GetItem(i))
            {
                Instantiate(ItemCellPrefub, Target).ItemSet(_playerSettings.Items.GetItem(i).icon);

            }
            else
            {
                Instantiate(ItemCellPrefub, Target).ItemSet(null);

            }
        }

    }

    private void RemoveAllItem()
    {
        for (int i = 0; i < Target.childCount; i++)
        {
            Destroy(Target.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
