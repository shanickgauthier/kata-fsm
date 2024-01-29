using System;
using Car.Scripts;
using UnityEngine;

public class CarView : MonoBehaviour
{
    public event Action OnClick;

    private void Awake()
    {
        var controller = gameObject.AddComponent<CarController>();
        controller.Initialize(this);
    }

    private void OnMouseDown()
    {
        OnClick?.Invoke();
    }
}
