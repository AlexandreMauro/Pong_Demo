using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavedController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    public string namePlayer;
    public string nameEnemy;


    private string WinnerSaveKey = "SavedWinner";

    private static SavedController _instance;
    // Propriedade est�tica para acessar a inst�ncia
    public static SavedController Instance
    {
        get
        {
            if (_instance == null)
            {
                // Procure a inst�ncia na cena
                _instance = FindObjectOfType<SavedController>();
                // Se n�o encontrar, crie uma nova inst�ncia
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SavedController).Name);
                    _instance = singletonObject.AddComponent<SavedController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Garanta que apenas uma inst�ncia do Singleton exista
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        // Mantenha o Singleton vivo entre as cenas
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(WinnerSaveKey, winner);
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(WinnerSaveKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
