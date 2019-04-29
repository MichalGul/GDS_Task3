using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int levelNumber;

    //our UI item
    public UIItem selectedItem; 

    public Inventory playerInventory;
    //public List<Item> sceneStartupItems = new List<Item>();

    public Item wallet;
    public Item vodka;
    public Item weirdBottle;

    //This field will be used to check using item on other interactables
    public Item itemPointerSelectedItem;

    private void Awake()
    {
        //Set to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        InitializeScene();

        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void InitializeScene()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
           Destroy(gameObject);
        }


        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
        levelNumber = SceneManager.GetActiveScene().buildIndex;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (this != instance) return; // Prevent second call

        Debug.Log("OnSceneLoaded: " + scene.name);
        InitializeScene();

        if (scene.name == "Bar")
        {   
                playerInventory.GiveItem(wallet);
        }
        else if (scene.name == "Stacja")
        {
            playerInventory.GiveItem(wallet);
            playerInventory.GiveItem(weirdBottle);

        }


    }


    public void UpdatePointerSelectedItem()
    {
        itemPointerSelectedItem = selectedItem.GetComponent<UIItem>().selectedItem.item;
    }

    public void LoadNextLevel()
    {
        levelNumber++;
        if (levelNumber == SceneManager.sceneCountInBuildSettings+1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(levelNumber);
        }
    }



    
        

}
