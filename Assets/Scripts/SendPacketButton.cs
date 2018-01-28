using System;
using UnityEngine;
using UnityEngine.UI;

public class SendPacketButton : MonoBehaviour
{
    public LongValue bitsSent;
    public LongValue bitsStored;
    public LongValue maxPacketSize;
    public Text buttonText;

    public long PacketSize
    {
        get
        {
            return Math.Min(maxPacketSize.value, bitsStored.value);
        }
    }

    public void Send()
    {
        var packetSize = PacketSize;
        bitsStored.value -= packetSize;
        bitsSent.value += packetSize;
    }

    private void Update()
    {
        buttonText.text = PacketSize.ToString();
    }
}
