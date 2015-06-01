using UnityEngine;
using System.Collections;

public class CheckGesture : MonoBehaviour {


    private Vector3 posHand;
    private Vector3 posElbow;
    private Vector3 posShoulder;
    public GameObject hand;
    public GameObject elbow;
    public GameObject shoulder;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        posHand = hand.transform.position;
        posElbow = elbow.transform.position;
        posShoulder = shoulder.transform.position;

        if (posHand.y > posShoulder.y && posHand.y > posElbow.y && posElbow.y > posShoulder.y)
        {
            Debug.Log("Gesture Recognized");

        }
	}
}
