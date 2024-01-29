using System;
using Car.Scripts.States;
using Features.StateMachine;
using UnityEngine;

namespace Car.Scripts
{
    public class CarController : MonoBehaviour
    {
        private CarView carView { get; set; }
        private Fsm<CarStates> Fsm;
        private CarStoppedState<CarStates> _carStoppedState;
        
        public void Initialize(CarView carView)
        {
            this.carView = carView;
            this.carView.OnClick += OnCarClick;
        }

        private void Awake()
        {
            _carStoppedState = new CarStoppedState<CarStates>(carView);
            Fsm = new Fsm<CarStates>(_carStoppedState);
        }

        private void Update()
        {
            Fsm.OnUpdate();
        }

        private void OnCarClick()
        {
            Fsm.Transition(CarStates.Rolling);
        }

       
    }
}