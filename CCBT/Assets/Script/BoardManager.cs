using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private MassDataBase massData;
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
                Board[i, j] = massData.MassDataList[DataID];
                Board[i, j].isClear = false;
                check++;
                if (check >= 2)
                {
                    DataID++;
                    check = 0;
                }
                   
            }
           
        }
        Board[Length - 1, Length - 1] = massData.MassDataList[0];

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

       
    }

    public void Reset()
    {
        SetBoard();
        Shuffle(Board);
    }
}
