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
    
    
}
