using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FedbckAnim : MonoBehaviour
{
    private Vector3 initialSize;


    private bool selected;

    public float UpgradeSize;
    private void Awake()
    {
        initialSize = transform.localScale;
    }
    private void Update()
    {
        if (selected == true)
        {
            ChangeSize(UpgradeSize);

        }
        else
        {
            ChangeSize(1);

        }

    }
    public void touchOver() => selected = true;

    public void touchExit() => selected = false;

    void ChangeSize(float multiplyValue)
    {

        if (Mathf.Abs(Vector3.Distance(initialSize * multiplyValue, transform.localScale)) > 0.05)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, initialSize * multiplyValue, 0.1f);
        }

    }

    public void Bounce()
    {
        StartCoroutine(BounceSize());
    }

    IEnumerator BounceSize()
    {
        touchOver();
        yield return new WaitForSeconds(0.2f);
        touchExit();
    }

}
