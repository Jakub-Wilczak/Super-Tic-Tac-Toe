using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public class BigBoard : MonoBehaviour
{
    private Transform [,] _Boards;
    void Awake()
    {
        
        SetBoards();
            
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
        _Boards = new Transform [3,3];
        for (int i = 0; i < _Boards.GetLength(0); i++)
        {
            for (int j = 0; j < _Boards.GetLength(1); j++)
            {
                _Boards[i, j] = temp.GetChild(i * _Boards.GetLength(0) + j);
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
    
    
    
    public void ShowPredictableBackgrounds(int[,]xy)
    {
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
                    GetChildren(list2.ElementAt(temp)).ElementAt(9).gameObject.SetActive(true);
                else
                {
                    for (int i = 0; i < 9; i++)
                    {
                        GetChildren(list2.ElementAt(i)).ElementAt(9).gameObject.SetActive(true);
                    }
                }

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
    
    
}
