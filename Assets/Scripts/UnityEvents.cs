
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[Serializable] public class IntEvent : UnityEvent<int> { }
[Serializable] public class StringEvent : UnityEvent<string> { }
[Serializable] public class ObjectEvent : UnityEvent<GameObject> { }
[Serializable] public class FloatEvent : UnityEvent<float> { }
[Serializable] public class ColorEvent : UnityEvent<Color> { }