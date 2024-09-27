using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CinematicController : MonoBehaviour
{
    public Image[] images; // Tableau pour stocker les images
    private int currentImageIndex = 0;

    void Start()
    {
        // Masquez toutes les images au début
        foreach (Image img in images)
        {
            img.gameObject.SetActive(false);
        }

        // Affiche la première image
        ShowImage();
    }

    void Update()
    {
        // Vérifiez si l'utilisateur appuie sur Espace pour passer à l'image suivante
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextImage();
        }
    }

    void ShowImage()
    {
        // Afficher l'image actuelle
        if (currentImageIndex < images.Length)
        {
            images[currentImageIndex].gameObject.SetActive(true);
        }
    }

    void ShowNextImage()
    {
        // Masquer l'image actuelle
        if (currentImageIndex < images.Length)
        {
            images[currentImageIndex].gameObject.SetActive(false);
            currentImageIndex++;
        }

        // Afficher la prochaine image
        if (currentImageIndex < images.Length)
        {
            ShowImage();
        }
        else
        {
            // Si toutes les images ont été affichées, passez à la scène menu
            SceneManager.LoadScene("menu");
        }
    }
}