# Chapter 3 - Objects And Types
紀錄此章節學習的知識


**類別**與**結構**都是建立物件的模板(藍圖)，每個物件都可包含資料且提供處理和訪問資料的方法。兩者不同之處在於類別是參考類型（Reference Type）儲存於 heap 上，而結構是實值類型（Value Type）儲存於 stack 上，且結構不支持繼承。較小的資料類型使用結構可提高性能，在堆棧上儲存實值類型可避免垃圾收集。

## class（類別）
類別的成員包含 Fields、Constants、Methods、Properties、Constructors、Indexers、Operators、Events、Destructor、Finalizers、Nested Types

參考 [Members (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/members)

### Fields（欄位）
欄位是任意類型的變數，可直接宣告於類別或結構中。欄位可分為兩種 Instance Fields（實例欄位）& Static Fields（靜態欄位）

```CSharp
public class Member
{
    // 欄位宣告為 private，使用屬性來訪問欄位
    private string _name;
    // 唯讀欄位，分配後就不能改變
    private readonly string _gender;
}
```

### Constants（常量變數）
- 使用 `const` 關鍵字宣告常量變數
- 必須在宣告時進行初始化
- 使用 `public` 修飾詞可在類別外部訪問

```CSharp
class Calendar
{
    public const int Months = 12;
    public const int Weeks = 52;
    public const int Days = 365;
    
    public const double DaysPerWeek = (double) Days / (double) Weeks;
    public const double DaysPerMont = (double) Days / (double) Months;
}
```

### Properties（屬性）
屬性可以讓類別公開取得和設定值的公用方式，並且同時隱藏實作或驗證的一種類別成員。

屬性使用到三個存取器（accessors）分別為
- `get` 用來回傳屬性值
- `set` 用來指派新的值
- `value` 指派給屬性或索引器的值，類似方法的傳入參數

```CSharp
class Member
{
    private int _age;
    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            _age = value;
        }
    }
}
```

也可使用 Expression body definitions（表達式主體定義），使用一條語句實現存取器，且 `get` 省略 `return` 關鍵字
```CSharp
class Member
{
    private int _age;
    public int Age
    {
        get => _age;
        set => _age = value;
    }
}
```

存取器 `get` 和 `set` 中沒有任何邏輯，就可使用 Auto-implemented properties（自動實作屬性），該屬性會自動實現 Backing Field（or Backing Store），即不需宣告私有欄為，Compiler 會自動建立欄位成員。使用自動實作屬性就不能直接訪問欄位，因為不知道 Compiler 生成的名稱，也不能在屬性中設置驗證屬性的有效性，適合用於只需讀寫欄位的屬性。
```CSharp
class Member
{
    public int Age { get; set; }
}
```

自動實作屬性也可以直接初始化屬性
```CSharp
class Member
{
    public int Age { get; set; } = 18;
}
```

給存取器（accessors）設置不同的訪問修飾詞
```CSharp
class Member
{
    private int _age;
    public int Age
    {
        get => _age;
        private set => _name = value;
    }
}
```

通過自動實作屬性設置不同的訪問層級
```CSharp
class Member
{
    public int Age { get; private set; }
}
```

建立唯讀屬性的方式就是直接省略 `set` 存取器
```CSharp
class Member
{
    private int _age;
    public int Age
    {
        get => _age;
    }
}
```

使用自動實作屬性建立唯讀屬性，且使用屬性初始化器來初始化
```CSharp
class Member
{
    public int ID { get; } = Guid.NewGuid().ToString();
}
```

唯讀屬性也可明顯地在建構函式（Constructors）中初始化
```CSharp
public class Member
{
    // property
    public string Name { get; }
    
    // constructor
    public Member(string name) => Name = name;
}
```

`get` 存取器的屬性可以使用表達式屬性實現
```CSharp
public class Member
{
    public Member(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public string FirstName { get; }
    public string LastName { get; }
    public string FullName => $"{FirstName} {LastName}";
}
```

### Methods（方法）
方法的宣告語法
```CSharp
[modifiers] return_type MethodName([parameters])
{
    // Method body.
}
```

表達式的方法，使用 `=>` 實現只有一條語句的方法
```CSharp
public bool IsSquare(Rectangle rect) => rect.Height == rect.Width;
```

方法的重載簽章即方法名稱相同，但宣告的參數個數或資料型別不同
```CSharp
// 資料型別不同的方法重載
class Displayer
{
    public void Display(string result)
    {
        // implementation
    }
    
    public void Display(int result)
    {
        // implementation
    }
}

// 參數個數不同的方法重載
class Displayer
{
    public void Display(int x)
    {
        // implementation
    }
    
    public void Display(int x, int y)
    {
        // 也可 invoke 另一個重載的方法
        Display(x, y, 10);
    }
    
    public void Display(int x, int y, int z)
    {
        // implementation
    }
}
```

明確的調用方法參數
```CSharp
public void Resize(int x, int y, int height, int width)

// 調用方法
r.Resize(10, 20, 30, 40);

// 明確調用
r.Resize(x: 10, y: 20, width: 40, height: 30);
```

參數也可以是可選的，可選參數必須提供預設值，還必須是方法定義中最後的參數
```CSharp
public void Display(int x, int y = 50)
{
    Console.WriteLine(x + y);
}
```

該方法可使用一個或兩個參數來調用，當傳遞一個參數時，Compiler 會修改方法的 invoke，給第二個參數傳遞 50
```CSharp
Display(10);
Display(10, 20);
```

添加 `params` 關鍵字可成為個數可變的參數，可以使用任意數量的參數 invoke 方法，且在方法定義中必須是最後一個參數，若傳遞的參數型別不同，可將 `int[]` 改為使用 `object[]`
```CSharp
pubilc void Display(params int[] data)
{
    foreach(var x in data)
        Console.WriteLine(x);
}
```

### Constructors（建構函式）
建構函式即宣告一個與類別同名的方法，該方法沒有返回類型。一般情況下，不需要為類別提供建構函式，Compiler 會自動生成一個基本的建構函式，也就是隱式提供一個空的建構函式
```CSharp
class Member
{
    // constructor
    public Member()
    {
    }
}
```

建構函式遵循與其他方法相同的規則，即可為建構函式提供方法多載，只需將方法簽章有明顯區別即可
```CSharp
class Member
{
    public Member()
    {
        // construction code
    }
    
    // another overload
    public Member(string name)
    {
        // consstruction code
    }
}
```

若提供帶有參數的建構函式，而未提供空的建構函式，則 Compiler 不會自動生成默認的建構函式（空建構子），意思是在沒有定義任何建構函式時，Compiler 才會自動生成基礎建構函式，例如下列範例將不會隱式地提供其他建構函式，如果使用無參數的建構函式實例化 Member 物件，則會得到一個編譯錯誤
```CSharp
class Member
{
    private string _name;
    public Member(string name)
    {
        _name = name;
    }
}
```

建構函式與方法相同的規則，故也能通過表達式來實現
```CSharp
public class Member
{
    private string _name;
    public Member(string name) => _name = name;
}
```

從建構函式中調用其他建構函式，如下，在一個類別中有幾個建構函式，以容納某些可選參數，這些建構函式包含一些共同程式碼
```CSharp
class Car
{
    private string _name;
    private uint _wheels;
    
    public Car(string name, uint wheels)
    {
        _name = name;
        _wheels = wheels
    }
    
    public Car(string name)
    {
        _name = name;
        _wheels = 4;
    }
    
    // other construction or code.
}
```

上述例子而已，兩個建構函式初始化相同的欄位，故最好把相同的程式碼放在一個地方，C# 提供一個特殊語法為建構函式初始化器，可用以實現此目的，在帶有一個參數的建構函式執行之前，會先執行代有兩個參數的建構函式，此地方的 `this` 關鍵字僅調用參數最匹配的建構函式
```CSharp
class Car
{
    private string _name;
    private uint _wheels;
    
    public Car(string name, uint wheels)
    {
        _name = name;
        _wheels = wheels;
    }
    
    public Car(string name): this(name, 4)
    {
    }
    
    // other construction or code.
}
```

## struct（結構）
結構與類別非常類似，不同之處為結構是 Value Type（實值類型）儲存於 stack 上，且不支援繼承，較小的資料類型使用結構可提高性能。例如提供一個可儲存每件家具的尺寸大小模型，因不需要很多方法和使用繼承，且內部只需儲存兩個 `double` 型別的資料，沒有過多複雜的邏輯處理，此案例就可使用 `struct` 代替 `class`，
```CSharp
public struct Dimensions
{
    public double Length { get; }
    public double Width { get; }
    
    public Dimensions(double length, double width)
    {
        Length = length;
        Width = width;
    }
    
    // 添加表達式屬性
    public double Diagonal => Math.Sqrt(Length * Length * Width * Width)
}
```

結構在未提供建構函式時，Compiler 會自動生成一個基礎建構函式，與類別相同。

結構雖是 Value Type，語法上也可使用與類別相同的 `new` 關鍵字，但 `new` 關鍵字的作用卻完全不相同，`new` 並不分配 stack 中的記憶體，而是根據傳送給它的參數，調用對應的建構函式，初始化所有欄位
```CSharp
// 合法寫法
var point = new Dimensions();
point.Length = 3;
point.Width = 6;

// 更合法的寫法
Dimensions point;
point.Length = 3;
point.Width = 6;
```

在宣告結構時，實際上是在為整個結構在 stack 中分配記憶體空間，故不須使用 `new` 就可直接賦值。但下列程式碼會產生編譯錯誤，因為結構的變數尚未初始化
```CSharp
Dimensions point;
double d = point.Length;
```

## 按值和按址傳遞參數
傳值和傳址（By Value & By Reference）

假定有兩個方法分別傳入一參數為類別和結構，並在方法內改變屬性值，在方法調用結束後其值會因傳入參數類型而有所不同
```CSharp

struct A
{
    public int X { get; set; }
}

class B
{
    public int X { get; set; }
}

// 傳入參數為 struct
static void ChangeA(A a)
{
    a.X = 2;
}

// 傳入參數為 class
static void ChangeB(B b)
{
    b.X = 2;
}
```

在 `Main()` 方法中分別實例化 A 和 B 物件，並調用適當的 `Change` 方法，最後輸出 X 的值

```CSharp
static void Main()
{
    A a1 = new A { X = 1 };
    ChangeA(a1);
    Console.WriteLine(a1.X);

    B b1 = new B { X = 1 };
    ChangeB(b1);
    Console.WriteLine(b1.X);
}
```

以上述例子來看，若是傳入參數為結構，則輸出為 1，若是類別則輸出為 2。因為結構屬於按值傳遞，故在傳遞參數給 `Change` 方法時，會在記憶體中複製 `a1` 結構成為 `a`，將副本 `a` 傳遞給方法使用，當方法結束調用時，會將其銷毀，故在 `Main()` 方法輸出 `a1.X` 的屬性值時依然是原本的結構，屬性值也依然是 1；而類別是屬於按址傳遞，調用 `Change` 方法時會直接將類別 `b1` 的記憶體位址提供給 `Change` 方法參數使用，即 `b` 參數的位址等同於 `b1` 位址，故在方法內改變其屬性值 X 為 2 時，該位址所儲存的值也等同於被修改，因此 `Main()` 方法輸出 X 屬性值就會是 2。

### ref
假設傳遞的參數為 Value Type，但想使用按址傳遞的方式，就可使用 `ref` 修飾符達到目的，例如原先按值傳遞的結構欲改用按址傳遞方式進行，在方法參數前添加 `ref` 修飾符，並且在調用方法時為傳遞的參數也添加 `ref` 修飾詞，最後輸出結果就上述類別的輸出相同即屬性值 X 為 2。

```CSharp
static void Main()
{
    A a1 = new A { X = 1 };
    ChangeA(ref a1);
    Console.WriteLine(a1.X);
}

static void ChangeA(ref A a)
{
    a.X = 2;
}
```

類別使用 `ref` 修飾詞一般用法看不出差異，但若在方法內為參數重新分配一個物件，則會有所不同，例如下方程式碼最終輸出的屬性 X 值為 2，因為 `Main()` 方法的 `b1` 仍然引用屬性值為 2 的舊物件，新物件只存在於 `Change` 方法中的 `b`，故方法調用結束後也會將其銷毀
```CSharp
static void ChangeB(B b)
{
    b.X = 2;
    b = new B { X = 3 };
}
```

若相同方法添加 `ref` 修飾詞則結果會不同，方法內建立新物件 B 並指給 `b`，此時 `b` 會等同於 `b1` 物件，故輸出為 3
```CSharp
static void ChangeB(ref B b)
{
    b.X = 2;
    b = new B { X = 3 };
}
```

## 可 Null 型別

## enum（列舉）

## partial（部分類別）

## Extension Method（擴展方法）

## Object
