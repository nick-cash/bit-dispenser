using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SendPacketButton : MonoBehaviour
{
    public LongValue bitsSent;
    public LongValue bitsStored;
    public LongValue maxPacketSize;
    public Text buttonText;

    public Animator animator;
    public FloatValue transmissionSpeed;

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
        animator.speed = transmissionSpeed.value;
        StartCoroutine(TransmitOverTime(packetSize));
    }

    public void PlayTransmitAnimation()
    {
        animator.speed = transmissionSpeed.value;
        animator.SetTrigger("Transmit");
    }

    private void Update()
    {
        buttonText.text = PacketSize.ToString();
    }

    private IEnumerator TransmitOverTime(long totalBitsToSend)
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Transmitting"))
        {
            yield return null;
        }

        var time = 0.0f;
        var totalTime = animator.GetCurrentAnimatorStateInfo(0).length;
        var remainingBitsToSend = totalBitsToSend;

        while ((time < totalTime) && (remainingBitsToSend > 0))
        {
            time += Time.deltaTime;

            var amountToSend = (long)((Time.deltaTime / totalTime) * totalBitsToSend);
            amountToSend = Math.Min(remainingBitsToSend, Math.Max(amountToSend, 1));

            bitsSent.value += amountToSend;
            remainingBitsToSend = Math.Max(0, remainingBitsToSend - amountToSend);

            yield return null;
        }

        if (remainingBitsToSend > 0)
        {
            bitsSent.value += remainingBitsToSend;
        }
    }
}
