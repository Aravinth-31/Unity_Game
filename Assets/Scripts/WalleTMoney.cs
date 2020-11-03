using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WalleTMoney : MonoBehaviour
{
    public GameObject money;
    private string Money;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SubmitButton(){
        SceneManager.LoadScene("menu");
    }
    public void BackButton(){
        SceneManager.LoadScene("menu");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            if(Money!=""){
                SubmitButton();
            }
        }
        Money =money.GetComponent<InputField>().text;
    }
}
