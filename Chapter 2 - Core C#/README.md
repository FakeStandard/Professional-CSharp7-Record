# Chapter 2 - Core C#
紀錄此章節學習的知識

### namespace/命名空間
- 將相關類別組合在一起的方式，並使用 `using` 關鍵字來引用命名空間，使用上便可忽略命名空間
- 使用 `using static` 引用命名空間，可啟用類別的所有靜態成員
- 若忽略命名空間的引用，則調用類別方法時必須添加命名空間的名稱，例如 `System.Console.WriteLine("Hello World");`

### Main()
Program 類別包含一個 `Main()` 方法，即所有應用程式的入口點
```CSharp
static void Main()
{
  // do something...
}
```
方法定義格式
```CSharp
[modifiers] return_type MethodName([parameters])
{
  // Method Body
}
```

### Variable/變數
宣告變數語法
```CSharp
datatype identifier;
```
宣告一個資料型別為 `int` 的 `i` 變數，實際上 Compiler 不允許在表達式中使用該變數，必須使用一個值來初始化該變數後才能使用
```CSharp
int i;
```
- 賦予值 `i = 10;`
- 也可同時宣告並初始化 `int i = 10;`
- 在同一條語句中宣告且初始化多個變數，則所有變數皆為相同的資料型別 `int x = 10, y = 20;`
- 同一條語句中不可宣告不同資料型別，必須分別使用單獨語句進行宣告，否則將無法編譯
- 變數在使用前必須進行初始化，初始化之後才能操作該變數

### var
- 類型推斷使用 `var` 關鍵字，使用 `var` 關鍵字替代實際資料型別，Compiler 會根據初始化的值進行推斷變數的資料類型
- 變數必須初始化，否則 Compiler 無法推斷型別

### 常數
- 常數是一個在使用過程中(即生命週期)不會發生變化的變數
- 使用 `const` 關鍵字
- 宣告常數時必須同時初始化，其賦值後不可再改寫 `const int a = 100;`
- 常數是隱式靜態，不必添加 `static` 修飾詞

## 資料型別定義
在 C# 中資料型別依其定義可分為兩種，一種是實值型別（Value Type），一種是參考型別（Reference Type）。兩種型別的差異在於儲存方式，實質型別儲存於 Stack 中，而參考型別儲存於 Managed Heap 中，實質型別在記憶體中會直接儲存資料，參考型別則是儲存資料的參考位置，再透過參考位置找到資料。

例如 `int` 是實質型別，`class` 則是參考型別

## C# 和 .NET 的型別
在 C# 關鍵字中，如 `int`、`short`、`string` 等，在 Compiler 時會 Mapping 到 .NET 的 DataType，例如宣告一個 `int` 變數時，其宣告實際上是 .NET `System.Int32` 的一個實例。

[資料型別對應參考](https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/builtin-types/built-in-types)
