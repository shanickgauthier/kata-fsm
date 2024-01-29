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
        private CarRollingState<CarStates> _carRollingState;
        private CarDestroyingState<CarStates> _carDestroyingState;

        public void Initialize(CarView carView)
        {
            this.carView = carView;
            this.carView.OnClick += OnCarClick;
            this.carView.OnDestroy += OnCarDestroy;
        }
        
        private void Start()
        {
            _carStoppedState = new CarStoppedState<CarStates>(carView);
            _carRollingState = new CarRollingState<CarStates>(carView);
            _carDestroyingState = new CarDestroyingState<CarStates>(carView, OnDestroyFinished);
            
            _carStoppedState.AddTransitionState(CarStates.Rolling, _carRollingState);
            _carStoppedState.AddTransitionState(CarStates.Destroying, _carDestroyingState);
            _carRollingState.AddTransitionState(CarStates.Destroying, _carDestroyingState);
            _carDestroyingState.AddTransitionState(CarStates.Stopped, _carStoppedState);
            
            Fsm = new Fsm<CarStates>(_carStoppedState);
           
        }

        private void OnDestroyFinished()
        {
            Fsm.Transition(CarStates.Stopped);
        }

        private void Update()
        {
            Fsm.OnUpdate();
        }

        private void OnCarClick()
        {
            Fsm.Transition(CarStates.Rolling);
        }
        
        private void OnCarDestroy()
        {
            Fsm.Transition(CarStates.Destroying);
        }

       
    }
}