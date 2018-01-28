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
    private float fractionalBits;
    private bool transmitting;
    private long totalBitsToSend;

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
            totalBitsToSend = PacketSize;
            bitsStored.Value -= totalBitsToSend;

            if (animator != null)
            {
                StartCoroutine(TransmitWithAnimation());
            }
            else
            {
                totalTime = transmissionSpeed.Value;
                StartCoroutine(TransmitOverTime());
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
            buttonText.text = string.Format("{0} ({1}%)", totalBitsToSend, (int)(time / totalTime * 100));
        }

        onUpdate.Invoke();
    }

    private IEnumerator TransmitWithAnimation()
    {
        transmitting = true;

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Transmitting"))
        {
            yield return null;
        }

        totalTime = animator.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(TransmitOverTime());
    }

    private IEnumerator TransmitOverTime()
    {
        transmitting = true;

        time = 0.0f;
        fractionalBits = 0.0f;

        var remainingBitsToSend = totalBitsToSend;

        while (time < totalTime)
        {
            time += Time.deltaTime;

            fractionalBits += ((Time.deltaTime / totalTime) * totalBitsToSend);

            if (fractionalBits > 1.0f)
            {
                var newBits = (long)fractionalBits;

                fractionalBits -= newBits;
                remainingBitsToSend -= newBits;

                bitsSent.Value += newBits;
            }

            // if (remainingBitsToSend > 0)
            // {
            //     var amountToSend = (long)((Time.deltaTime / totalTime) * totalBitsToSend);
            //     amountToSend = Math.Min(remainingBitsToSend, Math.Max(amountToSend, 1));

            //     bitsSent.Value += amountToSend;

            //     remainingBitsToSend = Math.Max(0, remainingBitsToSend - amountToSend);
            // }

            yield return null;
        }

        if (remainingBitsToSend > 0)
        {
            bitsSent.Value += remainingBitsToSend;
        }

        transmitting = false;
    }
}
