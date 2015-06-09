using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class KinectInput : MonoBehaviour
{


    private Socket socket;
    private IPHostEntry hostEntry;
    private IPEndPoint endPoint;
    private IPEndPoint sender;
    private EndPoint senderRemote;
    private TcpListener server = null;
    private Thread listenerThread;
     
    private NetworkStream stream;

    private byte[] msg;
    private string message = "";

    private System.Diagnostics.Process listener;




    // Use this for initialization
    void Start()
    {

    
       /* System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
        listener.StartInfo = startInfo;
        */
        listener = System.Diagnostics.Process.Start("VoiceInput.exe");
       
        listenerThread=new Thread(new ThreadStart(CheckMessageTCP));
       // CheckMessageTCP();
        listenerThread.Start();
    }

    public IPAddress GetLocalIP()
    {
        IPHostEntry host;
        IPAddress localIP = null;
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip;
            }
        }
        return localIP;
    }

    // Update is called once per frame
    void Update()
    {

        if (!message.Equals("")){
            if(message.ToUpper().Contains("CAST"))
        {
            gameObject.SendMessage("RecognizeSpell", message.Remove(0, 5));
            message = "";
        }
            else if(message.ToUpper().Contains("GESTURE")){
                gameObject.SendMessage("RecognizeGesture");
            }
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("abort succes");
            listenerThread.Abort();
            listener.CloseMainWindow();
            listener.Close();
            socket.Close();
            server.Stop();
        }
    }

    void CheckMessageTCP()
    {
        try
        {


            server = new TcpListener(GetLocalIP(), 8001);

            //start listening
            server.Start();

            Socket socket = server.AcceptSocket();

            byte[] msg = new byte[100];

            //receive message
            int k = socket.Receive(msg);
    
            message= System.Text.Encoding.Default.GetString(msg);
          

            ASCIIEncoding asen = new ASCIIEncoding();
            socket.Send(asen.GetBytes("The string was received by the server."));
            Debug.Log("\nSent Acknowledgement");
            /* clean up */
            socket.Close();
            server.Stop();
        }
        catch (Exception e)
        {
            Debug.Log("Error..... " + e.StackTrace);
        }

        CheckMessageTCP();
    }



    void OnApplicationQuit()
    {
        listenerThread.Abort();
        listener.Close();
    }





}
