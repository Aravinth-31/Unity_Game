using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    private string Username;
    private string Password;
    // public const string url="http.google.ca";
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoginButton(){
        print("Login Succesfull"+Username);
        print("password-->>>"+Password);
        SceneManager.LoadScene("menu");
        // WWW request = new WWW(url);
        // StartCoroutine(OnResponse(request));
        // StartCoroutine(SimpleLoginRequest(Username));
    }
    private IEnumerator OnResponse(WWW req){
        yield return req;
        // print(req.text);
    }
    // IEnumerator SimpleLoginRequest(string name){
    //     List<MultipartFormSection> wwwform = new List<MultipartFormSection>();
    //     wwwform.Add(new MultipartFormSection("userName",Username));
    //     UnityWebRequest www = UnityWebRequest.Post("http://localhost/",wwwform);
    //     yield return www.SendWebRequest();
    //     if(www.isNetworkError || www.isHttpError){
    //         print("[ERROR] Login --->>>  "+www.error);
    //     }else{
    //         print("[] Login Succesfull --->>>  "+www);
    //     }
    // }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            if(Username!=""&&Password!=""){
                LoginButton();
            }
        }
        Username =username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
}
