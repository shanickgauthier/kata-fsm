using System;
using System.Collections;
using System.Threading.Tasks;
using Features.StateMachine;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Car.Scripts.States
{
    public class CarDestroyingState<T> : States<T>
    {
        private readonly CarView _carView;
        private readonly Action _onFinished;

        public CarDestroyingState(CarView carView, Action onFinished)
        {
            _carView = carView;
            _onFinished = onFinished;
        }

        public override void Awake()
        {
            base.Awake();

            DestroyRoutine();
        }

        public override void Execute()
        {
            base.Execute();
            
            _carView.transform.Rotate(Vector3.forward, Time.deltaTime * 1000);
        }

        public override void Exit()
        {
            Debug.Log("Destroying State Exit");
            Object.Destroy(_carView.gameObject);

        }

        public async Task DestroyRoutine()
        {
            await Task.Delay(3000);
            Debug.Log("Destroying State Invoke Finished");
            _onFinished?.Invoke();

        }
    }
}