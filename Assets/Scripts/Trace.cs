using System;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour
{
    [Header("Editor setting")]
    public float twoPointsDistanceMinimum;

    private LineRenderer _line;
    private GameObject _lineTarget;
    internal GameObject LineTarget
    {
        get => _lineTarget;
        set
        {
            _lineTarget = value;
            _line.enabled = false;
            _points = new List<Vector3>();
            AddPoint();
        }
    }

    private List<Vector3> _points;
    internal Vector3 LastPoint
    {
        get
        {
            if (_points==null)
            {
                return Vector3.zero;
            }
            return _points[_points.Count - 1];
        }
    }
    
    private void AddPoint()
    {
        var point = _lineTarget.transform.position;
        if (_points.Count>0 && (point-LastPoint).magnitude<twoPointsDistanceMinimum) return;
        _points.Add(point);
        _line.positionCount = _points.Count;
        _line.SetPosition(_points.Count-1,LastPoint);
        _line.enabled = true;
    }

    private void Awake()
    {
        _line=GetComponent<LineRenderer>();
        _line.enabled = false;
        _points = new List<Vector3>();
    }
    private void FixedUpdate()
    {
        if (_lineTarget==null)
        {
            if (FollowCamera.target!=null)
            {
                if (FollowCamera.target.CompareTag("Bullet"))
                {
                    LineTarget = FollowCamera.target;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        AddPoint();
        if (FollowCamera.target==null)
        {
            _lineTarget = null;
        }
    }
}
