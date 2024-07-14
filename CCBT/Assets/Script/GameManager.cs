using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    private BoardManager boardManager;
    private int SaveBoardVertical;
    private int SaveBoardBeside;
    private AudioSource MainAudio;
    [SerializeField] private AudioClip ClearMassAudio;
    [SerializeField] private AudioClip BombAudio;
    [SerializeField] private AudioClip ClearGameAudio;
    [SerializeField] private PlayerInput _input;

    private bool isChoice = false;
    private int ClearMassNum = 0;

    private void Start()
    {
        MainAudio = GetComponent<AudioSource>();
        boardManager = GetComponent<BoardManager>();
        _input.actions["00"].started += AaAction;
        _input.actions["10"].started += BaAction;
        _input.actions["20"].started += CaAction;
        _input.actions["01"].started += AbAction;
        _input.actions["11"].started += BbAction;
        _input.actions["21"].started += CbAction;
        _input.actions["02"].started += AcAction;
        _input.actions["12"].started += BcAction;
        _input.actions["22"].started += CcAction;

        _input.actions["00"].canceled += UpKey;
        _input.actions["10"].canceled += UpKey;
        _input.actions["20"].canceled += UpKey;
        _input.actions["01"].canceled += UpKey;
        _input.actions["11"].canceled += UpKey;
        _input.actions["21"].canceled += UpKey;
        _input.actions["02"].canceled += UpKey;
        _input.actions["12"].canceled += UpKey;
        _input.actions["22"].canceled += UpKey;


    }
   
    private void InputKey(int Vertical,int Beside)
    {
        Debug.Log("押されました"+ boardManager.Board[Vertical, Beside].ID);
        if (boardManager.Board[Vertical, Beside].isClear)
            return;

       
            MainAudio.PlayOneShot(boardManager.Board[Vertical, Beside].audio);
            if (isChoice)
            {
                int check = CheckBoard(boardManager.Board[SaveBoardVertical, SaveBoardBeside], boardManager.Board[Vertical, Beside]);
                switch (check)
                {
                    case -1: Gameover(); break;
                    case 0: Discrepancy(); break;
                    case 1: ClearMass(boardManager.Board[SaveBoardVertical, SaveBoardBeside], boardManager.Board[Vertical, Beside]); break;
                }
            }
            else
            {
                SaveBoardVertical = Vertical;
                SaveBoardBeside = Beside;
                isChoice = true;
            }
        

       
        
    }

    private void UpKey(InputAction.CallbackContext obj)
    {
        isChoice = false;
    }
    private int CheckBoard(MassClass a,MassClass b)
    {
        if (a.ID == 0)
            return -1;
        if (a.ID == b.ID)
            return 1;
        else
            return 0;
    }

    private void Gameover()
    {
        MainAudio.PlayOneShot(BombAudio);
        isChoice = false;
        boardManager.Reset();
        Debug.Log("ゲームオーバーです");
        ClearMassNum = 0;
    }

    private void Discrepancy()
    {
        isChoice = false;
        Debug.Log("違います");
    }

    private void ClearMass(MassClass a, MassClass b)
    {
        MainAudio.PlayOneShot(ClearMassAudio);
        isChoice = false;
        a.isClear = true;
        b.isClear = true;
        ClearMassNum++;
        if (ClearMassNum >= (boardManager.Length * boardManager.Length - 1) / 2)
            ClearGame();
    }

    private void ClearGame()
    {
        MainAudio.PlayOneShot(ClearGameAudio);
        boardManager.Reset();
        Debug.Log("ゲームクリアです");
        ClearMassNum = 0;
    }

    private void AaAction(InputAction.CallbackContext obj)
    {
        InputKey(0, 0);
    }
    private void BaAction(InputAction.CallbackContext obj)
    {
        InputKey(1, 0);
    }
    private void CaAction(InputAction.CallbackContext obj)
    {
        InputKey(2, 0);
    }

    private void AbAction(InputAction.CallbackContext obj)
    {
        InputKey(0, 1);
    }
    private void BbAction(InputAction.CallbackContext obj)
    {
        InputKey(1, 1);
    }
    private void CbAction(InputAction.CallbackContext obj)
    {
        InputKey(2, 1);
    }

    private void AcAction(InputAction.CallbackContext obj)
    {
        InputKey(0, 2);
    }
    private void BcAction(InputAction.CallbackContext obj)
    {
        InputKey(1, 2);
    }
    private void CcAction(InputAction.CallbackContext obj)
    {
        InputKey(2, 2);
    }
}
