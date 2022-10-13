using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;

public class Dot : MonoBehaviour
{
    
    private bool isMatched = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    Board board;
    GameObject leftDot1, rightDot1, downDot1, upDot1;

    IObjectPool<Dot> _pool;
    public void SetPool(IObjectPool<Dot> pool) => _pool = pool;
    
    void Start()
    {
        board = FindObjectOfType<Board>();
    }
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("FirstTouch");
        FindMatches(0);
    }
   

    void FindMatches(int pos)
    {
        if (transform.position.x >= 0 && transform.position.x <= board.width -1 && !isMatched)
        {
            Debug.Log("X: " + transform.position.x + "   Y: " + transform.position.y );
            if (!(transform.position.x == 0) && !(pos == 1))
            {
                leftDot1 = board.allDots[(int)transform.position.x - 1, (int)transform.position.y];    
                if (leftDot1.CompareTag(this.gameObject.tag))
                {
                    isMatched = true;
                    leftDot1.GetComponent<Dot>().FindMatches(2);   
                }
            }
            
            if(!(transform.position.x == board.width-1) && !(pos == 2))
            {
                rightDot1 = board.allDots[(int)transform.position.x + 1, (int)transform.position.y];
                if (rightDot1.CompareTag(this.gameObject.tag))
                {
                    isMatched = true;
                    rightDot1.GetComponent<Dot>().FindMatches(1);
                }
            }

            if (!(transform.position.y == 0) && !(pos == 3))
            {
                downDot1 = board.allDots[(int)transform.position.x, (int)transform.position.y - 1];    
                if (downDot1.CompareTag(this.gameObject.tag))
                {
                    isMatched = true;
                    downDot1.GetComponent<Dot>().FindMatches(4);   
                }
            }

            if (!(transform.position.y == board.height-1) && !(pos == 4))
            {
                upDot1 = board.allDots[(int)transform.position.x, (int)transform.position.y + 1];    
                if (upDot1.CompareTag(this.gameObject.tag))
                {
                    isMatched = true;
                    upDot1.GetComponent<Dot>().FindMatches(3);   
                }
            }

            if (!isMatched && !(pos == 0))
            {
                isMatched = true;
            }

            if (isMatched)
            {
                spriteRenderer.color = new Color(0f, 0f, 0f, .2f);
            }
        }
    }


}
