using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    private int _state;
    private int _x;
    private int _y;
    private bool _playable;
    public SmallBoard smallBoard;
    public static event Action OnChangedState;


    private void Awake()
    {
        _playable = true;
    }

    public void OnMouseDown() => change_state();

    public void OnMouseEnter()
    {
        if (transform.GetChild(0).TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite)) sprite.color = new Color(0.77f,0.77f,0.77f,1f);
        
        if(_playable) smallBoard.bigBoard.ShowPredictableBackgrounds(_x,_y);
        
        
        
    }

    public void OnMouseExit()
    {
        if (transform.GetChild(0).TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite)) sprite.color = (Color.white); 
        
        smallBoard.bigBoard.HidePredictableBackgrounds();
    }

    public void change_state()
    {
        int temp = _state;
        
        if (smallBoard.Get_board_state()==0 && _playable)
        {
            if (Turn.player && _state == 0)
            {
                transform.GetChild(0).GameObject().SetActive(false);
                transform.GetChild(1).GameObject().SetActive(false);
                transform.GetChild(2).GameObject().SetActive(true);
                _state = 2;
            }

            else if (!Turn.player && _state == 0)
            {
                transform.GetChild(0).GameObject().SetActive(false);
                transform.GetChild(1).GameObject().SetActive(true);
                transform.GetChild(2).GameObject().SetActive(false);
                _state = 1;
            }
        }

        if (temp != _state)
        {
            Turn.change_player();
            OnChangedState?.Invoke();
        }
    }


    
    public int Getstate()
    {
        return _state;
    }
    
    public bool Get_playable()
    {
        return _playable;
    }
    public void Set_playable(bool playable)
    {
        _playable = playable;
    }

    public void Set_x(int x)
    {
        _x = x;
    }
    public void Set_y(int y)
    {
        _y = y;
    }

    public int Get_x()
    {
        return _x;
    }
    
    public int Get_y()
    {
        return _y;
    }

    
}