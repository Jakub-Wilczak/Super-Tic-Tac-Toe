using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler ,IPointerExitHandler
{

    public static bool player=true;
    private State _state;
    private Hover _hover;
    private Click _click;

    private void Awake()
    {
        _state = GetComponent<State>();
        _hover = GetComponent<Hover>();
        _click = GetComponent<Click>();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        _hover.ChangeBackground();
        _hover.ShowOtherBackgrounds();
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        _hover.ReturnBackground();
        _hover.HideOtherBackgrounds();
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_state.change_state(player))
        {
            player = !player;
            _click.SetPlayableField();
        }
        
        


    }

    
}
