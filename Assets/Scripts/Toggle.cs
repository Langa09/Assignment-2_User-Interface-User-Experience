using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
    public Button toggleButton;

    private bool isCanvas1Active = true;

    private void Awake()
    {
        toggleButton.onClick.AddListener(ToggleCanvas);
    }

    private void ToggleCanvas()
    {
        isCanvas1Active = !isCanvas1Active;
        canvas1.gameObject.SetActive(isCanvas1Active);
        canvas2.gameObject.SetActive(!isCanvas1Active);
    }
}