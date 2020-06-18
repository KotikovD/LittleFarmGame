using UnityEngine;


namespace LittleFarmGame.Controllers
{
    /// <summary>
    /// Simple magic camera controller
    /// </summary>
    internal sealed class CameraController : MonoBehaviour
    {

        #region Fileds

        private const float BOTTOM_BOUND = 8.3f;
        private const float MIN_Y = -1.7f;
        private const float MAX_Y = 0.5f;
        private const float MIN_X = -3.1f;
        private const float MAX_X = 3.1f;

        [SerializeField] private Camera _camera;
        private Vector2 _startPosition;

        #endregion


        #region UnityMethods

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                if (_startPosition.y > BOTTOM_BOUND)
                {
                    var positionY = _camera.ScreenToWorldPoint(Input.mousePosition).y - _startPosition.y;
                    var positionX = _camera.ScreenToWorldPoint(Input.mousePosition).x - _startPosition.x;

                    positionX = Mathf.Clamp(transform.localPosition.x - positionX, MIN_X, MAX_X);
                    positionY = Mathf.Clamp(transform.localPosition.y - positionY, MIN_Y, MAX_Y);

                    transform.localPosition = new Vector3(positionX, positionY, transform.localPosition.z);
                }
            }
        }

        #endregion


    }
}