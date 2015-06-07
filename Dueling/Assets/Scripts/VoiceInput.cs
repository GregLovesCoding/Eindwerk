using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


public class VoiceInput : MonoBehaviour {


    private Socket socket;
    private IPHostEntry hostEntry;
    private IPEndPoint endPoint;
    private IPEndPoint sender;
    private EndPoint senderRemote;
    private TcpListener server = null;
    private NetworkStream stream;

    private byte[] msg;
    private string message="";

    private  System.Diagnostics.Process listener;
    



    // Use this for initialization
    void Start()
    {
        listener = System.Diagnostics.Process.Start("VoiceInput.exe");
   
    /*    Thread checkmsg = new Thread(new ThreadStart(CheckMessageTCP));

        checkmsg.Start();*/
       
            
       
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.EnableBroadcast = true;

        hostEntry = Dns.Resolve(Dns.GetHostName());
        endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);
        socket.Bind(endPoint);
        //CheckMessage();
        CheckMessageTCP();

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

        if (!message.Equals(""))
        {
            gameObject.SendMessage("RecognizeSpell", message.Remove(0, 5));
            message = "";
        }


    }

    void CheckMessage()
    {
   
        sender = new IPEndPoint(IPAddress.Any, 0);
        senderRemote = (EndPoint)sender;
        msg = new byte[16];

        Thread thread = new Thread(new ThreadStart(ReceiveMessage));
        thread.Start();
    }

    void CheckMessageTCP() {
        try
        {

           
            TcpListener myList = new TcpListener(GetLocalIP(), 8001);

            //start listening
            myList.Start();

            Socket socket = myList.AcceptSocket();

            byte[] msg = new byte[100];

            //receive message
            int k = socket.Receive(msg);
            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(msg[i]));

            ASCIIEncoding asen = new ASCIIEncoding();
            socket.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\nSent Acknowledgement");
            /* clean up */
            socket.Close();
            myList.Stop();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
  }   
    
    

    void ReceiveMessage()
    {
    
      

        socket.ReceiveFrom(msg, ref senderRemote);
        message = System.Text.Encoding.UTF8.GetString(msg);

        Debug.Log(message.Remove(0, 5));
        ReceiveMessage();

    }

    void OnApplicationQuit()
    {
        socket.Close();
        listener.Close();
    }


     


}
