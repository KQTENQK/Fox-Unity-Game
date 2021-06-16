using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transcriptor
{
    static private string _alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890,.[](){}= +-;:\u0022";

    static public string Encode(string message, string gamma)
    {
        string encodedString = string.Empty;

        while (gamma.Length < message.Length)
        {
            gamma += gamma;
            if (gamma.Length > message.Length)
                gamma = gamma.Remove(message.Length);

        }

        int C = 0;
        int T = 0;
        int G = 0;

        for (int i = 0; i < message.Length; i++)
        {
            for (int k = 0; k < _alphabet.Length; k++)
            {
                if (gamma[i] == _alphabet[k])
                    G = k;

                if (message[i] == _alphabet[k])
                    T = k;
            }

            C = (T + G) % _alphabet.Length;
            encodedString += _alphabet[C];
        }

        return encodedString;
    }

    static public string Decode(string message, string gamma)
    {
        string decodedString = string.Empty;

        while (gamma.Length < message.Length)
        {
            gamma += gamma;
            if (gamma.Length > message.Length)
                gamma = gamma.Remove(message.Length);

        }

        int C = 0;
        int T = 0;
        int G = 0;

        for (int i = 0; i < message.Length; i++)
        {
            for (int k = 0; k < _alphabet.Length; k++)
            {
                if (gamma[i] == _alphabet[k])
                    G = k;

                if (message[i] == _alphabet[k])
                    C = k;
            }

            T = (C - G + _alphabet.Length) % _alphabet.Length;
            decodedString += _alphabet[T];
        }

        return decodedString;
    }
}
