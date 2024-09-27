using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Boutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalSprite;   // Le sprite par défaut
    public Sprite hoverSprite;    // Le sprite au survol

    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();  // Récupère le composant Image du bouton
    }

    // Quand la souris entre sur le bouton
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;   // Change le sprite à hoverSprite
    }

    // Quand la souris sort du bouton
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite;  // Rétablit le sprite à normalSprite
    }
}