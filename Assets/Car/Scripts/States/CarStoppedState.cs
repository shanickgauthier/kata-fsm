using Features.StateMachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Car.Scripts.States
{
    public class CarStoppedState<T> : States<T>
    {
        private CarView _carView;
        public CarStoppedState(CarView carView)
        {
            this._carView = carView;
        }

        public override void Awake()
        {
            Debug.Log("Car stopped awake");
        }

        public override void Execute()
        {
            Debug.Log("Car stopped execute");
        }
    }
}