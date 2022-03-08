//Resourses https://wiki.unity3d.com/index.php/MD5


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util_Security : MonoBehaviour
{

	/// <summary>
	/// Всегда возвращает одно и то же значение если входные данные те же
	/// </summary>
	public static string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);

		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);

		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";

		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}

		return hashString.PadLeft(32, '0');
	}

	/// <summary>
	/// Всегда возвращает одно и то же значение если входные данные те же
	/// </summary>
	public static string Sha1Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);

		// encrypt bytes
		System.Security.Cryptography.SHA1CryptoServiceProvider provider = new System.Security.Cryptography.SHA1CryptoServiceProvider();
		byte[] hashBytes = provider.ComputeHash(bytes);

		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";

		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}

		return hashString.PadLeft(32, '0');
	}
}
