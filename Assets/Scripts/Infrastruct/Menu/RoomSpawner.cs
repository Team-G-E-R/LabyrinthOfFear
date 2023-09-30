using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private float _distanceBetweenRoom;
    [SerializeField] private int _countRoom;
    [SerializeField] private Camera _camera;
    [SerializeField] private List<GameObject> _poolRoom = new List<GameObject>();

    [SerializeField] private Vector3 _lastPosition;

    private void Awake()
    {
        _lastPosition = new Vector3(-_distanceBetweenRoom, 0, 0);
        for (int i = 0; i < _countRoom; i++)
        {
            var room = Instantiate(Resources.Load<GameObject>(AssetsPath.RoomPath),
                _lastPosition,
                Quaternion.identity);
            _poolRoom.Add(room);
            _lastPosition = room.transform.position;
            _lastPosition.x += _distanceBetweenRoom;
        }

        _lastPosition.x -= _distanceBetweenRoom;
    }

    private void FixedUpdate()
    {
        if (Math.Abs(_camera.transform.position.x - _lastPosition.x) 
            < Math.Abs(_poolRoom[0].transform.position.x- _lastPosition.x)/2)
        {
            for (int i = 0; i < _poolRoom.Count / 4; i++)
            {
                Destroy(_poolRoom[i]);
                var room = Instantiate(Resources.Load<GameObject>(AssetsPath.RoomPath));
                _lastPosition.x += _distanceBetweenRoom;
                room.transform.position = _lastPosition;
                _poolRoom.Add(room);
            }
            _poolRoom.RemoveRange(0,  _poolRoom.Count /4);
            Debug.Log(_poolRoom.Count / 4);
        }
    }
}
