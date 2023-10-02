using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUiHide : MonoBehaviour
{
    [SerializeField] private GameObject _menuPlay;
    [SerializeField] private GameObject _menuSlider;
    [SerializeField] private GameObject _menuQuit;

    public void OnBtnClickHide()
    {
        _menuPlay.SetActive(false);
        _menuSlider.SetActive(false);
        _menuQuit.SetActive(false);
    }
}
