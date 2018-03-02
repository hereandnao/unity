using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;


public partial class Eyes : MonoBehaviour
{
	public Transform eyeL;
	public Transform eyeR;

	private List<GameObject> eyeL_leds;
	private List<GameObject> eyeR_leds;

	GameObject[,] eyeMatrix;		
	GameObject[,] rotated;

	
	private void Start()
	{
		// Creating two lists of childrens for left eye and right eye
		eyeL_leds = eyeL.Cast<Transform>().ToList().ConvertAll<GameObject>(t => t.gameObject);
		eyeR_leds = eyeR.Cast<Transform>().ToList().ConvertAll<GameObject>(t => t.gameObject);


		rotated = new GameObject[8,8];

		transform_list_to_array(eyeL_leds);
		rotated = RotateMatrix(eyeMatrix, 8);
		rotated = RotateMatrix(eyeMatrix, 8);
		rotated = RotateMatrix(eyeMatrix, 8);

	//	print(eyeMatrix[0,0]);
	//	print(eyeMatrix[1,0]);
	//	print(eyeMatrix[2,0]);

		
		print(rotated[0,0]);
                            		print(rotated[1,0]);
                            		print(rotated[2,0]);
		print(rotated[3,0]);
		print(rotated[4,0]);
		print(rotated[5,0]);
		print(rotated[6,0]);
		print(rotated[7,0]);
		print(rotated[8,0]);
		
	//	reset_matrix(eyeMatrix);
		
// 		print_eyes(heart_test_bmp);


	}

	void transform_list_to_array(List<GameObject> eye)
	{
		int i = 0;
		int j = 0;
		int k = 0;
		eyeMatrix = new GameObject[8,8];
		while (j < 8)
		{
			i = 0;
			while (i < 8)
			{
				eyeMatrix[i, j] = eye[k];
				k++;
				i++;
	//			print(k);
			}
			j++;
		}
	}
	
	
	
	
	
	static GameObject[,] RotateMatrix(GameObject[,] matrix, int n) {
//		GameObject[,] ret = new GameObject[n, n];
//
//		for (int i = 0; i < n; ++i) {
//			for (int j = 0; j < n; ++j) {
//				ret[i, j] = matrix[j, i];
//			}
//		}
//
//		return ret;
		
		GameObject [,] newArray = new GameObject[n,n];

		for (int i = 0; i<8; i++)
		{
			for (int j=0; j<8; j++)
			{
				newArray[Mathf.Abs(j-7), i] = matrix[i,j];
			}
		}
		return newArray;
	}

	void reset_matrix(GameObject[,] matrix)
	{
		int i = 0;
		int j = 0;
		while (j < 8)
		{
			i = 0;
			while (i < 8)
			{
				matrix[i, j].SetActive(false);
				i++;
			}
			j++;
		}
	}
	
	
	
	void print_eyes(byte[] x)
	{
		int i = 0;

		while (i < 8)
		{
			if ((x[i] & 1) == 1) // B000000101 & 00000001 == 1 
			{
			//			eyeL_leds[(8 * i) + 7].SetActive(true);
				eyeMatrix[7, i].SetActive(true);
			}
			if ((x[i] & 2) == 2)
			{
			//			eyeL_leds[(8 * i) + 6].SetActive(true);
				eyeMatrix[6, i].SetActive(true);
			}
			if ((x[i] & 4) == 4)
			{
			//			eyeL_leds[(8 * i) + 5].SetActive(true);
				eyeMatrix[5, i].SetActive(true);
			}
			if ((x[i] & 8) == 8)
			{
			//			eyeL_leds[(8 * i) + 4].SetActive(true);
				eyeMatrix[4, i].SetActive(true);
			}
			if ((x[i] & 16) == 16)
			{
				eyeMatrix[3, i].SetActive(true);
			//	eyeL_leds[(8 * i) + 3].SetActive(true);
			}
			if ((x[i] & 32) == 32)
			{
				eyeMatrix[2, i].SetActive(true);
			//	eyeL_leds[(8 * i) + 2].SetActive(true);
			}
			if ((x[i] & 64) == 64)
			{
				eyeMatrix[1, i].SetActive(true);
			//			eyeL_leds[(8 * i) + 1].SetActive(true);
			}
			if ((x[i] & 128) == 128)
			{
			//			eyeL_leds[(8 * i) + 0].SetActive(true); */
				eyeMatrix[0, i].SetActive(true);
			}
			i++; 
		}
	}
	
	private byte[] small_eyeR_bmp =
		{
			24,
			24,
			0,
			0,
			0,
			0,
			0,
			0
		},

		small_eyeL_bmp =
		{
			4, //B00000101
			1, // B00000001
			1,
			1,
			4,
			4,
			1,
			1
		},
		heart_test_bmp =
		{
			56,
			124,
			126,
			63,
			126,
			124,
			56,
			0,
		};
}