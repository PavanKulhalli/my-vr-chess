﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour {

    public Material selected_material;
    public Material nextmove_material;
    private Material original_material;
    private string piece_type;
    private int who;
    public GameObject P;
    private GameObject temp_piece = null;
    public board B;
    private bool occupied;

	// Use this for initialization
	void Start () {
        original_material = GetComponent<Renderer>().material;
        temp_piece = P;
        occupied = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pointed()
    {
        if (B.status == 0)
        {
            if (temp_piece != null && ((piece)temp_piece.GetComponent(typeof(piece))).side == B.next)
                GetComponent<Renderer>().material = selected_material;
        }
        else
        {
            if (temp_piece == null || ((piece)temp_piece.GetComponent(typeof(piece))).side != B.next)
                GetComponent<Renderer>().material = nextmove_material;
        }
        
    }

    public void notpointed()
    {
        if (occupied==false)
            GetComponent<Renderer>().material = original_material;
    }

    public void clickon()
    {
        if (B.status==0)
        {
            if (temp_piece != null && ((piece)temp_piece.GetComponent(typeof(piece))).side == B.next)
            {
                occupied = true;
                B.occupied_grid = this;
                B.status = 1;
                ((piece)temp_piece.GetComponent(typeof(piece))).goup();
            }
        }
        else
        {
            if (B.occupied_grid == this)
            {
                occupied = false;
                B.occupied_grid = null;
                B.status = 0;
                ((piece)temp_piece.GetComponent(typeof(piece))).godown();
            }
        }
    }
}
