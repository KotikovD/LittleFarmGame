using UnityEngine;


namespace LittleFarmGame.Controllers
{
    /// <summary>
    /// Simple magic camera controller
    /// </summary>
    internal sealed class CameraController : MonoBehaviour
    {
        private const float BOTTOM_BOUND = 8.3f;
        private const float MIN_Z = -10.5f;
        private const float MAX_Z = -5.5f;
        private const float MIN_X = -9f;
        private const float MAX_X = -5f;

        private Vector2 _startPosition;
        [SerializeField] private Camera _camera;
        [SerializeField] private int _dragAntiSpeed = 15;
        [SerializeField] private int _smoothSpeed = 100;


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
                    var positionZ = _camera.ScreenToWorldPoint(Input.mousePosition).y - _startPosition.y;
                    var positionX = _camera.ScreenToWorldPoint(Input.mousePosition).x - _startPosition.x;
                    var desirePosition =
                        new Vector3(Mathf.Clamp(transform.localPosition.x - positionX / _dragAntiSpeed, MIN_X, MAX_X),
                        transform.localPosition.y,
                        Mathf.Clamp(transform.localPosition.z - positionZ / _dragAntiSpeed, MIN_Z, MAX_Z));

                    positionX = Mathf.Lerp(positionX, desirePosition.x, _smoothSpeed * Time.deltaTime);
                    positionZ = Mathf.Lerp(positionZ, desirePosition.z, _smoothSpeed * Time.deltaTime);

                    transform.localPosition = new Vector3(positionX, transform.localPosition.y, positionZ);
                }
            }

        }

    }
}