using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Boutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalSprite;   // Le sprite par d�faut
    public Sprite hoverSprite;    // Le sprite au survol

    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();  // R�cup�re le composant Image du bouton
    }

    // Quand la souris entre sur le bouton
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;   // Change le sprite � hoverSprite
    }

    // Quand la souris sort du bouton
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite;  // R�tablit le sprite � normalSprite
    }
}