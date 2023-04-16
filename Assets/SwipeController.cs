using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SwipeController : MonoBehaviour
{
    public UnityEvent LeftFunc;
    public UnityEvent RigthFunc;
    public UnityEvent UpFunc;
    public UnityEvent DownFunc;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwipeControls();
    }

    void SwipeControls()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Vector2.Distance(startTouchPosition, endTouchPosition) > 3)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (Mathf.Abs(endTouchPosition.x - startTouchPosition.x) >= Mathf.Abs(endTouchPosition.y - startTouchPosition.y))
                {
                    if (endTouchPosition.x < startTouchPosition.x)
                    {
                        SwipeLeft();
                    }

                    if (endTouchPosition.x < startTouchPosition.x)
                    {
                        SwipeRigth();
                    }
                }
                else
                {
                    if (endTouchPosition.y < startTouchPosition.y)
                    {
                        SwipeDown();
                    }

                    if (endTouchPosition.y > startTouchPosition.y)
                    {
                        SwipeUp();
                    }
                }
            }
        }
        
    }

    void SwipeLeft()
    {
        LeftFunc.Invoke();
    }

    void SwipeRigth()
    {
        RigthFunc.Invoke();
    }

    void SwipeUp()
    {
        UpFunc.Invoke();
    }

    void SwipeDown()
    {
        DownFunc.Invoke();
    }
}

