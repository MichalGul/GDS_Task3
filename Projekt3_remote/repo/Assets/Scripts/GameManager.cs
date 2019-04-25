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

    public bool haveWallet;
    public bool haveWeirdBottle;
    public bool haveVodka;

    //This field will be used to check using item on other interactables
    public Item itemPointerSelectedItem;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Set to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        levelNumber = SceneManager.GetActiveScene().buildIndex;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void UpdatePointerSelectedItem()
    {
        itemPointerSelectedItem = selectedItem.GetComponent<UIItem>().selectedItem.item;
    }

    void CheckInventoryOnSceneLoad()
    {

    }


    public void LoadNextLevel()
    {
        levelNumber++;
        if (levelNumber == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(levelNumber);
        }
    }


}
