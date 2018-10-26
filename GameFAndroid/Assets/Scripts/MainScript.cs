using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoardF;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainScript : MonoBehaviour
{

    const int size = 4;
    Game game;
    Sound sound;

    public Text TextMoves;

    void Start()
    {
        game = new Game(size);
        sound = GetComponent<Sound>();
        HideButtons();
    }

    public void OnStart()
    {
        game.Start(1000 + System.DateTime.Now.DayOfYear);
        ShowButtons();
        sound.PlayStart();
    }

    public void OnClick()
    {
        if (game.Solved())
            return;
        string name = EventSystem.current.currentSelectedGameObject.name;
        int x = int.Parse(name.Substring(0, 1));
        int y = int.Parse(name.Substring(1, 1));
        if(game.PressAt(x, y) > 0)
            sound.PlayMove();
        ShowButtons();
        if (game.Solved())
        {
            TextMoves.text = "Game finished in " + game.moves + " moves";
            sound.PlaySolved();
        }
    }

    //Скрываем кнопки
    void HideButtons()
    {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigitAt(0, x, y);
        TextMoves.text = "Welcome to Game F";
    }

    //Отображаем кнопки
    void ShowButtons()
    {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigitAt(game.GetDigitAt(x, y), x, y);
        TextMoves.text = game.moves + " moves";
    }

    void ShowDigitAt(int digit, int x, int y)
    {
        //Получение имени кнопки
        string name = x + "" + y;
        var button = GameObject.Find(name);
        //Получаем компонент текста с кнопки
        var text = button.GetComponentInChildren<Text>();
        //Записываем текст
        text.text = DecToHex(digit);
        //Получаем картинку кнопки и меняем цвет с белого на прозрачный и обратно
        button.GetComponentInChildren<Image>().color = //set Visible
            (digit > 0) ? Color.white : Color.clear;
    }

    string DecToHex(int digit)
    {
        if (digit == 0) return "";
        if (digit < 10) return digit.ToString();
        return ((char)('A' + digit - 10)).ToString();
    }

    void Update()
    {

    }
}
