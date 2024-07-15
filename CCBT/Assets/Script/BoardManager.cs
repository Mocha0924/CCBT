using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class BoardManager : MonoBehaviour
{
    public List<MassClass> massData = new List<MassClass>();
    public int Length;
    public MassClass[,] Board;

    private void Awake()
    {
        Board = new MassClass[Length,Length];
        SetBoard();
        Shuffle(Board);
    }

  
    private void SetBoard()
    {
        int check = 0;
        int DataID = 1;
        for(int i = 0;i < Length;i++)
        {
            for(int j = 0;j < Length;j++)
            {
                if(i>=Length-1&&j>=Length-1)
                    Board[Length - 1, Length - 1] = massData[0];
                else
                {
                    Board[i, j] = massData[DataID];
                    Board[i, j].isClear = false;
                    check++;
                    if (check >= 2)
                    {
                        DataID++;
                        check = 0;
                    }
                }
               
                   
            }
           
        }
      

    }

    private void Shuffle(MassClass[,]board)
    {
        Debug.Log("É{Å[ÉhÇï¿Ç◊ë÷Ç¶Ç‹Ç∑");
        for (int i = 0; i < Length; i++)
        {
            for(int j = 0; j < Length; j++)
            {
                MassClass temp = board[i,j];

                int IrandomIndex = Random.Range(0, Length);
                int JrandomIndex = Random.Range(0, Length);

                board[i,j] = board[IrandomIndex,JrandomIndex];

                board[IrandomIndex, JrandomIndex] = temp;
            }
           
        }
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Length; j++)
            {
                Debug.Log(board[i, j].ID);
            }

        }

    }

    public void Reset()
    {
        SetBoard();
        Shuffle(Board);
    }
}
