using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Intermediate
{
    public class ClassTest_Basic1
    {
        // class's element
        // 1. Method 2. Property  3. Field  4. Event  5.Enum  6.Constant

        // other consideration
        // access modifier

        // member or member field
        private string name;
        private int age;
        private readonly string gender;

        // difference between readonly varialbes and constant

        // event
        // delegate는 Method memory address를 저장할 수 있는 특이한 데이터타입.
        // EventHandler는 return type이 delegate로 정의되어 있음.
        // Prameter는 두개.
        public event EventHandler NameChanged;
        public event EventHandler BalanceChanged;   // event 설명을 위한 임시 예제

        // Constructor
        // Condition: 1. same as class name 2. must be Public 3. no return type
        public ClassTest_Basic1(string pname, int page, char pgender = 'M')
        {
            // 생성자는 멤버들의 초기화를 담당
            name = pname;
            age = page;
            gender = pgender == 'M' ? "Male" :"Female";
        }

        // Property
        // a.k.a Special kind of method
        // 실제 멤버에 대해서 input, output 관리
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    if (NameChanged != null)
                    {
                        // Callback
                        NameChanged(this, EventArgs.Empty);
                    }

                    // event 설명을 위한 예시로 추가됨
                    if (BalanceChanged != null)
                    {
                        decimal balance = 1000M;
                        BalanceChanged(balance, new EventArgs());
                    }
                }
            }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }


        // Java에서는 아래처럼 씀
        public int getAge()
        {
            return this.age;
        }

        public void setAge(int value)
        {
            this.age = value;
        }

        // read only property
        public string Gender
        {
            get { return this.gender; }
        }

        // Method
        public string GetCustomerData()
        {
            string data = string.Format("Name: {0} (Age: {1} Gender: {2})",
                        this.Name, this.Age, this.Gender);
            return data;
        }

        // Method Overloading
        // Overloading의 정의: 같은 Signature(Method 이름)의 Method들을 정의할 수 있음.
        // 조건: Parameter의 개수가 다르거나 타입이 달라야함. Return type은 같아야함.
        // ★★★★★
        // 인터뷰 문제: Overloading의 조건?
        // Parameter count or types must be different. but Return type must be same.
        public string Foo(int x)
        {
            return string.Format("returning integer: {0}", x);
        }
        public string Foo(double x)
        {
            return string.Format("returning double: {0}", x);
        }

        public string Foo(int x, float y)
        {
            return string.Format("returning integer and float: {0},{1}", x, y);
        }
        public string Foo(float x, int y)
        {
            return string.Format("returning float and integer: {0},{1}", x, y);
        }

        // difference between overloading and overriding
    }
}
