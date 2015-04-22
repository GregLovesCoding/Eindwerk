using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using Microsoft.Speech;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.AudioFormat;
using Microsoft.Kinect;



public class VoiceInput : MonoBehaviour {

  //  public Spell[] SpellList;
    //Create an instance of your kinect sensor       
    public KinectSensor CurrentSensor;
    //and the speech recognition engine (SRE)
    private SpeechRecognitionEngine speechRecognizer;


	// Use this for initialization
	void Start () {
        InitializeKinect();
	}
	
	// Update is called once per frame
	void Update () {
	
	}








        private static RecognizerInfo GetKinectRecognizer()
        {
            Func<RecognizerInfo, bool> matchingFunc = r =>
            {
                string value;
                r.AdditionalInfo.TryGetValue("Kinect", out value);
                return "True".Equals(value, StringComparison.InvariantCultureIgnoreCase) && "en-US".Equals(r.Culture.Name, StringComparison.InvariantCultureIgnoreCase);
            };
            return SpeechRecognitionEngine.InstalledRecognizers().Where(matchingFunc).FirstOrDefault();
        }
        private KinectSensor InitializeKinect()
        {
            //get the first available sensor and set it to the current sensor variable
            CurrentSensor = KinectSensor.KinectSensors
                                  .FirstOrDefault(s => s.Status == KinectStatus.Connected);
            speechRecognizer = CreateSpeechRecognizer();
            //Start the sensor
            CurrentSensor.Start();
            //then run the start method to start streaming audio
            StartStream();
            return CurrentSensor;
        }
        //Start streaming audio
        private void StartStream()
        {
            //set sensor audio source to variable
            var audioSource = CurrentSensor.AudioSource;
            //Set the beam angle mode - the direction the audio beam is pointing
            //we want it to be set to adaptive
            audioSource.BeamAngleMode = BeamAngleMode.Adaptive;
            //start the audiosource 
            var kinectStream = audioSource.Start();
            //configure incoming audio stream
            speechRecognizer.SetInputToAudioStream(
                kinectStream, new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
            //make sure the recognizer does not stop after completing     
            speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            //reduce background and ambient noise for better accuracy
            CurrentSensor.AudioSource.EchoCancellationMode = EchoCancellationMode.None;
            CurrentSensor.AudioSource.AutomaticGainControlEnabled = false;

        }
        //here is the fun part: create the speech recognizer
        private SpeechRecognitionEngine CreateSpeechRecognizer()
        {
            //set recognizer info
            RecognizerInfo ri = GetKinectRecognizer();
            //create instance of SRE
            SpeechRecognitionEngine sre;
            sre = new SpeechRecognitionEngine(ri.Id);

            //Now we need to add the words we want our program to recognise
            var grammar = new Choices();
            grammar.Add("Test");
     
        

            //set culture - language, country/region
            var gb = new GrammarBuilder { Culture = ri.Culture };
            gb.Append(grammar);

            //set up the grammar builder
            var g = new Grammar(gb);
            sre.LoadGrammar(g);

            //Set events for recognizing, hypothesising and rejecting speech
            sre.SpeechRecognized += SreSpeechRecognized;
            sre.SpeechHypothesized += SreSpeechHypothesized;
            sre.SpeechRecognitionRejected += SreSpeechRecognitionRejected;
            return sre;
        }
        //if speech is rejected
        private void RejectSpeech(RecognitionResult result)
        {
           // textBox1.Text = "WTF?";
            //textBox1.BackColor = Color.Pink;
            Debug.Log("speech rejected");
        }

        private void SreSpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            RejectSpeech(e.Result);
        }
        //hypothesized result
        private void SreSpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            //textBox1.Text = "Hypothesized: " + e.Result.Text + " " + e.Result.Confidence;
        }
        //Speech is recognised
        private void SreSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //Very important! - change this value to adjust accuracy - the higher the value
            //the more accurate it will have to be, lower it if it is not recognizing you
            if (e.Result.Confidence < .2f)
            {
                RejectSpeech(e.Result);
            }
            if (e.Result.Confidence > 0.8f)
            {
                switch (e.Result.Text.ToUpperInvariant())
                {
                    //and finally, here we set what we want to happen when 
                    //the SRE recognizes a word
                    case "TEST":
                      Debug.Log("Test Complete");

                        break;
                 


                }
            }
        }


 


     


}
