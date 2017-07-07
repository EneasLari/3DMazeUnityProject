using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;

public class CreateMaze : MonoBehaviour {

	public GameObject R;
	public GameObject G;
	public GameObject B;
	public GameObject T1;
	public GameObject T2;
	public GameObject T3;
	public GameObject botwall;
	public GameObject topwall;
	public GameObject w1;
	public GameObject w2;

	public int L;
	public int N;
	public int K;
	public int size=6;

	void readFile()
	{
		int counter = 0;
		string line;
		int x = 0;
		int y = -1;
		int z = 0;
		// Read the file and display it line by line.
		System.IO.StreamReader file =  new System.IO.StreamReader("maze.txt");
		while((line = file.ReadLine()) != null)
		{
			Debug.Log (line);
			//
			//char points={' ', "  "};

			counter++;
			if(line.Contains("L="))
			{
				string[] array = line.Split ('=');
				L= Int32.Parse (array[1]);

			}
			else if(line.Contains("N="))
			{
				string[] array = line.Split ('=');
				N= Int32.Parse (array[1]);

			}
			else if (line.Contains ("K=")) {
				string[] array = line.Split ('=');
				K = Int32.Parse (array [1]);

			}
			else if (line.Contains ("LEVEL")){
				y++;
				//line = file.ReadLine();
			}
			string[] words=line.Split(' ');
			foreach(string s in words)
			{
				
				if (s.Equals ("E")) 
				{
					
					x++;
					if (x == N) {
						z++;
						x = 0;
						if (z == N)
							z =0;
					}
				}
				else if (s.Equals ("R")) 
				{
					Instantiate (R, new Vector3 (x*size, y*size, z*size), Quaternion.identity);

					x++;
					if (x == N) {
						z++;
						x = 0;
						if (z == N)
							z =0;
					}
				}
				else if (s.Equals ("B")) 
				{
					Instantiate (B, new Vector3 (x*size, y*size, z*size), Quaternion.identity);

					x++;
					if (x == N) {
						z++;
						x = 0;
						if (z == N)
							z =0;
					}
				}
				else if (s.Equals ("G")) 
				{
					Instantiate (G, new Vector3 (x*size, y*size, z*size), Quaternion.identity);

					x++;
					if (x == N) {
						z++;
						x = 0;
						if (z == N)
							z =0;
					}
						
				}
				else if (s.Equals ("T1")) 
				{
					Instantiate (T1, new Vector3 (x*size, y*size, z*size), Quaternion.identity);
					x++;
					if (x == N) {
						z++;
						x = 0;
						if (z == N)
							z =0;
					}
				}
				else if (s.Equals ("T2")) 
				{
					Instantiate (T2, new Vector3 (x*size, y*size, z*size), Quaternion.identity);
					x++;
					if (x == N) {
						z++;
						x = 0;
						if (z == N)
							z =0;
					}
				}
				else if (s.Equals ("T3")) 
				{
					Instantiate (T3, new Vector3 (x*size, y*size, z*size), Quaternion.identity);
					x++;
					if (x == N) {
						z++;
						x = 0;
						if (z == N)
							z =0;
					}
				}
			}
				
		}

		file.Close();
	}

	void Start () {
		R.transform.localScale = new Vector3 (size,size,size);
		G.transform.localScale = new Vector3 (size,size,size);
		B.transform.localScale = new Vector3 (size,size,size);
		T1.transform.localScale = new Vector3 (size,size,size);
		T2.transform.localScale = new Vector3 (size,size,size);
		T3.transform.localScale = new Vector3 (size,size,size);
		readFile ();

		Instantiate(botwall, new Vector3 ((float)(((size*N) / 2)-3) , (float)(-3.5) , (float)(((size * N )/2)-3)), Quaternion.identity);
		botwall.transform.localScale = new Vector3 (size*N,1,size*N);

		Instantiate(topwall, new Vector3 ((float)(((size*N) / 2)-3) , (float)((L)*size+3.5) , (float)(((size * N )/2)-3)), Quaternion.identity);
		topwall.transform.localScale = new Vector3 (size*N,1,size*N);

		Instantiate(w1, new Vector3 ((float)(-3.5) , (float)((L*size)/2-3) , (float)(((size * N )/2)-3)), Quaternion.identity);
		w1.transform.localScale = new Vector3 (1,size*L,size*N);

		Instantiate(w1, new Vector3 ((float)((N-1)*size+3.5) , (float)((L*size)/2-3) , (float)(((size * N )/2)-3)), Quaternion.identity);
		w1.transform.localScale = new Vector3 (1,size*L,size*N);

		Instantiate(w2, new Vector3 ((float)(((size * N )/2)-3) , (float)((L*size)/2-3) ,(float)(-3.5) ), Quaternion.identity);
		w2.transform.localScale = new Vector3 (size*N,size*L,1);

		Instantiate(w2, new Vector3 ((float)(((size * N )/2)-3) , (float)((L*size)/2-3) ,(float)(size*(N-1)+3.5) ), Quaternion.identity);
		w2.transform.localScale = new Vector3 (size*N,size*L,1);
	}
}
		