using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBarrier : MonoBehaviour
{
    [SerializeField] private bool isLeftBarrier;
    private bool onLeftBarrierRing;
    private bool onRightBarrierRing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(isLeftBarrier)
            {
                onLeftBarrierRing = true;
            }
            else
            {
                onRightBarrierRing = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onLeftBarrierRing = false;
            onRightBarrierRing = false;
        }
    }

    public bool GetOnLeftBarriering()
    {
        return onLeftBarrierRing;
    }

    public bool GetOnRightRarriering()
    {
        return onRightBarrierRing;
    }
}
