using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
[CustomPropertyDrawer (typeof (BadEggStudio.Utils.Record))]
public class AnySingleLineSerializableDictionaryProperty : SingleLineSerializableDictionaryPropertyDrawer {}
#endif