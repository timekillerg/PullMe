using UnityEngine;
using System.Collections;

public class FigureBackup : MonoBehaviour {

	public Figure firstFigure { get; set; }
	public Figure secondFigure { get; set; }
	
	public FigureBackup()
	{
		
	}
	
	public FigureBackup(Figure _firstFigure, Figure _secondFigure)
	{
		firstFigure = _firstFigure;
		secondFigure = _secondFigure;
	}
}
