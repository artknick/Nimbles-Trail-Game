using UnityEngine;
using System.Collections;
using System;

public class Dialog : MonoBehaviour
{
	private static float DIALOG_WINDOW_HEIGHT;
	private static float DIALOG_WINDOW_WIDTH;
	private static float DIALOG_WINDOW_START_Y;
	private static float DIALOG_WINDOW_START_X;

	private static float OPTION_HEIGHT;
	private static float OPTION_WIDTH;
	private static float OPTION_START_X;

	private static float TEXT_HEIGHT;
	private static float TEXT_WIDTH;

	internal static bool SHOW = false;
	internal static string TEXT = string.Empty;

	private static int BUTTON_NUM = 0;
	private static string BUTTON_1_TEXT = string.Empty;
	private static string BUTTON_2_TEXT = string.Empty;
	private static string BUTTON_3_TEXT = string.Empty;
	private static string BUTTON_4_TEXT = string.Empty;
	private static Action BUTTON_1_ACTION;
	private static Action BUTTON_2_ACTION;
	private static Action BUTTON_3_ACTION;
	private static Action BUTTON_4_ACTION;

	void Start () 
	{
		DIALOG_WINDOW_HEIGHT = Screen.height / 2;
		DIALOG_WINDOW_WIDTH = Screen.width / 4;
		DIALOG_WINDOW_START_Y = Screen.height / 4;
		DIALOG_WINDOW_START_X = Screen.width / 4;

		OPTION_HEIGHT = DIALOG_WINDOW_HEIGHT / 20;
		OPTION_START_X = OPTION_HEIGHT;
		OPTION_WIDTH = DIALOG_WINDOW_WIDTH - (OPTION_START_X * 2);

		TEXT_WIDTH = DIALOG_WINDOW_WIDTH - (2 * OPTION_START_X);
		TEXT_HEIGHT = DIALOG_WINDOW_HEIGHT - (OPTION_HEIGHT * 10);

		Dialog_Window.Show ("Hello WORLD!", "Button Option 1", this.DELETE, "Button Option 2", this.DELETE, "Button Option 3", this.DELETE);
	}

	public void DELETE()
	{
		Dialog_Window.Show ("Goodbye!", "Bye", this.HIDE);
	}

	public void HIDE()
	{
		Dialog_Window.Hide ();
	}

	internal static void Set_Buttons(Action[] button_actions, string[] button_texts)
	{
		BUTTON_NUM = button_actions.Length;
		if (BUTTON_NUM > 3) 
		{
			BUTTON_4_ACTION = button_actions [3];
			BUTTON_4_TEXT = button_texts [3];
		}
		if (BUTTON_NUM > 2) 
		{
			BUTTON_3_ACTION = button_actions [2];
			BUTTON_3_TEXT = button_texts [2];
		}
		if (BUTTON_NUM > 1) 
		{
			BUTTON_2_ACTION = button_actions [1];
			BUTTON_2_TEXT = button_texts [1];
		}
		if (BUTTON_NUM > 0) 
		{
			BUTTON_1_ACTION = button_actions [0];
			BUTTON_1_TEXT = button_texts [0];
		}
		TEXT_HEIGHT = DIALOG_WINDOW_HEIGHT - (OPTION_HEIGHT * (10 - (2 * (4 - BUTTON_NUM))));
	}

	void OnGUI ()
	{
		if (SHOW) {
			GUI.BeginGroup (new Rect (DIALOG_WINDOW_START_X, DIALOG_WINDOW_START_Y, DIALOG_WINDOW_WIDTH, DIALOG_WINDOW_HEIGHT));

			float height_counter = 0;

			GUI.Box (new Rect (0, height_counter, DIALOG_WINDOW_WIDTH, DIALOG_WINDOW_HEIGHT), string.Empty);

			height_counter += OPTION_HEIGHT;

			GUI.Box (new Rect (OPTION_START_X, height_counter, TEXT_WIDTH, TEXT_HEIGHT), TEXT);

			height_counter += TEXT_HEIGHT + OPTION_HEIGHT;

			if (BUTTON_NUM > 0) 
			{
				if (GUI.Button (new Rect (OPTION_START_X, height_counter, OPTION_WIDTH, OPTION_HEIGHT), BUTTON_1_TEXT)) 
				{
					BUTTON_1_ACTION ();
				}
				height_counter += (OPTION_HEIGHT * 2);
			}
			if (BUTTON_NUM > 1) 
			{
				if (GUI.Button (new Rect (OPTION_START_X, height_counter, OPTION_WIDTH, OPTION_HEIGHT), BUTTON_2_TEXT)) 
				{
					BUTTON_2_ACTION ();
				}
				height_counter += (OPTION_HEIGHT * 2);
			}
			if (BUTTON_NUM > 2) 
			{
				if (GUI.Button (new Rect (OPTION_START_X, height_counter, OPTION_WIDTH, OPTION_HEIGHT), BUTTON_3_TEXT)) 
				{
					BUTTON_3_ACTION ();
				}
				height_counter += (OPTION_HEIGHT * 2);
			}
			if (BUTTON_NUM > 3) 
			{
				if (GUI.Button (new Rect (OPTION_START_X, height_counter, OPTION_WIDTH, OPTION_HEIGHT), BUTTON_4_TEXT)) 
				{
					BUTTON_4_ACTION ();
				}
			}
			GUI.EndGroup ();
		}
	}
}

public static class Dialog_Window
{
	public static void Show(string text, string button_1_text, Action option_1)
	{
		Dialog.Set_Buttons (new Action[] { option_1 }, new string[] { button_1_text });
		Dialog.TEXT = text;
		Dialog.SHOW = true;
	}

	public static void Show(string text, string button_1_text, Action option_1, string button_2_text, Action option_2)
	{
		Dialog.Set_Buttons (new Action[] { option_1, option_2 }, new string[] { button_1_text, button_2_text });
		Dialog.TEXT = text;
		Dialog.SHOW = true;
	}

	public static void Show(string text, string button_1_text, Action option_1, string button_2_text, Action option_2, string button_3_text, Action option_3)
	{
		Dialog.Set_Buttons (new Action[] { option_1, option_2, option_3 }, new string[] { button_1_text, button_2_text, button_3_text });
		Dialog.TEXT = text;
		Dialog.SHOW = true;
	}

	public static void Show(string text, string button_1_text, Action option_1, string button_2_text, Action option_2, string button_3_text, Action option_3, string button_4_text, Action option_4)
	{
		Dialog.Set_Buttons (new Action[] { option_1, option_2, option_3, option_4 }, new string[] { button_1_text, button_2_text, button_3_text, button_4_text });
		Dialog.TEXT = text;
		Dialog.SHOW = true;
	}

	public static void Hide()
	{
		Dialog.SHOW = false;
	}
}