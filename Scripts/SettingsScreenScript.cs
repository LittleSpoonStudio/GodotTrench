using Godot;
using System;

public partial class SettingsScreenScript : Control
{
	private Control m_LastScreen = null;
	private void _on_button_pressed()
	{
		m_LastScreen.Visible = true;
		this.Visible = false;
	}

	public void _set_last_screen(Control screen)
	{
		m_LastScreen = screen;
	}
}


