using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NumberWizard : MonoBehaviour {
	// Use this for initialization
	int max;
	int min;
	int guess;

	public int maxGuessesAllowed = 10;

	public Text text;

	public Text guesses;

	void Start () {
		StartGame();
	}

	void StartGame ()
	{
		max = 1000;
		min = 1;
		NextGuess();

	}

	public void GuessLower(){
		max = guess;
		NextGuess();
	}

	public void GuessHigher(){
		min = guess;
		NextGuess();
	}

	void NextGuess ()
	{
		guess = Random.Range(min,max+1);
		text.text = guess.ToString();
		maxGuessesAllowed = maxGuessesAllowed - 1;
		guesses.text = "Guesses Remaining: " + maxGuessesAllowed.ToString();
		if(maxGuessesAllowed <= 0){
		SceneManager.LoadScene("Win");
		}
	}
}
