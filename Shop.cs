using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//предисловие:
//на каждой кнопке со скином мы напишем цену, повешаем этот скрипт на какой-то обьект.
//в методе onClick на самой кнопке указываем функцию Buying и указываем порядковый номер кнопки


//                                      ОЧЕНЬ ВАЖНО!!!!!!
//мы должны указать номер кнопки-1, потому-что... ПОТОМУ-ЧТО!
//крч, там простая математика, я не знаю как обьяснить

//и дальше во всех циклахнужно указывать КОЛИЧЕСТВО СКИНОВ - 1
//и еще, я повесил этот скрипт на обьект Image, чтоб его проще было найти
//надо в скрипте указать все обьекты ТЕКСТ, на которых будет показана цена


//в общем, это все предисловие, дальше сам код и коментарии
//Не знаю, на сколько понятны будут мои коментарии, если что, пиши в тг =>
//постараюсь ответить



public class Shop : MonoBehaviour
{
    private Dictionary<int, int> CoastListItems = new Dictionary<int, int>();
    //это словарь, в котором будут указаны элементы и их цена (идет порядковый номер элемента,
    //после него - цена
    public Text[] PricesText;
    // это список на обьекты Текст, в которых будут вписаны цены наших скинов
    public Dictionary<int, string> Symbols = new Dictionary<int, string>();
    //это мое персональное решение по сохранению прогресса скинов:

    //мы будем записывать в какую-то PlayerPrefs Строку, в которую
    //по мере покупки скина будем добавлять какой-то символ
    //(символы на скины указаны в методе Старт)
    //потом при повторной загрузке сцены - мы будем получать символы, и поочередно
    //проверять их на совпадение с элементами словарей
    void Start()
    {
        CoastListItems.Add(0, 1000);//
        CoastListItems.Add(1, 5000);//
        CoastListItems.Add(2, 10000);//
        CoastListItems.Add(3, 15000);//
        CoastListItems.Add(4, 100000);//
        CoastListItems.Add(5, 300000);//
        CoastListItems.Add(6, 500000);//
        CoastListItems.Add(7, 5555555);//
        CoastListItems.Add(8, 60000000);//
        Symbols.Add(0, "Q");//
        Symbols.Add(1, "W");//
        Symbols.Add(2, "E");//
        Symbols.Add(3, "R");//
        Symbols.Add(4, "T");//
        Symbols.Add(5, "Y");//это инициализация самих словарей
        Symbols.Add(6, "U");//
        Symbols.Add(7, "I");//важно в этой инициализации для (всех скинов -1) указать цены и символы
        Symbols.Add(8, "O");//

        for (int i = 0; i < 9; i++) //подгон цен скинов в зависимости от их порядкового номера
        { PricesText[i].text = CoastListItems[i].ToString(); // оченб важно: в строке 
            //"int i = 0; i < 9; i++" девятку нужно поменять на количество наших скинов
        }
        if (!PlayerPrefs.HasKey("SkinProgress")) { PlayerPrefs.SetString("SkinProgress", ""); }
        string SkinProgress = PlayerPrefs.GetString("SkinProgress");//строка,
        //которая будет хранить прогресс скинов
        for (int num = 0; num < 9; num++)//цикл проверки совпадений в строке SkinProgress
        //на Символы скинов
        //опять же, ограничевующюю девятку нужно поменять на количество скинов
        {
            if (SkinProgress.Contains(Symbols[num])) { PricesText[num].text = "Boughted"; }
        }
    }
    public void BuyingSkin(int ButtonNum)
    {
        if (!PlayerPrefs.GetString("SkinProgress").Contains(Symbols[ButtonNum]))
            //получаем строку с прогрессом скинов
            //проверяем, что бы не было нужного символа,
            //что-бы не покупать дважды один скин
        {
            int Price = CoastListItems[ButtonNum];//на каждой кнопке скина нужно указать
                                                  //их порядковый номер (от 0 до количество скинов-1)
            int Money = PlayerPrefs.GetInt("Money");//получаем количество денег из PlayerPrefs
            if (Money >= Price)//проверка, чтоб у нас было достаточно денег
            {
                Money -= Price;
                PlayerPrefs.SetInt("Money", Money); // записываем деньги с отнятой ценой в PlayerPrefs
                //дальше самое интересное


                string letter = Symbols[ButtonNum];//символ полученый в зависимости от нажатой кнопки
                string preflet = PlayerPrefs.GetString("SkinProgress");//уже купленые скины
                preflet = preflet + letter;//дописываем, что мы купили новый скин
                PlayerPrefs.SetString("SkinProgress", preflet);//записываем строку с куплеными скинами
                PlayerPrefs.SetInt("ChoosenSkin", ButtonNum);//Сетаем только-что купленый скина на игрока
                Debug.Log((preflet, Money, letter));
            }
            else
            {
                Debug.Log("Error with Buying");
                //Тут код когда роизошла ошибка (денег мало, или что-то еще)
            }
        }
        else
        {
            Debug.Log("Мы уже купили этот скин");
            //код, если мы УЖЕ купили скин
        }
    }
    public void SetMoney() // метод для пополнения счета (только для разработчиков)
    {
        PlayerPrefs.SetInt("Money", 10000000);
        Debug.Log(PlayerPrefs.GetInt("Money"));
    }
}
