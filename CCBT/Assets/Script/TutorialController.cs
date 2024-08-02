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
    private uint SkipTutorial = 0; 


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

        _input.actions["00"].canceled += Up;
        _input.actions["10"].canceled += Up;
        _input.actions["20"].canceled += Up;
        _input.actions["30"].canceled += Up;
        _input.actions["40"].canceled += Up;
        _input.actions["01"].canceled += Up;
        _input.actions["11"].canceled += Up;
        _input.actions["21"].canceled += Up;
        _input.actions["31"].canceled += Up;
        _input.actions["41"].canceled += Up;
        _input.actions["02"].canceled += Up;
        _input.actions["12"].canceled += Up;
        _input.actions["22"].canceled += Up;
        _input.actions["32"].canceled += Up;
        _input.actions["42"].canceled += Up;
        _input.actions["03"].canceled += Up;
        _input.actions["13"].canceled += Up;
        _input.actions["23"].canceled += Up;
        _input.actions["33"].canceled += Up;
        _input.actions["43"].canceled += Up;
        _input.actions["04"].canceled += Up;
        _input.actions["14"].canceled += Up;
        _input.actions["24"].canceled += Up;
        _input.actions["34"].canceled += Up;
        _input.actions["44"].canceled += Up;


    }

    private void Input(InputAction.CallbackContext obj)
    {
        SkipTutorial++;
        Debug.Log(SkipTutorial);
        if (TutorialStart)
        {
           
            if (!AfterAudioSource.isPlaying||SkipTutorial >=3)
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

                _input.actions["00"].canceled -= Up;
                _input.actions["10"].canceled -= Up;
                _input.actions["20"].canceled -= Up;
                _input.actions["30"].canceled -= Up;
                _input.actions["40"].canceled -= Up;
                _input.actions["01"].canceled -= Up;
                _input.actions["11"].canceled -= Up;
                _input.actions["21"].canceled -= Up;
                _input.actions["31"].canceled -= Up;
                _input.actions["41"].canceled -= Up;
                _input.actions["02"].canceled -= Up;
                _input.actions["12"].canceled -= Up;
                _input.actions["22"].canceled -= Up;
                _input.actions["32"].canceled -= Up;
                _input.actions["42"].canceled -= Up;
                _input.actions["03"].canceled -= Up;
                _input.actions["13"].canceled -= Up;
                _input.actions["23"].canceled -= Up;
                _input.actions["33"].canceled -= Up;
                _input.actions["43"].canceled -= Up;
                _input.actions["04"].canceled -= Up;
                _input.actions["14"].canceled -= Up;
                _input.actions["24"].canceled -= Up;
                _input.actions["34"].canceled -= Up;
                _input.actions["44"].canceled -= Up;
                SceneManager.LoadScene("MainGame");
            }
            
        }
        else
        {
            TutorialStart = true;
            SetTutorial();
        }
    }

    private void Up(InputAction.CallbackContext obj)
    {
        SkipTutorial--;
        Debug.Log(SkipTutorial);
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
