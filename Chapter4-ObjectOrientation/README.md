# Chapter 4 - Object-Oriented Programming with C#
紀錄此章節學習的知識

### 物件導向
物件導向（Object Oriented or OO）三個重要概念為**繼承**、**封裝**和**多型**

### 繼承的類型
- 單一繼承：表示一個類別可以衍生自一個基底類別
- 多重繼承：允許一個類別衍生自多個基底類別，C# 不支援多重繼承，但允許介面多重繼承
- 多層繼承：允許繼承有更大的層次結構，如 Class B 衍生自 Class A，而 Class C 衍生自 Class B，因此 Class B 可稱為中間基底類別，而 Class C 則繼承 Class A 和 Class B 中宣告的所有成員
- 介面繼承：允許介面多重繼承

### 類別與結構
類別支援繼承，結構不支援繼承，但兩者皆可實現介面繼承
- 結構衍生自 `System.ValueType`
- 類別衍生自 `System.Object`

## 繼承實現
宣告一個類別衍生自另一個類別
```CSharp
class MyDerivedClass : MyBaseClass
{
    // members
}
```
同時衍生自基底類別或介面，則使用逗號隔開，結構繼承介面的寫法相同
```CSharp
class MyDerivedClass : MyBaseClass, IInterface1, IInterface2
{
    // members
}
```

如果類別沒有指定基底類別，Compiler 會假定 `System.Object` 是基底類別，因此衍生自 Object 類別與不定義基底類別的效果事相同的
```CSharp
class MyClass // implicitly derives from System.Object
{
    // members
}
```

### 虛擬方法
為基底類別添加 `virtual` 關鍵字，就可在衍生類別中重寫該方法
```CSharp
public class Shape
{
    public virtual void Dras() => Console.WriteLine($"Shape with {Position} and {Size}");
}
```

也可把屬性宣告為 `virtual`
```CSharp
public virtual Size size { get; set; }
```

覆寫方法時必須使用 `override` 關鍵字
```CSharp
public class Rectangle : Shape
{
    public override void Draw()
    {
        //base.Draw();
        Console.WriteLine($"Rectanlge with {Position} and {Size}");
    }
}
```

### 隱藏方法
如果簽章相同的方法在基底類別和衍生類別中都進行了宣告，但該方法沒有宣告為 `virtual` 和 `override`，衍生類別方法就會隱藏基底類別方法。假設衍生類別添加一個新方法為 `Move`，未來決定要擴展基底類別也添加一個方法為 `Move`，此時編譯器會提出一個警告訊息，因為出現一個潛在的方法衝突，故會將基底類別的方法隱藏，但這不影響編譯，若本意確定要使用衍生類別的方法，它將提醒在方法前使用 `new` 關鍵字來隱藏方法，以避免編譯器出現警告訊息。
```CSharp
public class Ellipse : Shape
{
    new public void MoveBy(int x, int y)
    {
        Position.X += x;
        Position.Y += y;
    }
}
```

### 調用基底類別的方法
當衍生類別衍生自基底類別，想在衍生類別的覆寫方法中調用基底類別的虛擬方法，可以使用 `base` 關鍵字來調用，語法為 `base.<MethodName>()`
```CSharp
// 在覆寫方法中調用基底類別的 move 虛擬方法
public override void Move(Position position)
{
    Console.WriteLine("Rectangle ");
    base.Move(position);
}
```

### 抽象類別和抽象方法
把類別和方法宣告為抽象使用 `abstract` 關鍵字，但宣告為抽象的類別不能實例化，抽象方法不能直接實現，必須在非抽象的衍生類別中覆寫，如果類別中包含抽象方法，那麼該類別也必須宣告為抽象類別。
```CSharp
public abstract class Shape
{
    public abstract void Resize(int width, int height);
}
```

若衍生類別繼承自抽象類別，必須實作所有抽象成員，否則 Compiler 會提出「未實作繼承的抽象成員」的錯誤訊息

使用抽象類別時，可以宣告抽象類別的變數，但不能實例化它，但可以實例化衍生類別，並將其指派給抽象類別的變數
```CSharp
// 宣告 Shape 抽象類別，實例化 Ellipse 類別並指派給 s
Shape s = new Ellipse();
DrawShape(s);
```

### 密封類別和密封方法
若類別希望不允許衍生成子類別，則可使用 `sealed` 關鍵字，則該類別不可被繼承
```CSharp
sealed class FinalClass
{
    // ...
}

class DerivedClass : FinalClass // wrong. Cannot derive from sealed class.
{
    // ...
}
```

密封方法類似密封類別，無法被覆寫
```CSharp
class DerivedClass : MyClass
{
    // 無法覆寫繼承的成員
    //public override void FinalMethod()
    //{

    //}
}

class MyClass : MyBaseClass
{
    public sealed override void FinalMethod()
    {
        // implementation
    }
}

class MyBaseClass
{
    public virtual void FinalMethod()
    {

    }
}
```
