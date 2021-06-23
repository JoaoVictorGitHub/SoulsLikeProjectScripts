using UnityEngine;

public class SaveFiles : MonoBehaviour
{
    [SerializeField]
    private GameObject thisObject;

    InputHandler inputHandler;



    private void Start()
    {
        thisObject = GameObject.FindGameObjectWithTag("Player");
        inputHandler = GetComponent<InputHandler>();
    }

    private void Update()
    {

        if (inputHandler.loadGame_Input)
        {
            LoadGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fogueira")
        {
            SaveGame();
        }
    }


    void SaveGame()
    {
        PlayerPrefs.SetFloat("PlayerX", thisObject.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", thisObject.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", thisObject.transform.position.z);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }


    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));

            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}