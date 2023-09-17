using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Click : MonoBehaviour
{
    public void SetPlayableField()
    {
        HideplayableFields();
        
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

    public void HideplayableFields()
    {
        List<Transform> list2 = GetChildren(transform.parent.parent);
        for (int i = 0; i < 9; i++) 
        { 
            GetChildren(list2.ElementAt(i)).ElementAt(11).gameObject.SetActive(false);
            list2.ElementAt(i).GetComponent<SmallBoard>().Set_playable(false);

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
