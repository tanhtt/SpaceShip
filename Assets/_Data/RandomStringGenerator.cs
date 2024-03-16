using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStringGenerator : MonoBehaviour
{
    private const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

    public static string Generate(int length)
    {
        string randomString = "";
        for (int i = 0; i < length; i++)
        {
            randomString += chars[UnityEngine.Random.Range(0, chars.Length)];
        }
        return randomString;
    }
}
