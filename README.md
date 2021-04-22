# MementoPattern_with_Unity
 
메멘토에 저장할 타입을 Memento.cs 에 선언한다.

씬에서 Save 버튼을 누르면 큐브의 location이 메멘토에 저장되고,
큐브 인터렉션은 귀찮아서 안만들었다.  수동으로 제어하고 Save를 누르고 < , > 누르면 테스트 됨.

메멘토를 버퍼에 넣는 함수가 두 가지가 있다. 
 1. Do 
 2. PushCurrentState 

Do 함수는 데이터를 버퍼에 삽입하고 버퍼에서 가르키고있는 인덱스를 +1 시켜준다. 

PushCurrentState는 버퍼에 데이터를 삽입하나 인덱스를 ++ 하지 않는다. 이 경우는 Undo 클릭 시 다시 Redo가 가능해야 하기에 버퍼에 임시로 데이터를 저장하는 용도로 사용한다. 


오픈 소스 활용 출처 https://www.codeproject.com/Articles/10576/An-Undo-Redo-Buffer-Framework
