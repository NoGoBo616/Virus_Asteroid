using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System;
using TMPro;

public class Twitch_Spawn : MonoBehaviour
{
    public string channelName = "tucanal";
    public TMP_InputField channelInput;

    [Header("Prefab a instanciar")]
    public GameObject prefabNPC;

    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;
    private Thread twitchThread;
    private bool running;
    private bool waittime;

    private string messageFromChat = null;
    private string userNikcName = null;

    public void Iniciar()
    {
        channelName = channelInput.text.ToLower();
        running = true;
        twitchThread = new Thread(ConnectToTwitch);
        twitchThread.IsBackground = true;
        twitchThread.Start();
        waittime = true;
    }

    void Update()
    {

        if (!string.IsNullOrEmpty(messageFromChat))
        {
            string msg = messageFromChat.ToLower();
            messageFromChat = null;

            if (msg.Contains("!npc"))
            {
                SpawnNPC();
            }
        }
    }

    public void ConnectToTwitch()
    {
        try
        {
            twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
            reader = new StreamReader(twitchClient.GetStream());
            writer = new StreamWriter(twitchClient.GetStream());

            writer.WriteLine("PASS SCHMOOPIIE");
            writer.WriteLine("NICK justinfan12345");
            writer.WriteLine("JOIN #" + channelName.ToLower());
            writer.Flush();

            Debug.Log("Conectado al chat de Twitch #" + channelName);

            while (running)
            {
                if (twitchClient.Available > 0)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        if (line.StartsWith("PING"))
                        {
                            writer.WriteLine("PONG :tmi.twitch.tv");
                            writer.Flush();
                        }
                        else
                        {
                            if (line.Contains("PRIVMSG"))
                            {
                                int splitPoint = line.IndexOf("!", 1);
                                string user = line.Substring(1, splitPoint - 1);

                                int msgIndex = line.IndexOf(":", 1);
                                string message = line.Substring(msgIndex + 1);

                                Debug.Log(user + ": " + message);
                                messageFromChat = message;
                                userNikcName = user;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error conectando a Twitch: " + e.Message);
        }
    }

    private void OnDestroy()
    {
        running = false;
        if (twitchThread != null && twitchThread.IsAlive)
            twitchThread.Abort();

        if (writer != null) writer.Close();
        if (reader != null) reader.Close();
        if (twitchClient != null) twitchClient.Close();
    }


    public void SpawnNPC()
    {
        if (waittime)
        {
            this.gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-16, 17), UnityEngine.Random.Range(-3.5f, 10), 0);
            GameObject nuevoNPC = Instantiate(prefabNPC, this.gameObject.transform.position, Quaternion.identity);
            nuevoNPC.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = userNikcName;
        }
    }

    IEnumerator CoolDown()
    {
        waittime = false;
        yield return new WaitForSeconds(1);
        waittime = true;
        yield return null;
    }
}
