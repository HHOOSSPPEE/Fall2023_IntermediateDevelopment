using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;

/// <summary>
/// This is a serializable Dictionary class I made.
/// Please note that you should always try to create equal amount of keys and values.
/// Only basic methods provided.
/// </summary>
[Serializable]
public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
{
    #region for serialization
    [SerializeField]
    private List<TKey> keys = new List<TKey>();

    [SerializeField]
    private List<TValue> values = new List<TValue>();

    private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

    public TValue this[TKey key]
    {
        get => dictionary[key];
        set
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                Add(key, value);
        }
    }
    public void OnBeforeSerialize()
    {
        // No action needed
    }
    public void OnAfterDeserialize()
    {
        dictionary = new Dictionary<TKey, TValue>();
        for (int i = 0; i < keys.Count; i++)
        {
            dictionary[keys[i]] = values[i];
        }
    }
    #endregion
    #region normal dictionary methods
    public void Add(TKey key, TValue value)
    {
        if (!dictionary.ContainsKey(key))
        {
            keys.Add(key);
            values.Add(value);
            dictionary.Add(key, value);
        }
    }
    /// <summary> I assume this will work </summary>
    public void Remove(TKey key)
    {
        if (!dictionary.ContainsKey(key))
            return;
        int index = keys.IndexOf(key);
        values.RemoveAt(index);
        keys.Remove(key);
        dictionary.Remove(key);
        var temp = dictionary.Keys;
    }
    public Dictionary<TKey, TValue>.KeyCollection Keys() => dictionary.Keys;
    public Dictionary<TKey, TValue>.ValueCollection Values() => dictionary.Values;
    public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);
    public bool TryGetValue(TKey key, out TValue value) => dictionary.TryGetValue(key, out value);
    public void Clear()
    {
        keys.Clear();
        values.Clear();
        dictionary.Clear();
    }
    /// <summary>
    /// Never been tested but I think it will work. If anyone tested, just delete this summary
    /// </summary>
    public bool Equals(SerializableDictionary<TKey, TValue> other)
    {
        if (other.dictionary == null || this.dictionary == null) return false; // Check if null
        if (other.dictionary.Equals(this.dictionary)) return true; // Checks for equality by comparing references
        if (other.dictionary.Count != this.dictionary.Count) return false; // Check by Count
        foreach (var pair in this.dictionary) //Check for equality by keys and values
            if (!other.dictionary.TryGetValue(pair.Key, out TValue value) || !value.Equals(pair.Value))
                return false;
        return true;
    }
    #endregion
    public void PrintDictionary() => Debug.Log(ToString());
    public void PrintDictionaryWithName(string dictionaryName)
    {
        string printContent = dictionaryName + "\r\n" + ToString();
        Debug.Log(printContent);
    }
    override public string ToString()
    {
        string asString = "";
        foreach (var keyValuePair in dictionary)
            asString += $"    {{key = {keyValuePair.Key}, value = {keyValuePair.Value}}}\r\n";
        return asString;
    }
}