using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMiniGamable 
{
    //������Ʈ�� ������� ��
    //�ð� �������� ���ؼ� ��� ������ �ؾ��ϴµ� � ������ ������ ������ �� �ؾ���
    //������ ���������� ��¦ ���ϰ� �ڵ��� ���������� �κ��� �ణ �ִ�.
   
    public void GameStart();
    public void GameEnd();
    public void ReturnHome();
   
}
