using Godot;
using System;

public partial class MainMenuScript : Control
{

	private void _on_start_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/TestScene.tscn");
	}
	private void _on_settings_pressed()
	{		Control Settings = GetParent().GetNode<Control>("SettingsScreen");

		if(Settings == null) { GD.Print("No node found"); return; }
		if(!Settings.HasMethod("_set_last_screen")) { GD.Print("No such method found"); return; }

		Settings.Call("_set_last_screen", this);
		Settings.Visible = true;

		this.Visible = false;
	}

	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}


