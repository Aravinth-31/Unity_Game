using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Solitaire : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public GameObject CardsContainer;
    private static PointsUpdate pointsUpdate;
    public GameObject GameContainer;
    
    public static string[] suits={"C","D","H","S"};
    public static string[] values={"A","2","3","4","5","6","7","8","9","10","J","Q","K"};
    public static List<string> deck;
    public static IDictionary<string,int> alphaCardsValues=new Dictionary<string,int>(){
        {"A",1},
        {"J",11},
        {"Q",12},
        {"K",13}
        };

    // Start is called before the first frame update
    void Start()
    {
        pointsUpdate=FindObjectOfType<PointsUpdate>();
        CardsContainer=GameObject.Find("CardsContainer");
        GameContainer=GameObject.Find("GameContainer");
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
        float xOffset =0;
        float zOffset=0.03f;
        for(int i=0;i<4;i++){
            GameObject newCard= Instantiate(cardPrefab,new Vector3(CardsContainer.transform.position.x+xOffset,CardsContainer.transform.position.y,CardsContainer.transform.position.z-zOffset),Quaternion.identity);
            newCard.transform.parent=GameContainer.transform;
            newCard.name=deck[i];
            UpdatePoint(deck[i].Substring(1,deck[i].Length-1));
            newCard.GetComponent<Selectable>().faceUp=true;
            xOffset+=0.30f;
            zOffset+=0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public static int UpdatePoint(string name){
        int value;
        if(int.TryParse(name,out value))
            pointsUpdate.points+=value;
        else{
            pointsUpdate.points+=alphaCardsValues[name];
            value=alphaCardsValues[name];
        }
        return value;
    }

    public void ToMainMenu(){
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }
}
