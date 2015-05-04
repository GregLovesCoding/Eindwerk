using UnityEngine;
using System.Collections;
using System;

public class KinectGestureController : MonoBehaviour {

    //Assignments for a bitmask to control which bones to look at and which to ignore
    public enum BoneMask
    {
        None = 0x0,
        Hip_Center = 0x1,
        Spine = 0x2,
        Shoulder_Center = 0x4,
        Head = 0x8,
        Shoulder_Left = 0x10,
        Elbow_Left = 0x20,
        Wrist_Left = 0x40,
        Hand_Left = 0x80,
        Shoulder_Right = 0x100,
        Elbow_Right = 0x200,
        Wrist_Right = 0x400,
        Hand_Right = 0x800,
        Hip_Left = 0x1000,
        Knee_Left = 0x2000,
        Ankle_Left = 0x4000,
        Foot_Left = 0x8000,
        Hip_Right = 0x10000,
        Knee_Right = 0x20000,
        Ankle_Right = 0x40000,
        Foot_Right = 0x80000,
        All = 0xFFFFF,
        Torso = 0x10000F, //the leading bit is used to force the ordering in the editor
        Left_Arm = 0x1000F0,
        Right_Arm = 0x100F00,
        Left_Leg = 0x10F000,
        Right_Leg = 0x1F0000,
        R_Arm_Chest = Right_Arm | Spine,
        No_Feet = All & ~(Foot_Left | Foot_Right),
        UpperBody = Shoulder_Center | Head | Shoulder_Left | Elbow_Left | Wrist_Left | Hand_Left |
        Shoulder_Right | Elbow_Right | Wrist_Right | Hand_Right

    }

    public SkeletonWrapper sw;

    private Vector3 Hip_Center;
    private Vector3 Spine;
    private Vector3 Shoulder_Center;
    private Vector3 Head;
    private Vector3 Shoulder_Left;
    private Vector3 Elbow_Left;
    private Vector3 Wrist_Left;
    private Vector3 Hand_Left;
    private Vector3 Shoulder_Right;
    private Vector3 Elbow_Right;
    private Vector3 Wrist_Right;
    private Vector3 Hand_Right;
    private Vector3 Hip_Left;
    private Vector3 Knee_Left;
    private Vector3 Ankle_Left;
    private Vector3 Foot_Left;
    private Vector3 Hip_Right;
    private Vector3 Knee_Right;
    private Vector3 Ankle_Right;
    private Vector3 Foot_Right;

    private Vector3[] _bones; //internal handle for the bones of the model

    public int player;
    public BoneMask Mask = BoneMask.All;

    public float scale = 1.0f;

	// Use this for initialization
	void Start () {
        	//store bones in a list for easier access
		_bones = new Vector3[(int)Kinect.NuiSkeletonPositionIndex.Count] {Hip_Center, Spine, Shoulder_Center, Head,
			Shoulder_Left, Elbow_Left, Wrist_Left, Hand_Left,
			Shoulder_Right, Elbow_Right, Wrist_Right, Hand_Right,
			Hip_Left, Knee_Left, Ankle_Left, Foot_Left,
			Hip_Right, Knee_Right, Ankle_Right, Foot_Right};
	}
	
	// Update is called once per frame
	void Update () {
			if(player == -1)
			return;
		//update all of the bones positions
		if (sw.pollSkeleton())
		{
			for( int ii = 0; ii < (int)Kinect.NuiSkeletonPositionIndex.Count; ii++) {
				//_bonePos[ii] = sw.getBonePos(ii);
				if( ((uint)Mask & (uint)(1 << ii) ) > 0 ){
					//_bones[ii].transform.localPosition = sw.bonePos[player,ii];
					_bones[ii] = new Vector3(
						sw.bonePos[player,ii].x * scale,
						sw.bonePos[player,ii].y * scale,
						sw.bonePos[player,ii].z * scale);
				}
			}
		}
	}
	}

