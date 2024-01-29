using Features.StateMachine;
using UnityEngine;

namespace Car.Scripts.States
{
    public class CarRollingState<T>: States<T>
    {
        private CarView _carView;
        public CarRollingState(CarView carView)
        {
            this._carView = carView;
        }

        public override void Awake()
        {
            base.Awake();
            Debug.Log("Car Rolling awaken");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Car Rolling executing");
            _carView.transform.position =
                Vector3.MoveTowards(_carView.transform.position, Vector3.up,
                    Time.deltaTime * 0.1f);
        }
        public override void Exit()
        {
            base.Exit();
        }
    }
}