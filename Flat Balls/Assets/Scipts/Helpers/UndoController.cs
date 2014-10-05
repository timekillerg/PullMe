using UnityEngine;
using System.Collections;

public class UndoController : MonoBehaviour {

	private bool _isPressed;
	public static FigureBackupController _backupController;
	public GameObject FigureGameObject;
	public GameObject LineGameObject;
	public GameObject ParentFigure;
	
	void Start()
	{
		_backupController = new FigureBackupController ();
	}
	
	void OnMouseDown()
	{
		_isPressed = true;
	}
	
	void OnMouseUp()
	{
		if (_isPressed)
		{
			var restoredFigures = new FigureBackup();
			restoredFigures = _backupController.RestoreFigures();
			RestoreFigure(restoredFigures.firstFigure);

			/*
			 * need to add : restore figure number and lines between figures. Paste here
			restoredFigures.secondFigure.Number /= 2;
			restoredFigures.secondFigure.GameObject.GetComponent<FigureNumberController>().Number /= 2;
			*/
			_isPressed = false;
		}
	}
	
	public void RestoreFigure(Figure _figure)
	{
		var newFigure = new Figure (_figure);
		FigureGameObject.GetComponent<FigureNumberController>().Number = newFigure.Number;
		var createdGameObject = (GameObject)Instantiate(FigureGameObject, newFigure.Vector2, Quaternion.identity);
		createdGameObject.name = newFigure.Name;
		createdGameObject.transform.parent = ParentFigure.transform;
		newFigure.GameObject = createdGameObject;
	}
}
