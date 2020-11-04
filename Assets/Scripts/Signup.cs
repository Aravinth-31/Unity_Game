using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Signup : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confpassword;
    private string Username;
    private string Email;
    private string Password;
    private string Confpassword;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SignupButton()
    {
        print("SignUp Succesfull"+Username);
        print("password-->>>"+Password);
        SceneManager.LoadScene("menu");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            if(Username!=""&&Password!=""&&Email!=""&&Confpassword!=""&&(Confpassword==Password)){
                SignupButton();
            }
        }
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(username.GetComponent<InputField>().isFocused){
                email.GetComponent<InputField>().Select();
            }
            if(email.GetComponent<InputField>().isFocused){
                password.GetComponent<InputField>().Select();
            }
            if(password.GetComponent<InputField>().isFocused){
                confpassword.GetComponent<InputField>().Select();
            }
        }

        Username =username.GetComponent<InputField>().text;
        Email =email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        Confpassword = confpassword.GetComponent<InputField>().text;
    }
}
