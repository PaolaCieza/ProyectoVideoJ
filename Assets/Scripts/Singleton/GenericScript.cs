using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericScript : MonoBehaviour
{
    /** PRUEBAS  **/
    private VidaPlayer playerVida;    
    private InventarioBotiquin botiquines;
    private Inventario balas;

    private string vidaPrefsName = "Vida";
    private string botiquinesPrefsName = "Botiquines";
    private string balasPrefsName = "Balas";
    /** FIN PRUEBAS **/

    private int money;
    private int items;

    private string moneyPrefsName = "Money";
    private string itemsPrefsName = "Items";

    private UserInterface userInterface;

    private int collectableValue=5;
    private int itemCost = 10;

    private void Awake() 
    {        
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
        botiquines = GameObject.FindWithTag("Player").GetComponent<InventarioBotiquin>();
        balas = GameObject.FindWithTag("Player").GetComponent<Inventario>();
        LoadData();
    }


    void Start()
    {
        userInterface = GameObject.FindGameObjectWithTag("GameController").GetComponent<UserInterface>();
        RefreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        SaveData();
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

    private void RefreshUI()
    {
        userInterface.RefreshMoney(money);
        userInterface.RefreshItems(items);
    }

    private void SaveData() {

        /** PRUEBAS **/
        PlayerPrefs.SetFloat(vidaPrefsName, playerVida.vida);
        PlayerPrefs.SetInt(botiquinesPrefsName, botiquines.CantidadBotiquin);
        PlayerPrefs.SetInt(balasPrefsName, balas.Cantidad);
        /** FIN **/

        PlayerPrefs.SetInt(moneyPrefsName, money);
        PlayerPrefs.SetInt(itemsPrefsName, items);        
    }

    private void LoadData() {
        /** PRUEBAS **/
        playerVida.vida = (PlayerPrefs.GetFloat(vidaPrefsName, 100f) <= 0) ? 100f : PlayerPrefs.GetFloat(vidaPrefsName, 100f);
        botiquines.CantidadBotiquin = (PlayerPrefs.GetInt(botiquinesPrefsName, 0));
        balas.Cantidad = (PlayerPrefs.GetInt(balasPrefsName, 6) <= 0) ? 6 : PlayerPrefs.GetInt(balasPrefsName, 6);
        /** FIN **/
        
        money = PlayerPrefs.GetInt(moneyPrefsName, 0);
        items = PlayerPrefs.GetInt(itemsPrefsName, 0);
    }

}
