using System.Collections.Generic;//Generic이 없을 경우-> 박싱으로 인해서 랙 유발 Generic 필수
using System.Reflection.Metadata.Ecma335;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace day19
{
    /*class Item
    {
        string  _name;
        int _price;
        int _quantity;
        public int CalculateTotalPrice()
        {
            return _price * _quantity;
        }
    }*/

    class Enemy
    {
        public string Name { get; set; }

    }
    class Ally
    {
        public string Name { get; set; }
    }
    class Troop<T> where T : class, new()
    {
        int _count = 0;
        T[] _army;


        public void RemoveAt(int index)
        {
            for (int i = index; i < _count-1; i++) 
            {
                _army[i]=_army[i+1];
            }
            _count--;
        }
        public int Count
        {
            get { return _count; }
            private set { _count = value; }//접근지정자를 통해서 프로퍼티도 정보은닉 가능
        }
        public void Add(T unit)//army.length를 통해서 길이를 알 수 있다.
        {
            if (_army.Length <= _count)
            {
                Array.Resize<T>(ref _army, _army.Length);
            }
            else
            {
                Array.Resize<T>(ref _army, _count+1);// 오른쪽 정수는 배열 길이-> 0이면 배열이 없어서 고장남
            }
            // 오류 발생
            Console.WriteLine(_army.Length);
            Console.WriteLine(Count);
            _army[_count] = unit;//배열 범위를 넘었다네요
            Count++;
            

        }
        public Troop()
        {
            _army = new T[10];
            for (int i = 0; i < 10; i++)
            {
                _army[i] = new T();
            }
            _count = 0;                                                                                   
        }
        public Troop(int troopSize)                                
        {
            _army = new T[troopSize];
            for(int i=0; i<troopSize; i++)
            {
                _army[i] = new T();
            }

        }

        public T this[int index]
        {
            get { return _army[index]; }
            set { _army[index] = value; }   
        }


        public T GetEnemyByindex(int index)
        {
            return _army[index];
        }
    }
     /*   struct Item
    {
        public string Name { get; set; }
        public string Description {  get; set; }
    }*/
    /*
    class Inventory
    {
        Item[] _items;//비어있는 Item 배열
        public Inventory(int invenSize)//생성자를 이용한 배열 크기 할당
        {
            _items=new Item[invenSize];
        }
        //인덱스를 인자값으로 주면, 배열속해당 아이템 반환해주는 메소드
        public Item GetItemByIndex(int index)
        {
            return _items[index];   
        }
        public Item[] Inven
        {
            get { return _items; }
        }
        public Item this[int i]//외부에서 인자로 인덱스 i 준다
        {
            get { return _items[i]; }//활용해서 변환값 적기
            set { _items[i] = value; }//외부에서 세팅해준 값
        }






    }*/
    internal class Program
    {

        static void Main(string[] args)
        {
            //추상화 필요한 부분만 추려내서 필드, 메소드로 구현하는 것
            //내부적인 정보를 숨기기 위해 정보은닉을 진행, 접근지정자를 통해서 정보 은닉
            //프로퍼티를 이용해서 변수의 직접 접근을 막고, 안전한 소통을 제공
            //캡슐화가 존재 
            // 비슷한 항목들이 많고, 코드 중복이 늘어나고 있을 때 상속을 사용
            ///부모 클래스에 공통된 사항을 넣고
            ///자식클래스에는 본인만의 요소나 기능을 추가하는 방식
            ///static-> 정적 할당 
            ///상속이긴 한데, 하위클래스에 재정의를 강제하는 키워드-> 추상클래스 abstract
            ///객체지향 4대 요소 추상화, 캡슐화, 상속, 다형성
            ///자료구조 배열 
            ///배열의 단점-> 크기가 늘었다 줄었다 하는 상황 대처능력이 떨어짐 
            ///배열에서 특정 내용물을 검색하는 기능도 없음 -> 수동으로 검색해야 함
            ///자료를 효율적으로, 그리고 관리하고 싶은 방법에 따라 다르게
            ///활용하는 것을 보고 자료구조를 활용한다 이렇게 표현함
            ///영어로 콜렉션 
            ///인덱서 
            ///특정 인덱스를 주면 거기있는 요소를 지우는 기능
            ///지워지긴 하되 중간에 null이 생기지 않고 유의미한 값들이 연속되게 만들고 싶음
            ///
            ///dictionary-> 사전 무언가를 찾으면 그에 대한 정보를 줌
            ///특정 키워드를 주면 그에 해당하는 정보를 가져다 주는 자료구조
            ///키값을 주면 값을 반환해줌
            ///
            ///stack 
            ///first in last out, last in first out
            ///filo, lifo
            ///선입후출, 후입선출
            ///스택이 사용될법한 상황 웹브라우저에서 뒤로가기 
            ///ui창에서 새로운 창이 뜰 때-> 제어권을 스택에 저장하는 방식으로 사용 가능
            ///턴제 게임에서 턴 무르기
            ///집어넣기 위 한 push, 가장 위 요소를 반환하는 동시에 없에는 pop
            ///요소를 보기만 하고 없애지는 않는 peek
            ///
            ///queue-> 줄,
            ///선입 선출, 




            //Inventory inventory= new Inventory(10);//시작하면서 10개의 칸을 가진 배열생성
            //Console.WriteLine(inventory.GetItemByIndex(2).Name);//인덱스 2번째 칸의 이름 가져오기
            //Console.WriteLine(inventory.Inven[2].Name);//프로퍼티로 구현

            //이럴 때 인덱서를 사용한다.
            ///[접근지정자][반환형태]this[int i]
            ///{
            ///get{return 반환할 것;}
            ///set{세팅할 값=value;}
            ///}
            ///
            //Console.WriteLine(inventory[2].Name);//클래스 속에 자류구조가 있다면 유용한 인덱서

            //Troop<Ally> myteam = new Troop<Ally>(10);
            //myteam[2] = new Ally();
            //myteam[2].Name = "lucia";
            //myteam[2] = new Ally { Name = "lucia" };
            //Troop<Enemy> enemyTeam = new Troop<Enemy>();//10개짜리 공간만 작성
            //enemyTeam.Add(new Enemy { Name ="ak"});
            //enemyTeam.Add(new Enemy { Name ="sdf"});
            //enemyTeam.Add(new Enemy { Name ="1w"});
            ////for(int i = 0; i < enemyTeam.Count; i++)
            ////{
            ////    Console.WriteLine(enemyTeam[i].Name);
            ////}
            //enemyTeam.RemoveAt(2);
            //Console.WriteLine("----------------------");
            //for (int i = 0; i < enemyTeam.Count; i++)
            //{
            //    Console.WriteLine(enemyTeam[i].Name);
            //}
            //
            //
            //List<int> myFirstList = new List<int>();
            //myFirstList.Add(1);
            //myFirstList.Add(5);
            //myFirstList.Add(8);
            //myFirstList.Add(12);
            //myFirstList.Add(19);
            //for(int i = 0;i< myFirstList.Count; i++)
            //{
            //    Console.WriteLine(myFirstList);
            //}
            //foreach(var i in myFirstList)
            //{
            //    Console.WriteLine(i);
            //}
            //
            //myFirstList.RemoveAt(2);
            //
            //Console.WriteLine("-------------------");
            //foreach (var i in myFirstList)
            //{
            //    Console.WriteLine(i);
            //}
            //
            //List<int> invenRowFirst = new List<int>();
            //List<int> invenRowSecond = new List<int>();
            //List<int> invenRowThird = new List<int>();
            //List<int>[] invenRows =new List<int>[3];
            //// 자료형[] 배열명 = new 자료형[배열개수]
            //List<List<int>> twoDim = new List<List<int>>();
            //twoDim.Add(invenRowFirst);
            //twoDim.Add(invenRowSecond);
            //twoDim.Add(invenRowThird);
            //twoDim[0].Add(1);
            //
            //for(int i = 0; i < 3; i++)
            //{
            //    if (invenRowFirst[i] == 7)// 반복문의 과정중에서 인덱스가 변하기 때문에 에러 발생
            //    {
            //        invenRowFirst.Remove(7);
            //    }
            //    Console.WriteLine(invenRowFirst[i]);
            //}
            //ArrayList myList = new ArrayList();
            //myList.Add(12);
            //myList.Add("Oing");
            //myList.Add(12.4565);

            //Dictionary<string, int> item = new Dictionary<string, int>(); //key와 value로 쓸 자료형을 요구함
            ////key는 찾을 때 사용할 자료형, value는 실제 저장하는 데이터 여기서는 
            ////key가 string, value가 int이다.
            //item.Add("파괴폭탄", 15);
            //item.Add("회오리수류탄", 198);
            //item.Add("성스러운부적", 22);
            //Console.WriteLine(item["파괴폭탄"]);
            //Dictionary<int, string> item2 = new Dictionary<int, string>();
            //item2.Add(1, "애니머신건");
            //item2.Add(2, "샷건");
            //item2.Add(3, "에너미체이서");
            //Console.WriteLine(item2[3]);
            //if (item2.ContainsKey(6) == false)
            //{
            //    item2.Add(6, "레이저");
            //}///Add, 꺼내쓰기, Containskey-> 키값이 존재하는가-> 나머지 기능은 자습!->c# 딕셔너리 사전
            //Stack<char>keyInputs =new Stack<char>();
            //
            //while (true)
            //{
            //    var keyInput=Console.ReadKey();
            //    keyInputs.Push(keyInput.KeyChar);
            //    if (keyInput.KeyChar == '0')
            //    {
            //        break;
            //    }
            //}
            //
            //for(int i = 0; i < keyInputs.Count; i++)//pop으로 인해서 count가 줄기 때문에 i는 증가하고 count는 감소해서 2배로 빨리 끝난다.
            //{
            //    char poped = keyInputs.Pop();
            //    Console.WriteLine(poped);
            //}
            //
            //while (keyInputs.Any())
            //{
            //    Console.WriteLine(keyInputs.Pop());//pop이 아니라 peak일 경우 맨위만 본다.
            //}
            //
            Queue<char> keyInputs = new Queue<char>();
            while (true)
            {
                var keyInput=Console.ReadKey();
                keyInputs.Enqueue(keyInput.KeyChar);//입력
                if (keyInput.KeyChar == '0')
                {
                    break;
                }
            }
            
            //for(int i = 0; i < keyInputs.Count; i++)
            //{
            //    char poped = keyInputs.Pop();
            //    Console.WriteLine(poped);
            //}
            
            while (keyInputs.Any())
            {
                Console.WriteLine(keyInputs.Dequeue());//출력
            }
            

        }
    }
}
