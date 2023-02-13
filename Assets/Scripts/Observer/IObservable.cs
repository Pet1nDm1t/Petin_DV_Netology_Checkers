using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

namespace Checkers
{
    public interface IObservable 
    {
        public Task Serialize(string input);

        public event Action<Coordinate> NextStepReady;

    }
}
