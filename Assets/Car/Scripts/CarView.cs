using System;
using Car.Scripts;
using UnityEngine;

public class CarView : MonoBehaviour
{
    public event Action OnClick; 
    private void Awake()
    {
        new CarPresenter(this);
    }

    private void OnMouseDown()
    {
        OnClick?.Invoke();
    }
}
