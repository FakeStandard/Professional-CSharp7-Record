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

## struct（結構）

## 按值和按址傳遞參數
傳值和傳址（By Value & By Reference）

## 可 Null 型別

## enum（列舉）

## partial（部分類別）

## Extension Method（擴展方法）

## Object
