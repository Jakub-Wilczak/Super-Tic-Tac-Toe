using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{

    public static bool player;
    public static Turn Instance { get; private set;}

    private void Awake()
    {
        Instance = this;
        player = true;
    }


    public static void change_player()
    {
        player = !player;
    }
   
    
}
