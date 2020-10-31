using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Solitaire : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public Transform BottomContainer;
    
    public static string[] suits={"C","D","H","S"};
    public static string[] values={"A","2","3","4","5","6","7","8","9","10","J","Q","K"};
    public List<string> deck;
    // Start is called before the first frame update
    void Start()
    {
        playCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shuffle<T>(List<T> list){
        System.Random random = new System.Random();
        int n = list.Count;
        while(n>1){
            int k= random.Next(n);
            n--;
            T temp=list[k];
            list[k]=list[n];
            list[n]=temp;
        }
    }

    public void playCards(){
        deck=GenerateDeck();
        Shuffle(deck);
        // foreach(string card in deck){
        //     print(card);
        // }
        StartCoroutine(SolitaireDeal());
        // SolitaireDeal();
    }

    public static List<string> GenerateDeck(){
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach(string v in values){
                newDeck.Add(s+v);
            }
        }
        return newDeck;
    }

    IEnumerator SolitaireDeal(){
        int[] cards= new int[5]{39,34,25,42,31};
        float xOffset =0;
        float zOffset=0.03f;
        for(int i=0;i<5;i++){
            GameObject newCard= Instantiate(cardPrefab,new Vector3(BottomContainer.position.x+xOffset,BottomContainer.position.y,BottomContainer.position.z-zOffset),Quaternion.identity);
            newCard.name=deck[cards[i]];
            newCard.GetComponent<Selectable>().faceUp=true;
            xOffset+=0.30f;
            zOffset+=0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void ToMainMenu(){
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(0);
    }
}
