using UnityEngine;


namespace LittleFarmGame.Models
{
    public abstract class BaseObjectScene : MonoBehaviour
    {


        #region Fields

        protected Transform _transform;
        protected Vector3 _position;
        protected Quaternion _rotation;
        protected Vector3 _scale;
        protected GameObject _instanceObject;
        protected string _name;

        #endregion


        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                InstanceObject.name = _name;
            }
        }

        public Vector3 Position
        {
            get
            {
                if (InstanceObject != null)
                {
                    _position = GetTransform.position;
                }
                return _position;
            }
            set
            {
                _position = value;
                if (InstanceObject != null)
                {
                    GetTransform.position = _position;
                }
            }
        }

        public Vector3 Scale
        {
            get
            {
                if (InstanceObject != null)
                {
                    _scale = GetTransform.localScale;
                }
                return _scale;
            }
            set
            {
                _scale = value;
                if (InstanceObject != null)
                {
                    GetTransform.localScale = _scale;
                }
            }
        }

        public Quaternion Rotation
        {
            get
            {
                if (InstanceObject != null)
                {
                    _rotation = GetTransform.rotation;
                }

                return _rotation;
            }
            set
            {
                _rotation = value;
                if (InstanceObject != null)
                {
                    GetTransform.rotation = _rotation;
                }
            }
        }

        public GameObject InstanceObject
        {
            get { return _instanceObject; }
        }

        public Transform GetTransform
        {
            get { return _transform; }
        }

        #endregion


        #region UnityMethods

        protected virtual void Awake()
        {
            _instanceObject = gameObject;
            _transform = _instanceObject.transform;
        }

        #endregion


        #region Methods

        //public void SaveData()
        //{
        //    if (GetComponent<ISerializable>() != null)
        //        Object.FindObjectOfType<SerializableObjects>().PrefubsForSave.Add(gameObject);
        //}

        #endregion


    }
}