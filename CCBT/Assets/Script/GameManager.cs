using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]private BoardManager boardManager;
    private int SaveBoardVertical;
    private int SaveBoardBeside;
    private AudioSource MainAudio;
    [SerializeField] private AudioSource TimerAudio;
    [SerializeField] private AudioClip ClearMassAudio;
    [SerializeField] private AudioClip BombAudio;
    [SerializeField] private AudioClip ClearGameAudio;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private TextMeshProUGUI Timertext;
    [SerializeField] private TextMeshProUGUI text;
    private bool isChoice = false;
    private int ClearMassNum = 0;

    private float Timer = 0;
    [SerializeField] private float MaxTime;
    [SerializeField]private float BasePitchUpTime;
    private float PitchUpTime;

    private bool isGamePlay = true;

    private void Awake()
    {
        PitchUpTime += BasePitchUpTime;
        MainAudio = GetComponent<AudioSource>();
        _input.actions["Finish"].started += EndGame;

        _input.actions["00"].started += AaAction;
        _input.actions["10"].started += BaAction;
        _input.actions["20"].started += CaAction;
        _input.actions["30"].started += DaAction;
        _input.actions["40"].started += EaAction;
        _input.actions["01"].started += AbAction;
        _input.actions["11"].started += BbAction;
        _input.actions["21"].started += CbAction;
        _input.actions["31"].started += DbAction;
        _input.actions["41"].started += EbAction;
        _input.actions["02"].started += AcAction;
        _input.actions["12"].started += BcAction;
        _input.actions["22"].started += CcAction;
        _input.actions["32"].started += DcAction;
        _input.actions["42"].started += EcAction;
        _input.actions["03"].started += AdAction;
        _input.actions["13"].started += BdAction;
        _input.actions["23"].started += CdAction;
        _input.actions["33"].started += DdAction;
        _input.actions["43"].started += EdAction;
        _input.actions["04"].started += AeAction;
        _input.actions["14"].started += BeAction;
        _input.actions["24"].started += CeAction;
        _input.actions["34"].started += DeAction;
        _input.actions["44"].started += EeAction;

        _input.actions["00"].canceled += UpKey;
        _input.actions["10"].canceled += UpKey;
        _input.actions["20"].canceled += UpKey;
        _input.actions["30"].canceled += UpKey;
        _input.actions["40"].canceled += UpKey;
        _input.actions["01"].canceled += UpKey;
        _input.actions["11"].canceled += UpKey;
        _input.actions["21"].canceled += UpKey;
        _input.actions["31"].canceled += UpKey;
        _input.actions["41"].canceled += UpKey;
        _input.actions["02"].canceled += UpKey;
        _input.actions["12"].canceled += UpKey;
        _input.actions["22"].canceled += UpKey;
        _input.actions["32"].canceled += UpKey;
        _input.actions["42"].canceled += UpKey;

        _input.actions["03"].canceled += UpKey;
        _input.actions["13"].canceled += UpKey;
        _input.actions["23"].canceled += UpKey;
        _input.actions["33"].canceled += UpKey;
        _input.actions["43"].canceled += UpKey;

        _input.actions["04"].canceled += UpKey;
        _input.actions["14"].canceled += UpKey;
        _input.actions["24"].canceled += UpKey;
        _input.actions["34"].canceled += UpKey;
        _input.actions["44"].canceled += UpKey;

        
    }
  

    private void StopGame()
    {
        _input.actions["00"].started -= AaAction;
        _input.actions["10"].started -= BaAction;
        _input.actions["20"].started -= CaAction;
        _input.actions["30"].started -= DaAction;
        _input.actions["40"].started -= EaAction;
        _input.actions["01"].started -= AbAction;
        _input.actions["11"].started -= BbAction;
        _input.actions["21"].started -= CbAction;
        _input.actions["31"].started -= DbAction;
        _input.actions["41"].started -= EbAction;
        _input.actions["02"].started -= AcAction;
        _input.actions["12"].started -= BcAction;
        _input.actions["22"].started -= CcAction;
        _input.actions["32"].started -= DcAction;
        _input.actions["42"].started -= EcAction;
        _input.actions["03"].started -= AdAction;
        _input.actions["13"].started -= BdAction;
        _input.actions["23"].started -= CdAction;
        _input.actions["33"].started -= DdAction;
        _input.actions["43"].started -= EdAction;
        _input.actions["04"].started -= AeAction;
        _input.actions["14"].started -= BeAction;
        _input.actions["24"].started -= CeAction;
        _input.actions["34"].started -= DeAction;
        _input.actions["44"].started -= EeAction;

        _input.actions["00"].canceled -= UpKey;
        _input.actions["10"].canceled -= UpKey;
        _input.actions["20"].canceled -= UpKey;
        _input.actions["30"].canceled -= UpKey;
        _input.actions["40"].canceled -= UpKey;
        _input.actions["01"].canceled -= UpKey;
        _input.actions["11"].canceled -= UpKey;
        _input.actions["21"].canceled -= UpKey;
        _input.actions["31"].canceled -= UpKey;
        _input.actions["41"].canceled -= UpKey;
        _input.actions["02"].canceled -= UpKey;
        _input.actions["12"].canceled -= UpKey;
        _input.actions["22"].canceled -= UpKey;
        _input.actions["32"].canceled -= UpKey;
        _input.actions["42"].canceled -= UpKey;

        _input.actions["03"].canceled -= UpKey;
        _input.actions["13"].canceled -= UpKey;
        _input.actions["23"].canceled -= UpKey;
        _input.actions["33"].canceled -= UpKey;
        _input.actions["43"].canceled -= UpKey;

        _input.actions["04"].canceled -= UpKey;
        _input.actions["14"].canceled -= UpKey;
        _input.actions["24"].canceled -= UpKey;
        _input.actions["34"].canceled -= UpKey;
        _input.actions["44"].canceled -= UpKey;

        _input.actions["00"].started += Retry;
        _input.actions["10"].started += Retry;
        _input.actions["20"].started += Retry;
        _input.actions["30"].started += Retry;
        _input.actions["40"].started += Retry;
        _input.actions["01"].started += Retry;
        _input.actions["11"].started += Retry;
        _input.actions["21"].started += Retry;
        _input.actions["31"].started += Retry;
        _input.actions["41"].started += Retry;
        _input.actions["02"].started += Retry;
        _input.actions["12"].started += Retry;
        _input.actions["22"].started += Retry;
        _input.actions["32"].started += Retry;
        _input.actions["42"].started += Retry;
        _input.actions["03"].started += Retry;
        _input.actions["13"].started += Retry;
        _input.actions["23"].started += Retry;
        _input.actions["33"].started += Retry;
        _input.actions["43"].started += Retry;
        _input.actions["04"].started += Retry;
        _input.actions["14"].started += Retry;
        _input.actions["24"].started += Retry;
        _input.actions["34"].started += Retry;
        _input.actions["44"].started += Retry;
    }
    private void Update()
    {
        if (!isGamePlay)
            return;

        Timer+=Time.deltaTime;
        Timertext.text = (MaxTime-Timer).ToString();
        if(MaxTime-Timer <=0)
        {
            Gameover();
        }
       if(Timer >= PitchUpTime)
        {
            if (TimerAudio.pitch < 1.5f)
                TimerAudio.pitch += 0.1f;
            PitchUpTime += BasePitchUpTime;
        }

    }
   
    private void InputKey(int Vertical,int Beside)
    {
        Debug.Log("押されました"+ boardManager.Board.Length);
        text.text = Vertical.ToString()+" "+Beside.ToString();
        if (boardManager.Board[Vertical, Beside].isClear)
            return;

        if(boardManager.Board[Vertical, Beside].ID==0)
        {
            Bomb();
        }
        MainAudio.PlayOneShot(boardManager.Board[Vertical, Beside].audio);
            if (isChoice)
            {
            if (CheckBoard(boardManager.Board[SaveBoardVertical, SaveBoardBeside], boardManager.Board[Vertical, Beside]))
                ClearMass(boardManager.Board[SaveBoardVertical, SaveBoardBeside], boardManager.Board[Vertical, Beside]);
            else
                Discrepancy();

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
    private bool CheckBoard(MassClass a,MassClass b)
    {
        if (a.ID == b.ID)
            return true;
        else
            return false;
    }

    private void Bomb()
    {
        MainAudio.PlayOneShot(BombAudio);
        isChoice = false;
        Timer += 100;
       // boardManager.Reset();
       // ClearMassNum = 0;
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

    private void Gameover()
    {
        isGamePlay = false;
        StopGame();
        TimerAudio.Stop();
        MainAudio.PlayOneShot(BombAudio);
        boardManager.Reset();
        Timer = 0;
        Debug.Log("ゲームオーバーです");
    }

    private void EndGame(InputAction.CallbackContext obj)
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
    #else
    Application.Quit();//ゲームプレイ終了
    #endif
    }

    private void Retry(InputAction.CallbackContext obj)
    {
        _input.actions["00"].started -= Retry;
        _input.actions["10"].started -= Retry;
        _input.actions["20"].started -= Retry;
        _input.actions["30"].started -= Retry;
        _input.actions["40"].started -= Retry;
        _input.actions["01"].started -= Retry;
        _input.actions["11"].started -= Retry;
        _input.actions["21"].started -= Retry;
        _input.actions["31"].started -= Retry;
        _input.actions["41"].started -= Retry;
        _input.actions["02"].started -= Retry;
        _input.actions["12"].started -= Retry;
        _input.actions["22"].started -= Retry;
        _input.actions["32"].started -= Retry;
        _input.actions["42"].started -= Retry;
        _input.actions["03"].started -= Retry;
        _input.actions["13"].started -= Retry;
        _input.actions["23"].started -= Retry;
        _input.actions["33"].started -= Retry;
        _input.actions["43"].started -= Retry;
        _input.actions["04"].started -= Retry;
        _input.actions["14"].started -= Retry;
        _input.actions["24"].started -= Retry;
        _input.actions["34"].started -= Retry;
        _input.actions["44"].started -= Retry;
        SceneManager.LoadScene("Tutorial");
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
    private void DaAction(InputAction.CallbackContext obj)
    {
        InputKey(3, 0);
    }
    private void EaAction(InputAction.CallbackContext obj)
    {
        InputKey(4, 0);
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
    private void DbAction(InputAction.CallbackContext obj)
    {
        InputKey(3, 1);
    }
    private void EbAction(InputAction.CallbackContext obj)
    {
        InputKey(4, 1);
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
    private void DcAction(InputAction.CallbackContext obj)
    {
        InputKey(3, 2);
    }
    private void EcAction(InputAction.CallbackContext obj)
    {
        InputKey(4, 2);
    }
    private void AdAction(InputAction.CallbackContext obj)
    {
        InputKey(0, 3);
    }
    private void BdAction(InputAction.CallbackContext obj)
    {
        InputKey(1, 3);
    }
    private void CdAction(InputAction.CallbackContext obj)
    {
        InputKey(2, 3);
    }
    private void DdAction(InputAction.CallbackContext obj)
    {
        InputKey(3, 3);
    }
    private void EdAction(InputAction.CallbackContext obj)
    {
        InputKey(4, 3);
    }
    private void AeAction(InputAction.CallbackContext obj)
    {
        InputKey(0, 4);
    }
    private void BeAction(InputAction.CallbackContext obj)
    {
        InputKey(1, 4);
    }
    private void CeAction(InputAction.CallbackContext obj)
    {
        InputKey(2, 4);
    }
    private void DeAction(InputAction.CallbackContext obj)
    {
        InputKey(3, 4);
    }
    private void EeAction(InputAction.CallbackContext obj)
    {
        InputKey(4, 4);
    }
}
