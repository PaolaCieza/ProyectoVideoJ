using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GenericScript : MonoBehaviour
{
    /** PRUEBAS  POR ESCENA**/
    private VidaPlayer playerVida;
    private InventarioBotiquin botiquines;
    private Inventario balas;
    private Scene scene;
    private int escenaActual;
    private string escenaAPrefsName = "EscenaActual";
    private RE_ThirdPersonInput jugadorSC;

    // Bajas
    public int bajas;
    public int nroEnemigos;
    public Text txtBajas;
    public GameObject pasarNivelGO;

    // ESCENE Nro 2 = 3    
    private string vidaPrefsName2 = "Vida2";
    private string botiquinesPrefsName2 = "Botiquines2";
    private string balasPrefsName2 = "Balas2";
    private string vidaPrefsName3 = "Vida3";
    private string botiquinesPrefsName3 = "Botiquines3";
    private string balasPrefsName3 = "Balas3";

    private string vidaPrefsName4 = "Vida4";
    private string botiquinesPrefsName4 = "Botiquines4";
    private string balasPrefsName4 = "Balas4";

    private string vidaPrefsName5 = "Vida5";
    private string botiquinesPrefsName5 = "Botiquines5";
    private string balasPrefsName5 = "Balas5";
    private string vidaPrefsName6 = "Vida6";
    private string botiquinesPrefsName6 = "Botiquines6";
    private string balasPrefsName6 = "Balas6";

    /** FIN PRUEBAS **/

    private int money;
    private int items;
    private string moneyPrefsName = "Money";
    private string itemsPrefsName = "Items";

    // private UserInterface userInterface;

    private int collectableValue = 5;
    private int itemCost = 10;

    public GameObject msjBuscar;

    private void Awake()
    {
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
        botiquines = GameObject.FindWithTag("Player").GetComponent<InventarioBotiquin>();
        balas = GameObject.FindWithTag("Player").GetComponent<Inventario>();
        jugadorSC = GameObject.FindWithTag("Player").GetComponent<RE_ThirdPersonInput>();
        scene = SceneManager.GetActiveScene();

        bajas = 0;
        

        escenaActual = scene.buildIndex;
        LoadData();
    }

    void Start()
    {
        // userInterface = GameObject.FindGameObjectWithTag("GameController").GetComponent<UserInterface>();
        RefreshUI();
    }

    private void Update()
    {
        if (bajas == nroEnemigos)
        {
            pasarNivelGO.SetActive(true);
            msjBuscar.SetActive(true);
        }

    }

    private void OnDestroy()
    {

        // Solo guardamos las escenas jugables
        if (escenaActual >= 2 && escenaActual < 5) PlayerPrefs.SetInt(escenaAPrefsName, escenaActual);

        if (jugadorSC.win)
        {
            SaveData();
        }

        /**
        if (Object.win) {
            SaveData();
        }
        **/
    }

    public void Collect()
    {
        money += collectableValue;
        RefreshUI();
    }

    public void BuyItem()
    {
        if (money >= itemCost)
        {
            items++;
            money -= itemCost;
        }
        else
        {
            Debug.Log("Can't Buy!!");
        }
        RefreshUI();
    }

    public void RefreshUI()
    {
        balas.textBalas.text = "= " + balas.Cantidad;
        botiquines.textBotiquin.text = "= " + botiquines.CantidadBotiquin;
        txtBajas.text = "" + bajas + " / " + nroEnemigos;
    }

    private void SaveData()
    {

        /** PRUEBAS **/
        switch (escenaActual)
        {
            case 2:
                PlayerPrefs.SetFloat(vidaPrefsName2, playerVida.vida);
                PlayerPrefs.SetInt(botiquinesPrefsName2, botiquines.CantidadBotiquin);
                PlayerPrefs.SetInt(balasPrefsName2, balas.Cantidad);
                break;
            case 3:
                PlayerPrefs.SetFloat(vidaPrefsName3, playerVida.vida);
                PlayerPrefs.SetInt(botiquinesPrefsName3, botiquines.CantidadBotiquin);
                PlayerPrefs.SetInt(balasPrefsName3, balas.Cantidad);
                break;
            case 4:
                PlayerPrefs.SetFloat(vidaPrefsName4, playerVida.vida);
                PlayerPrefs.SetInt(botiquinesPrefsName4, botiquines.CantidadBotiquin);
                PlayerPrefs.SetInt(balasPrefsName4, balas.Cantidad);
                break;
            case 5:
                PlayerPrefs.SetFloat(vidaPrefsName5, playerVida.vida);
                PlayerPrefs.SetInt(botiquinesPrefsName5, botiquines.CantidadBotiquin);
                PlayerPrefs.SetInt(balasPrefsName5, balas.Cantidad);
                break;
            case 6:
                PlayerPrefs.SetFloat(vidaPrefsName6, playerVida.vida);
                PlayerPrefs.SetInt(botiquinesPrefsName6, botiquines.CantidadBotiquin);
                PlayerPrefs.SetInt(balasPrefsName6, balas.Cantidad);
                break;
        }

        /** FIN **/
        PlayerPrefs.SetInt(moneyPrefsName, money);
        PlayerPrefs.SetInt(itemsPrefsName, items);
    }

    private void LoadData()
    {

        /** PRUEBAS **/
        switch (escenaActual)
        {
            case 2:
                playerVida.vida = 100;
                botiquines.CantidadBotiquin = 0;
                balas.Cantidad = 0;
                break;
            case 3:
                playerVida.vida = (PlayerPrefs.GetFloat(vidaPrefsName2, 100f) <= 0) ? 100f : PlayerPrefs.GetFloat(vidaPrefsName2, 100f);
                botiquines.CantidadBotiquin = (PlayerPrefs.GetInt(botiquinesPrefsName2, 0));
                balas.Cantidad = (PlayerPrefs.GetInt(balasPrefsName2, 6) <= 0) ? 6 : PlayerPrefs.GetInt(balasPrefsName2, 6);
                break;
            case 4:
                playerVida.vida = (PlayerPrefs.GetFloat(vidaPrefsName3, 100f) <= 0) ? 100f : PlayerPrefs.GetFloat(vidaPrefsName3, 100f);
                botiquines.CantidadBotiquin = (PlayerPrefs.GetInt(botiquinesPrefsName3, 0));
                balas.Cantidad = (PlayerPrefs.GetInt(balasPrefsName3, 6) <= 0) ? 6 : PlayerPrefs.GetInt(balasPrefsName3, 6);
                break;
            case 5:
                playerVida.vida = (PlayerPrefs.GetFloat(vidaPrefsName4, 100f) <= 0) ? 100f : PlayerPrefs.GetFloat(vidaPrefsName4, 100f);
                botiquines.CantidadBotiquin = (PlayerPrefs.GetInt(botiquinesPrefsName4, 0));
                balas.Cantidad = (PlayerPrefs.GetInt(balasPrefsName4, 6) <= 0) ? 6 : PlayerPrefs.GetInt(balasPrefsName4, 6);
                break;
            case 6:
                playerVida.vida = (PlayerPrefs.GetFloat(vidaPrefsName5, 100f) <= 0) ? 100f : PlayerPrefs.GetFloat(vidaPrefsName5, 100f);
                botiquines.CantidadBotiquin = (PlayerPrefs.GetInt(botiquinesPrefsName5, 0));
                balas.Cantidad = (PlayerPrefs.GetInt(balasPrefsName5, 6) <= 0) ? 6 : PlayerPrefs.GetInt(balasPrefsName5, 6);
                break;

        }

        /** FIN **/
        money = PlayerPrefs.GetInt(moneyPrefsName, 0);
        items = PlayerPrefs.GetInt(itemsPrefsName, 0);
    }

}
