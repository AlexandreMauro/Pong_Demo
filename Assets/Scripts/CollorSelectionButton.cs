using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollorSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;
    public bool isColorPlayer = false;
    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if (isColorPlayer)
        {
            SavedController.Instance.colorPlayer = paddleReference.color;
        }
        else
        {
            SavedController.Instance.colorEnemy = paddleReference.color;
        }
    }
}
