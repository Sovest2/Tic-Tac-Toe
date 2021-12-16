using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void OpenSettings()
    {
        Instantiate(settingsMenu, transform.parent);
    }
}
