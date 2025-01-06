====
Xaml
====

* `Xaml Runの使い方 <https://www.pine4.net/Memo/Article/Archives/429>`__

  * Run要素間に改行が含まれると表示されるテキストの項目間に空白(スペース)が表示されます。
  * <Run>要素のテキストの間でスペースが含まれないようにするには、次のように<Run>要素間に改行が含まれないようにします。

  .. code-block:: XML

    <Run Text="平成"></Run><Run Text="25"></Run>
