using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public class BigBoard : MonoBehaviour
{
    private int GameState; // 0 = Still ongoing // 1 -x WON // 2 - o WON //3 Draw
    private SmallBoard [,] _Boards;
    private int [,] _statesBoards;
    private int _x;
    private int _y;
    public void OnEnable() => SmallBoard.BoardChangedState += CheckState;
    void Awake()
    {
        _statesBoards = new int[3, 3];
        SetBoards();
        AwokePlayableFields();
        //SetPlayableBackgrounds();

    }


    void Update()
    {
        
    }

    public void SetPlayableBackgrounds()
    {
        
        // List<Transform> list0 = GetChildren(transform.parent);
        //
        // foreach (var child in list0)
        // {
        //     GetChildren(child).ElementAt(11).gameObject.SetActive(false);
        // }
        //
        // GetChildren(transform).ElementAt(11).gameObject.SetActive(true);

    }

    public void SetBoards()
    {
        var temp = transform.GetChild(0);
        _Boards = new SmallBoard [3,3];
        for (int i = 0; i < _Boards.GetLength(0); i++)
        {
            for (int j = 0; j < _Boards.GetLength(1); j++)
            {
                if(temp.GetChild(i * _Boards.GetLength(0) + j).TryGetComponent<SmallBoard>(out SmallBoard smallBoard))
                    _Boards[i, j] =smallBoard;
            }
        }
    }
    
    public void CheckState()
    {
        Debug.Log("SADDGE");
        SetStates();
        bool check1 = false;
        

        for (int i = 0; i < 3 && !check1; i++)
        {

            if (_statesBoards[i, 0] == _statesBoards[i, 1] && _statesBoards[i, 1] == _statesBoards[i, 2] && _statesBoards[i, 0] != 0)
                check1 = true;

            if (_statesBoards[0, i] == _statesBoards[1, i] && _statesBoards[1, i] == _statesBoards[2, i] && _statesBoards[0, i] != 0)
                check1 = true;

            if (_statesBoards[i, 0] == _statesBoards[i, 1] && _statesBoards[i, 1] == _statesBoards[i, 2] && _statesBoards[i, 0] != 0)
                check1 = true;

        }

        if (!check1)
            if (_statesBoards[0, 0] == _statesBoards[1, 1] && _statesBoards[1, 1] == _statesBoards[2, 2] && _statesBoards[0, 0] != 0)
                check1 = true;

        if (!check1)
            if (_statesBoards[0, 2] == _statesBoards[1, 1] && _statesBoards[1, 1] == _statesBoards[2, 0] && _statesBoards[0, 2] != 0)
                check1 = true;
        
        if (check1)
        {
            Debug.Log("FLIPPED BIG BOARD");
            GameState = _statesBoards[_x,_y];
            //_flip1 = true;
        }
    }
    
    
    public void SetStates()   
    {
        for (int i = 0; i < _Boards.GetLength(0); i++)
        {
            for (int j = 0; j < _Boards.GetLength(1); j++)
            {
                if (_Boards[i, j].TryGetComponent<SmallBoard>(out SmallBoard smallBoard))
                {
                    if (_statesBoards[i, j] != smallBoard.Get_board_state())
                    {
                        _x = i;
                        _y = j;
                        _statesBoards[i, j] = smallBoard.Get_board_state();

                    }
                }
            }
        }
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



    public void ShowPredictableBackgrounds(int x, int y)
    {
        if (_Boards[x, y].Get_board_state()==0)
        {
            _Boards[x, y].SetPredictable(true);
        }
        else
        {
            for (int i = 0; i < _Boards.GetLength(0); i++)
            {
                for (int j = 0; j < _Boards.GetLength(1); j++)
                {
                    if (_Boards[i, j].Get_board_state()==0)
                    {
                        _Boards[i, j].SetPredictable(true);
                    }
                }
                
            }
        }
    }
        // List<Transform> list1 = GetChildren(transform.parent);
        //     int temp = 0;
        //
        //     for (int i = 0; i < 9; i++)
        //     {
        //         if (list1.ElementAt(i) == transform)
        //             temp = i;
        //     }
        //
        //     List<Transform> list2 = GetChildren(transform.parent.parent);
        //
        //     if (list2.ElementAt(temp).GameObject().TryGetComponent<SmallBoard>(out SmallBoard classic))
        //     {
        //         if (classic.Get_board_state() == 0)
        //             GetChildren(list2.ElementAt(temp)).ElementAt(9).gameObject.SetActive(true);
        //         else
        //         {
        //             for (int i = 0; i < 9; i++)
        //             {
        //                 GetChildren(list2.ElementAt(i)).ElementAt(9).gameObject.SetActive(true);
        //             }
        //         }
        //
        //     }
        
    
    
    
    public void HidePredictableBackgrounds()
    {
        for (int i = 0; i < _Boards.GetLength(0); i++)
        {
            for (int j = 0; j < _Boards.GetLength(1); j++)
            {
                _Boards[i, j].SetPredictable(false);
            }
                
        }

    }
    
    
    public void HideOtherBackgrounds()
    {
        List<Transform> list2 = GetChildren(transform.parent.parent);
        for (int i = 0; i < 9; i++) 
        { 
            GetChildren(list2.ElementAt(i)).ElementAt(9).gameObject.SetActive(false);
        }

    }


    public void AwokePlayableFields()
    {
        for (int i = 0; i < _Boards.GetLength(0); i++)
        {
            for (int j = 0; j < _Boards.GetLength(1); j++)
            {
                _Boards[i, j].Set_playable(true);

            }

        }
    }

    public void HidePlayableFields()
    {
        for (int i = 0; i < _Boards.GetLength(0); i++)
        {
            for (int j = 0; j < _Boards.GetLength(1); j++)
            {
                _Boards[i, j].Set_playable(false);

            }

        }
    }
    
    public void SetPlayableField(int x, int y)
    {
        HidePlayableFields();
        
        if (transform.parent.GetComponent<SmallBoard>().Get_board_state() == 0)
        {
            List<Transform> list1 = GetChildren(transform.parent);
            int temp = 0;

            for (int i = 0; i < 9; i++)
            {
                if (list1.ElementAt(i) == transform)
                    temp = i;
            }

            List<Transform> list2 = GetChildren(transform.parent.parent);

            if (list2.ElementAt(temp).GameObject().TryGetComponent<SmallBoard>(out SmallBoard classic))
            {
                if (classic.Get_board_state() == 0)
                {
                    GetChildren(list2.ElementAt(temp)).ElementAt(11).gameObject.SetActive(true);
                    list2.ElementAt(temp).GetComponent<SmallBoard>().Set_playable(true);
                }
                else
                {
                    for (int i = 0; i < 9; i++)
                    {
                        GetChildren(list2.ElementAt(i)).ElementAt(11).gameObject.SetActive(true);
                        list2.ElementAt(i).GetComponent<SmallBoard>().Set_playable(true);
                    }
                }

            }
        }
    }
}
