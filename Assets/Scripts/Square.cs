using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    private int _state;

    public bool change_state(bool player)
    {
        int temp = _state;

        if (transform.parent.GetComponent<SmallBoard>().Get_board_state() == 0 && Playable())
        {
            if (player && _state == 0)
            {
                transform.GetChild(0).GameObject().SetActive(false);
                transform.GetChild(1).GameObject().SetActive(false);
                transform.GetChild(2).GameObject().SetActive(true);
                _state = 2;
            }

            else if (!player && _state == 0)
            {
                transform.GetChild(0).GameObject().SetActive(false);
                transform.GetChild(2).GameObject().SetActive(false);
                transform.GetChild(1).GameObject().SetActive(true);
                _state = 1;
            }

            if (transform.parent.TryGetComponent<SmallBoard>(out SmallBoard classic))
            {
                classic.CheckState();
            }
        }

        if (temp != _state)
            return true;

        return false;
    }


    public int Getstate()
    {
        return _state;
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent)
        {
            children.Add(child);
        }

        return children;
    }

    public bool Playable()
    {
        if (transform.parent.TryGetComponent<SmallBoard>(out SmallBoard smallBoard))
        {
            
            if (smallBoard.Get_playable())
            {
                return true;
            }
            
        }else
            return true;

        return false;
    }
}