using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
//using Microsoft.Speech;
//using Microsoft.Speech.Recognition;
//using Microsoft.Speech.AudioFormat;




public class VoiceInput : MonoBehaviour {


    
    
    

	// Use this for initialization
	void Start () {
        //InitializeKinect();
       Input();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Input() {

        //SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        SpeechRecognizer sre = new SpeechRecognizer();

     //set input here
      //  sre.SetInputToDefaultAudioDevice();

        //setup the grammar
        Choices grammar = new Choices();
        grammar.Add(new string[] { "red", "green", "blue" });

        GrammarBuilder gb = new GrammarBuilder();
        gb.Append(grammar);


        //set up the grammar builder
        Grammar g = new Grammar(gb);
    
        try { 
        //    sre.LoadGrammar(g); 
        }
        catch (Exception e) {
            Debug.Log(e);
        }
 
        
        //Set events for recognizing, hypothesising and rejecting speech

        /*sre.SpeechRecognized += SreSpeechRecognized;
        sre.SpeechHypothesized += SreSpeechHypothesized;
        sre.SpeechRecognitionRejected += SreSpeechRecognitionRejected;*/

      // sre.Recognize();
      
    }


 


     


}
