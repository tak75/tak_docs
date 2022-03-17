=====
Prism
=====

引用元
======

* https://elf-mission.net/programming/wpf/episode01/
* https://blog.okazuki.jp/entry/2014/05/07/014133

用語
====

.. glossary::

  Prism

    元々 Microsoft Patterns and Practices で『WPF 及び Silverlight で「複合アプリケーション」を構築するための公式ガイダンス』を意味するコード名。
    現在ではそれがそのままフレームワーク名になり、GitHub でメンテナンスされている。
    MVVMパターンをサポートする機能が含まれている。
    NuGetで「Prism.Core」をインストール

  DI

    Dependeny Injection。
    「依存性注入」と言うデザインパターンの 1 つ。
    依存性とはオブジェクトのことであり、コンストラクタインジェクション（コンストラクタの引数にオブジェクトを渡すこと）などを指す。

  DI コンテナ

    DI を実行するためのライブラリ

  Unity

    元は、Microsoft Patterns and Practices で開発された DI コンテナ。
    DI を実行するために Prism に内蔵された機能。
    型やインスタンスを自由に出し入れできるグローバルなオブジェクト保管庫のようなもので、
    DI コンテナに登録した型やインスタンスはいつでも・どこでも取り出すことができる便利な保管庫。
    Prism.UnityはPrism.Wpfに依存し、Prism.WpfはPrism.Coreに依存するので、Prism.Unityだけインストールすればよい。
    疎結合な関係で作成された部品間でデータをやり取りしたり、テストをし易くすることが可能。

  DryIoc

    GitHub で公開されている OSS の DIコンテナ。
    .NET Framewok、.NET Core で動作する高速で小型のフル機能を備えた .NET 用 IoC コンテナ。
    Unityと比較して、DryIocの方が圧倒的に高速。

  ReactiveProperty

    Reactive ExtensionsをベースとしたMVVMパターンのアプリケーションの作成をサポートするためのライブラリ。
    特徴としては、Reactive Extensionsをベースとしているため、全てをIObservableをベースとして捉えて、
    V, VM, Mすべてのレイヤをシームレスにつなぐことが可能な点。

Unity の使い方
==============

* DI コンテナへインスタンスを登録する

  RegisterInstance メソッドを使用する。
  登録したインスタンスは Singleton のように振舞うので、
  ソリューション内のプロジェクト間で同一のインスタンスを引き回して使う場合に適している

* DI コンテナからインスタンスを取り出す

  IContainerProvider.Resolve メソッドで登録された型やインスタンスを引き出すことが可能。
  ただし、VM 内部で Resolve<WpfTestAppData>() すると、WpfTestAppData に依存していることになるので
  DI パターンとは言えないので要注意。


メモ
====

* 追加した UserControl をデザイナー画面で見るとレイアウトが崩れる場合の対応。
  新しい項目の追加から View を追加した場合は、極小の UserControl が表示されたりする場合がある。
  この場合は、以下の4行をxamlに追加すると解消される。

  .. code-block:: xaml

    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    mc:Ignorable="d"
    d:DesignHeight="300" d:DesignWidth="300"

    