using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FigureBackupController : MonoBehaviour {

	private Stack<FigureBackup> figureBackup = new Stack<FigureBackup>();
	private int backupSteps;
	private const int MAX_BACKUP_STEPS = 3;
	
	public FigureBackupController()
	{
		figureBackup = new Stack<FigureBackup>();
		backupSteps = 0;
	}
	
	public bool IsThereBackupSteps()
	{
		return backupSteps != 0 ? true : false;
	}
	
	public FigureBackup RestoreFigures()
	{
		FigureBackup restoredFigures = new FigureBackup();
		if (IsThereBackupSteps())
		{
			restoredFigures = figureBackup.Pop(); // past backup here
			backupSteps--;
		}
		
		return restoredFigures;
	}
	
	public void AddFigures(Figure firstFigure, Figure secondFigure)
	{
		figureBackup.Push(new FigureBackup(firstFigure, secondFigure));
		if(backupSteps < MAX_BACKUP_STEPS)
			backupSteps++;
	}
}
