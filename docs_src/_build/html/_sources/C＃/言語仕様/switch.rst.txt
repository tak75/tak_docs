======
switch
======

パターンマッチングの拡張
========================

* C# 8からの仕様
* https://ufcpp.net/blog/2018/12/cs8switchexpr/
* switch構文: var y = x switch { ... } 
* 以下の1,2は同一

  .. code-block:: csharp
    
    // 1
    public void M(年号 e)
    {
        int y;
        switch (e)
        {
            case 明治:
                y = 45;
                break;
            case 大正:
                y = 15;
                break;
            case 昭和:
                y = 64;
                break;
            case 平成:
                y = 31;
                break;
            default: throw new InvalidOperationException();
        }
    }

  .. code-block:: csharp

    // 2
    public void M(年号 e)
    {
        var y = e switch
        {
            明治 => 45,
            大正 => 15,
            昭和 => 64,
            平成 => 31,
            _ => throw new InvalidOperationException()
        };
    }
