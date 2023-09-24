using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    private string displayText;

    private void Start()
    {
        Init();
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(255, 30, 350, 70), displayText, GUI.skin.textField);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int number = i * 3 + j + 1;
                if (GUI.Button(new Rect(255 + j * 70, 100 + i * 70, 70, 70), number.ToString(), GUI.skin.button))
                {
                    AppendToDisplay(number.ToString());
                }
            }
        }

        if (GUI.Button(new Rect(255, 310, 140, 70), "0", GUI.skin.button))
        {
            AppendToDisplay("0");
        }

        if (GUI.Button(new Rect(395, 310, 70, 70), ".", GUI.skin.button))
        {
            AppendToDisplay(".");
        }

        if (GUI.Button(new Rect(465, 100, 70, 70), "+", GUI.skin.button))
        {
            AppendToDisplay("+");
        }

        if (GUI.Button(new Rect(465, 170, 70, 70), "-", GUI.skin.button))
        {
            AppendToDisplay("-");
        }

        if (GUI.Button(new Rect(465, 240, 70, 70), "*", GUI.skin.button))
        {
            AppendToDisplay("*");
        }

        if (GUI.Button(new Rect(465, 310, 70, 70), "/", GUI.skin.button))
        {
            AppendToDisplay("/");
        }

        if (GUI.Button(new Rect(535, 100, 70, 70), "C", GUI.skin.button))
        {
            ClearDisplay();
        }

        if (GUI.Button(new Rect(535, 170, 70, 210), "=", GUI.skin.button))
        {
            Calculate();
        }
    }

    private void Init()
    {
        displayText = "";
    }

    private void AppendToDisplay(string str)
    {
        displayText += str;
    }

    private void ClearDisplay()
    {
        displayText = "";
    }

    private void Calculate()
    {
        try
        {
            var result = eval(displayText);
            displayText = result.ToString();
        }
        catch (System.Exception)
        {
            displayText = "´íÎó";
        }
    }

    private double eval(string expression)
    {
        var result = new System.Data.DataTable().Compute(expression, null);
        return System.Convert.ToDouble(result);
    }
}