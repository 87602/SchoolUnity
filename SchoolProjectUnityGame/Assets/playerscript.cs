using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerscript : MonoBehaviour
{
    //Variabelen aanmaken
    public Text scoreText;
    public Text timerText;
    private float counterdownTimer = 180;
    private int score;
    public bool canPostScore = true;

    //Object Highschore zodat we functies kunnen aanroepen uit die class
    public highScore highscoreOBj;

    // Start is called before the first frame update
    void PostScore()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Als er nog geen score is gepost, laat de timer aftellen
        if (canPostScore)
        {
            counterdownTimer -= 1 * Time.deltaTime;
            timerText.text = "Time left: " + counterdownTimer;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        //Switch statement om collision te detecteren van verschillende objecten op basis van TAG
        if (other.CompareTag("score"))
        {
            score++;
            scoreText.text = "Score: " + score;
        }
        //Speler is af als de collider on de grond wordt geraakt
        else if (other.CompareTag("death"))
        {
            SceneManager.LoadScene(0);
        }
        //detecteer als of het einde is bereikt
        else if (other.CompareTag("win"))
        {
            if (canPostScore)
            {
                //In de highscore class variabelen aanpassen zodat de score wordt meegegeven en de verstuur score functie uitvoeren
                highscoreOBj.highscore = score + (int)counterdownTimer;
                highscoreOBj.PostScore();
                //error Assets/playerscript.cs(56,30): error CS1061: 'highScore' does not contain a definition for 'PostScore' and no accessible extension method 'PostScore' accepting a first argument of type 'highScore' could be found (are you missing a using directive or an assembly reference?)

            }

            //Boolean op false zetten want het einde is bereikt.
            canPostScore = false;
            
        }
    }
}
