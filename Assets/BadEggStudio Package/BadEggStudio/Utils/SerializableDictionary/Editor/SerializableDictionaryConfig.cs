using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomPropertyDrawer (typeof (BadEggStudio.Utils.Record))]
[CustomPropertyDrawer (typeof (BadEggStudio.Localization.LocalizeDB))]
[CustomPropertyDrawer (typeof (BadEggStudio.Localization.FontDB))]
public class AnySingleLineSerializableDictionaryPropertyDrawer : SingleLineSerializableDictionaryPropertyDrawer {}

// [CustomPropertyDrawer(typeof(QuaternionMyClassDictionary))]

[CustomPropertyDrawer (typeof (BadEggStudio.Localization.StringKeyDB))]
public class AnyDoubleLineSerializableDictionaryPropertyDrawer : DoubleLineSerializableDictionaryPropertyDrawer {}
#endif