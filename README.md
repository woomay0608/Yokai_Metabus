# Yokai_Metabus
들어간 기능들
리더보드,Flappy게임, 색깔바꾸기, 홀짝맞추기게임, 장식물 장착, 탈 것 타기(속도 증가), 카메라 범위 제한

편지
여기 들어간 도트들은 제가 다 그렸습니다, 심지어 무슨 연유 때문인지는 몰라도 색깔이 이상해져서
더 못생겨지게 되었습니다. 해보고 싶어서 열심히 한 것이니 귀엽게 봐주시면 감사하겠습니다
그리고 영어 스펠링에 대해서 무감각하게 오류를 범했기에 이 부분은 시간이 부족해 고치지 못했으니
다음에는 꼭 틀리지 않을테니 이번만 너그러운 마음으로 봐주시면 감사하겠습니다.


가장 맨 위에는 리더보드가 있고
각 게임마다 상위 5개의 점수를 띄움

왼쪽에서부터 반 아치 형태를 그리며 친구들이 대기하고 있습니다.
-친구들 공통
F로 말을 걸면
행동하기/ 돌아가기를 고를 수 있음

-가장 왼쪽 친구(가오나시 비슷한 것)
Flappy게임으로 이동합니다
게임 오버시 최고 점수와 현재 점수를 띄워줌

-그 다음 친구(일본의 설녀)
색깔을 바꿔줍니다
slider R, G, B로 나눔

-그 다음(일본의 다루마, 빨간 친구)
주사위 홀짝 게임으로 이동합니다
게임 오버시 최고 점수와 현재 점수를 띄워줌

-그 다음(동물 귀 같은 걸 달고있는애)
맵 곳곳에 6개의 장식물들이 뿌려져있습니다
이걸 주으면 장착할 수 있도록 ui를 틀어줍니다
!!!장착 해제 불가능
다른 것으로 갈아입기는 가능

-그 다음(초록색 대머리, 일본의 갓파)
총 2가지의 탈 것을 제공하며 미니게임에서 5점을 넘을 시
하나씩 해금됩니다.
단순히 속도만 늘려줍니다
GameManger에서 해금을 마음대로 하실 수 있도록 만들어놨습니다.
!!!장착 해제 불가능
다른 것으로 갈아타기는 가능
