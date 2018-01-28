using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class SendPacketButton : MonoBehaviour
{
    public LongValue bitsSent;
    public LongValue bitsStored;
    public LongValue maxPacketSize;
    public Text buttonText;

    public Animator animator;
    public FloatValue transmissionSpeed;

    public UnityEvent onUpdate;

    private float time;
    private float totalTime;
    private bool transmitting;

    public long PacketSize
    {
        get
        {
            return Math.Min(maxPacketSize.Value, bitsStored.Value);
        }
    }

    public void Send()
    {
        if (!transmitting)
        {
            var packetSize = PacketSize;
            bitsStored.Value -= packetSize;

            if (animator != null)
            {
                StartCoroutine(TransmitWithAnimation(packetSize));
            }
            else
            {
                totalTime = transmissionSpeed.Value;
                StartCoroutine(TransmitOverTime(packetSize));
            }
        }
    }

    public void PlayTransmitAnimation()
    {
        if (animator)
        {
            animator.speed = transmissionSpeed.Value;
            animator.SetTrigger("Transmit");
        }
    }

    protected void Update()
    {
        if (animator)
        {
            buttonText.text = PacketSize.ToString();
        }
        else
        {
            buttonText.text = string.Format("{0} ({1}%)", PacketSize.ToString(), (int)(time / totalTime * 100));
        }


        onUpdate.Invoke();
    }

    private IEnumerator TransmitWithAnimation(long totalBitsToSend)
    {
        transmitting = true;

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Transmitting"))
        {
            yield return null;
        }

        totalTime = animator.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(TransmitOverTime(totalBitsToSend));
    }

    private IEnumerator TransmitOverTime(long totalBitsToSend)
    {
        transmitting = true;

        time = 0.0f;
        var remainingBitsToSend = totalBitsToSend;

        while (time < totalTime)
        {
            time += Time.deltaTime;

            if (remainingBitsToSend > 0)
            {
                var amountToSend = (long)((Time.deltaTime / totalTime) * totalBitsToSend);
                amountToSend = Math.Min(remainingBitsToSend, Math.Max(amountToSend, 1));

                bitsSent.Value += amountToSend;

                remainingBitsToSend = Math.Max(0, remainingBitsToSend - amountToSend);
            }

            yield return null;
        }

        if (remainingBitsToSend > 0)
        {
            bitsSent.Value += remainingBitsToSend;
        }

        transmitting = false;
    }
}
