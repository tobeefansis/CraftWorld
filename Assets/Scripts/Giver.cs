using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEditorInternal;
using System;
using System.Linq;

public class Giver : MonoBehaviour
{
    public enum State
    {
        Nope, InProgress, Done
    }
    public CraftRecipe CraftRecipe;
    public SpriteRenderer ItemIcon;
    GameManager _gameManager;
    float time;
    public UnityEvent onComliteEvent;
    public UnityEvent onClickInLackItem;
    public UnityEvent onClickInDone;
    public UnityEvent onClickInProgress;
    public UnityEvent onClickInSufficesItem;
    public ColorEvent onSelect;
    public ColorEvent onDiSelect;
    public Color SelectColor;
    public Color DiSelectColor;


    public State state;
    private void Start()
    {
        _gameManager = GameManager.GetFromScene();


    }

    private void OnMouseEnter()
    {
        onSelect.Invoke(SelectColor);


    }
    private void OnMouseExit()
    {
        onDiSelect.Invoke(DiSelectColor);

    }
    private void Update()
    {
        if (state == State.InProgress)
        {
            time += Time.deltaTime;
            if (time >= CraftRecipe.timeToCreate)
            {
                time = 0;
                state = State.Done;
                onComliteEvent.Invoke();
                if (ItemIcon)
                {
                    if (CraftRecipe.Output.Count > 0)
                    {
                        ItemIcon.sprite = CraftRecipe.Output[0].icon;

                    }
                }
                print("onComliteEvent");
            }
        }


    }



    private void OnMouseDown()
    {
        switch (state)
        {
            case State.Nope:
                if (_gameManager.settings.Items.IsContainsToRecept(CraftRecipe))
                {
                    _gameManager.settings.Items.RemoveFromRecept(CraftRecipe);
                    state = State.InProgress;
                    time = 0;
                    onClickInSufficesItem.Invoke();
                    print("onClickInSufficesItem");

                }
                else
                {
                    onClickInLackItem.Invoke();
                    print("onClickInLackItem");

                }
                break;
            case State.InProgress:
                onClickInProgress.Invoke();
                print("onClickInProgress");

                break;
            case State.Done:
                onClickInDone.Invoke();
                _gameManager.settings.Items.AddItem(CraftRecipe.Output);
                state = State.Nope;
                print("onClickInDone");

                break;
        }

    }
}
