using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TutorialController : MonoBehaviour
{
    private bool TutorialStart = false;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private AudioSource PlayAudioSource;
    [SerializeField]private AudioSource BeforeAudioSource;
    [SerializeField]private AudioSource AfterAudioSource;
    [SerializeField] private AudioClip PushSound;


    private void Awake()
    {
        _input.actions["Finish"].started += EndGame;
        _input.actions["00"].started += Input;
        _input.actions["10"].started += Input;
        _input.actions["20"].started += Input;
        _input.actions["30"].started += Input;
        _input.actions["40"].started += Input;
        _input.actions["01"].started += Input;
        _input.actions["11"].started += Input;
        _input.actions["21"].started += Input;
        _input.actions["31"].started += Input;
        _input.actions["41"].started += Input;
        _input.actions["02"].started += Input;
        _input.actions["12"].started += Input;
        _input.actions["22"].started += Input;
        _input.actions["32"].started += Input;
        _input.actions["42"].started += Input;
        _input.actions["03"].started += Input;
        _input.actions["13"].started += Input;
        _input.actions["23"].started += Input;
        _input.actions["33"].started += Input;
        _input.actions["43"].started += Input;
        _input.actions["04"].started += Input;
        _input.actions["14"].started += Input;
        _input.actions["24"].started += Input;
        _input.actions["34"].started += Input;
        _input.actions["44"].started += Input;

       
    }

    private void Input(InputAction.CallbackContext obj)
    {
        if(TutorialStart)
        {
            if(!AfterAudioSource.isPlaying)
            {
                _input.actions["00"].started -= Input;
                _input.actions["10"].started -= Input;
                _input.actions["20"].started -= Input;
                _input.actions["30"].started -= Input;
                _input.actions["40"].started -= Input;
                _input.actions["01"].started -= Input;
                _input.actions["11"].started -= Input;
                _input.actions["21"].started -= Input;
                _input.actions["31"].started -= Input;
                _input.actions["41"].started -= Input;
                _input.actions["02"].started -= Input;
                _input.actions["12"].started -= Input;
                _input.actions["22"].started -= Input;
                _input.actions["32"].started -= Input;
                _input.actions["42"].started -= Input;
                _input.actions["03"].started -= Input;
                _input.actions["13"].started -= Input;
                _input.actions["23"].started -= Input;
                _input.actions["33"].started -= Input;
                _input.actions["43"].started -= Input;
                _input.actions["04"].started -= Input;
                _input.actions["14"].started -= Input;
                _input.actions["24"].started -= Input;
                _input.actions["34"].started -= Input;
                _input.actions["44"].started -= Input;
                SceneManager.LoadScene("MainGame");
            }
            
        }
        else
        {
            TutorialStart = true;
            SetTutorial();
        }
    }
    private void EndGame(InputAction.CallbackContext obj)
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
    private void SetTutorial()
    {
        PlayAudioSource.PlayOneShot(PushSound);
        BeforeAudioSource.Stop();
        AfterAudioSource.Play();
    }
}
