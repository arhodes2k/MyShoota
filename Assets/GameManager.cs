using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour

{

   [SerializeField]  public int score;
   [SerializeField] public int impScore;

    int winner = 10;

    [SerializeField] TMP_Text impText;    
    [SerializeField] TMP_Text astroText; 

    [SerializeField] TMP_Text WinText; 
   

    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
        impScore = 0;
    }

    public void ImposterScored(){
        impScore += 2;
    }
    public void AstroScored(){
        score += 2;
    }

    // Update is called once per frame
    void Update()
    {
        impText.text = "Imposter: " + impScore.ToString();
        astroText.text = "Astronaut: " + score.ToString();

        if (impScore > winner){
            impWon();
        }
        if (score > winner){
           astroWon();
        }
    }

    public void impWon(){

       WinText.text = "No! The Imposter won! He'll get eaten last...";
    }

    public void astroWon(){

         WinText.text = "Ah! The astronaut won! We'll eat him first...";
    }
}
