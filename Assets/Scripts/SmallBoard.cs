using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SmallBoard : MonoBehaviour
{
    
    
    
    private List<Transform> _children;
    Transform [,] _squares;
    private int[,] _states;
    private int x;
    private int y;
    private bool flip1 = false;
    private int board_state=0;
    private bool _playable;
    



    void Update()
    {
        if(flip1) Flip(board_state);
    }
    
    void Awake()
    {
        _children = GetChildren(transform);
        _squares =new Transform[3,3];
        _states = new int[3, 3];
        _playable = true;
        Set_playableFields();
        SetStates();
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

    public void CheckState()
    {
        SetStates();
        bool check1 = false;
        

        for (int i = 0; i < 3 && !check1; i++)
        {

            if (_states[i, 0] == _states[i, 1] && _states[i, 1] == _states[i, 2] && _states[i, 0] != 0)
                check1 = true;

            if (_states[0, i] == _states[1, i] && _states[1, i] == _states[2, i] && _states[0, i] != 0)
                check1 = true;

            if (_states[i, 0] == _states[i, 1] && _states[i, 1] == _states[i, 2] && _states[i, 0] != 0)
                check1 = true;

        }

        if (!check1)
            if (_states[0, 0] == _states[1, 1] && _states[1, 1] == _states[2, 2] && _states[0, 0] != 0)
                check1 = true;

        if (!check1)
            if (_states[0, 2] == _states[1, 1] && _states[1, 1] == _states[2, 0] && _states[0, 2] != 0)
                check1 = true;

        




        if (check1)
        {
            Debug.Log("FLIPPED");
            board_state = _states[x,y];
            flip1 = true;
        }
    }


    public void SetStates()
    {
        
        for (int i = 0; i < _squares.GetLength(0); i++)
        {
            for (int j = 0; j < _squares.GetLength(1); j++)
            {
                _squares[i, j] = _children.ElementAt(3*i+j);
            }
        }
        
        
        for (int i = 0; i < _squares.GetLength(0); i++)
        {
            for (int j = 0; j < _squares.GetLength(1); j++)
            {
                if (_squares[i, j].TryGetComponent<State>(out State statecomponent))
                {

                    if (_states[i, j] != statecomponent.Getstate())
                    {
                        x = i;
                        y = j;
                        _states[i, j] = statecomponent.Getstate();

                    }



                }
            }
        }

        
    }


    public void SetPlayableBackground()
    {
        
        List<Transform> list0 = GetChildren(transform.parent);
        
        foreach (var child in list0)
        {
            GetChildren(child).ElementAt(11).gameObject.SetActive(false);
        }
        
        GetChildren(transform).ElementAt(11).gameObject.SetActive(true);

    }



    public void Flip(int check)
    {
        if (check==1)
        {
            GetChildren(_children.ElementAt(10)).ElementAt(1).GameObject().SetActive(false);
        }

        if (transform.eulerAngles.y<=180)
        {
            
            transform.Rotate(Time.deltaTime * 120 * new Vector3(0, 1, 0));
            if (transform.eulerAngles.y>=90)
                _children.ElementAt(10).GameObject().SetActive(true);
            
        }
        else
        {
            Debug.Log("WTF IS THIS");
            flip1 = false;
            Set_playableFields();
        }
    }


    public int GetX()
    {
        return x;
    }
    public int GetY()
    {
        return y;
    }
    public int Get_board_state()
    {
        return board_state;
    }
    public bool Get_playable()
    {
        return _playable;
    }

    public void Set_playable(bool playable)
    {
        _playable = playable;
    }

    public void Set_playableFields()
    {
        List<Transform> list0 = GetChildren(transform.parent);

        foreach (var child in list0)
        {
            if (child.GameObject().TryGetComponent<SmallBoard>(out SmallBoard smallBoard))
            {
                smallBoard.Set_playable(true);
                GetChildren(child).ElementAt(11).GameObject().SetActive(true);
                Debug.Log("TEST");
                
            }
        }
    }
}
