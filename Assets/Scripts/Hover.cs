using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class Hover : MonoBehaviour
{
    public void ChangeBackground()
    {
        if (GetChildren(transform).ElementAt(0).GameObject().TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite))
        {
            sprite.color = new Color(0.77f,0.77f,0.77f,1f);
        }
    }
    
    public void ReturnBackground()
    {
        if (GetChildren(transform).ElementAt(0).GameObject().TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite))
        {
            sprite.color = (Color.white);
        }
    }

    public void ShowOtherBackgrounds()
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
