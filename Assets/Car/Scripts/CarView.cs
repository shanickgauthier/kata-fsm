using System;
using Car.Scripts;
using UnityEngine;

public class CarView : MonoBehaviour
{
    public event Action OnClick;
    public event Action OnDestroy;

    private void Awake()
    {
        var controller = gameObject.AddComponent<CarController>();
        controller.Initialize(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnDestroy?.Invoke();
        }
    }

    private void OnMouseDown()
    {
        OnClick?.Invoke();
    }
}
