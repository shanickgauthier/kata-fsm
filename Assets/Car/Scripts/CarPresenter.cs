using UnityEngine;

namespace Car.Scripts
{
    public class CarPresenter
    {
        public CarView carView { get; set; }

        public CarPresenter(CarView carView)
        {
            this.carView = carView;
            carView.OnClick += OnCarClick;
        }

        private void OnCarClick()
        {
            Debug.Log("CarPresenter: OnCarClick");
        }
    }
}