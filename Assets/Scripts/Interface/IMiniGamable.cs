using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMiniGamable 
{
    //프로젝트가 깊어졌을 때
    //시간 부족으로 인해서 취사 선택을 해야하는데 어떤 구조로 만들지 생각을 잘 해야함
    //지금의 범위에서는 살짝 과하고 코드의 억지스러운 부분이 약간 있다.
   
    public void GameStart();
    public void GameEnd();
    public void ReturnHome();
   
}
