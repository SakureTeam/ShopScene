using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����������:
//�� ������ ������ �� ������ �� ������� ����, �������� ���� ������ �� �����-�� ������.
//� ������ onClick �� ����� ������ ��������� ������� Buying � ��������� ���������� ����� ������


//                                      ����� �����!!!!!!
//�� ������ ������� ����� ������-1, ������-���... ������-���!
//���, ��� ������� ����������, � �� ���� ��� ���������

//� ������ �� ���� ����������� ��������� ���������� ������ - 1
//� ���, � ������� ���� ������ �� ������ Image, ���� ��� ����� ���� �����
//���� � ������� ������� ��� ������� �����, �� ������� ����� �������� ����


//� �����, ��� ��� �����������, ������ ��� ��� � ����������
//�� ����, �� ������� ������� ����� ��� ����������, ���� ���, ���� � �� =>
//���������� ��������



public class Shop : MonoBehaviour
{
    private Dictionary<int, int> CoastListItems = new Dictionary<int, int>();
    //��� �������, � ������� ����� ������� �������� � �� ���� (���� ���������� ����� ��������,
    //����� ���� - ����
    public Text[] PricesText;
    // ��� ������ �� ������� �����, � ������� ����� ������� ���� ����� ������
    public Dictionary<int, string> Symbols = new Dictionary<int, string>();
    //��� ��� ������������ ������� �� ���������� ��������� ������:

    //�� ����� ���������� � �����-�� PlayerPrefs ������, � �������
    //�� ���� ������� ����� ����� ��������� �����-�� ������
    //(������� �� ����� ������� � ������ �����)
    //����� ��� ��������� �������� ����� - �� ����� �������� �������, � ����������
    //��������� �� �� ���������� � ���������� ��������
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
        Symbols.Add(5, "Y");//��� ������������� ����� ��������
        Symbols.Add(6, "U");//
        Symbols.Add(7, "I");//����� � ���� ������������� ��� (���� ������ -1) ������� ���� � �������
        Symbols.Add(8, "O");//

        for (int i = 0; i < 9; i++) //������ ��� ������ � ����������� �� �� ����������� ������
        { PricesText[i].text = CoastListItems[i].ToString(); // ����� �����: � ������ 
            //"int i = 0; i < 9; i++" ������� ����� �������� �� ���������� ����� ������
        }
        if (!PlayerPrefs.HasKey("SkinProgress")) { PlayerPrefs.SetString("SkinProgress", ""); }
        string SkinProgress = PlayerPrefs.GetString("SkinProgress");//������,
        //������� ����� ������� �������� ������
        for (int num = 0; num < 9; num++)//���� �������� ���������� � ������ SkinProgress
        //�� ������� ������
        //����� ��, �������������� ������� ����� �������� �� ���������� ������
        {
            if (SkinProgress.Contains(Symbols[num])) { PricesText[num].text = "Boughted"; }
        }
    }
    public void BuyingSkin(int ButtonNum)
    {
        if (!PlayerPrefs.GetString("SkinProgress").Contains(Symbols[ButtonNum]))
            //�������� ������ � ���������� ������
            //���������, ��� �� �� ���� ������� �������,
            //���-�� �� �������� ������ ���� ����
        {
            int Price = CoastListItems[ButtonNum];//�� ������ ������ ����� ����� �������
                                                  //�� ���������� ����� (�� 0 �� ���������� ������-1)
            int Money = PlayerPrefs.GetInt("Money");//�������� ���������� ����� �� PlayerPrefs
            if (Money >= Price)//��������, ���� � ��� ���� ���������� �����
            {
                Money -= Price;
                PlayerPrefs.SetInt("Money", Money); // ���������� ������ � ������� ����� � PlayerPrefs
                //������ ����� ����������


                string letter = Symbols[ButtonNum];//������ ��������� � ����������� �� ������� ������
                string preflet = PlayerPrefs.GetString("SkinProgress");//��� �������� �����
                preflet = preflet + letter;//����������, ��� �� ������ ����� ����
                PlayerPrefs.SetString("SkinProgress", preflet);//���������� ������ � ��������� �������
                PlayerPrefs.SetInt("ChoosenSkin", ButtonNum);//������ ������-��� �������� ����� �� ������
                Debug.Log((preflet, Money, letter));
            }
            else
            {
                Debug.Log("Error with Buying");
                //��� ��� ����� �������� ������ (����� ����, ��� ���-�� ���)
            }
        }
        else
        {
            Debug.Log("�� ��� ������ ���� ����");
            //���, ���� �� ��� ������ ����
        }
    }
    public void SetMoney() // ����� ��� ���������� ����� (������ ��� �������������)
    {
        PlayerPrefs.SetInt("Money", 10000000);
        Debug.Log(PlayerPrefs.GetInt("Money"));
    }
}
