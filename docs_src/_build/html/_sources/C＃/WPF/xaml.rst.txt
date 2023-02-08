====
xaml
====

参考資料
========

* https://qiita.com/YSRKEN/items/5a36fb8071104a989fb8

最初に準備すべきこと
====================

xamlに以下の4 行を追加すると、土台となる UserControl が指定したサイズで表示されるようになるため、デザイン時に実行時のイメージがつかみやすくなる。

.. code-block:: XML

    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    mc:Ignorable="d"
    d:DesignHeight="500" d:DesignWidth="500"

基本的なこと
============

------------------------------
コンテンツプロパティの指定方法
------------------------------

* ButtonクラスのContentプロパティでは、以下のように省略して書くことができる
* これは、BButtonクラスのContentプロパティが、以下のようにコンテンツプロパティとして指定されているためである

.. code-block:: XML

    // 省略しない場合
    <Button>
        <Button.Content>ボタン名</Button.Content>
    </Button>

    // 省略する場合
    <Button>ボタン名</Button>

.. code-block:: csharp

    // Contentプロパティをコンテンツプロパティとして指定
    [ContentProperty("Content")]
    public class Button
    {
        // その他いろいろ省略

        public string Content { get; set; }
    }

レイアウトコントロール
======================

------------------
Borderコントロール
------------------

https://blog.okazuki.jp/entry/20130104/1357309697

.. code-block:: XML

    <Border 
        Padding="5, 10, 15, 20"
        BorderThickness="5,10,15,20" 
        BorderBrush="Red" 
        CornerRadius="5, 10, 15, 20" 
        Background="Blue">
        <TextBlock Text="中身" Background="Black" Foreground="White" />
    </Border>

---------------------------
BulletDecoratorコントロール
---------------------------

https://blog.okazuki.jp/entry/20130104/1357309697

.. code-block:: XML

    <BulletDecorator Background="Cyan">
        <BulletDecorator.Bullet>
            <TextBlock Text="行頭" Foreground="White" Background="Black" />
        </BulletDecorator.Bullet>
        <TextBlock Text="子要素" Foreground="White" Background="Red" />
    </BulletDecorator>

------------------
Canvasコントロール
------------------

* https://blog.okazuki.jp/entry/20130104/1357315810
* Canvasの上下左右を起点として位置を指定する

.. code-block:: XML

    <Canvas>
        <Button Canvas.Top="10" Canvas.Left="10" Content="Button1" />
        <Button Canvas.Top="10" Canvas.Right="10" Content="Button2" />
        <Button Canvas.Bottom="10" Canvas.Left="10" Content="Button3" />
        <Button Canvas.Bottom="10" Canvas.Right="10" Content="Button4" />
    </Canvas>

---------------------
DockPanelコントロール
---------------------

https://blog.okazuki.jp/entry/20130105/1357395569

.. code-block:: XML

    <DockPanel>
        <!-- メニューやツールバー -->
        <Button DockPanel.Dock="Top" Content="Menu" />
        <Button DockPanel.Dock="Top" Content="Toolbar" />
        <!-- ステータスバー -->
        <Button DockPanel.Dock="Bottom" Content="StatusBar" />
        <!-- ツリーが表示される場所 最低限の幅確保のためMinWidthプロパティを指定 -->
        <Button DockPanel.Dock="Left" Content="Tree" MinWidth="150" />
        <!-- エクスプローラーの右側の領域 -->
        <Button Content="Content" />
    </DockPanel>

---------------------
WrapPanelコントロール
---------------------

* https://blog.okazuki.jp/entry/20130105/1357395569
* 子要素が外にはみ出したときは、折り返して表示
* 子要素サイズをItemHeight、ItemWidthで指定できる

.. code-block:: XML

    <WrapPanel Orientation="Vertical" ItemHeight="75" ItemWidth="50">
        <Button Content="Button" Width="75" />
        <Button Content="Button" Width="75" />
        <Button Content="Button" Width="75" />
        <Button Content="Button" Width="75" />
        <Button Content="Button" Width="75" />
        <Button Content="Button" Width="75" />
        <Button Content="Button" Width="75" />
        <Button Content="Button" Width="75" />
        <Button Content="Button" Width="75" />
    </WrapPanel>

-------------------
ViewBoxコントロール
-------------------

https://blog.okazuki.jp/entry/20130105/1357400239

ScrollViewerコントロール
------------------------

* https://blog.okazuki.jp/entry/20130106/1357475541
* 

.. code-block:: XML



バインド
========

--------------------------------------
コードビハインドのプロパティをバインド
--------------------------------------

* CLRプロパティやDependencyPropertyはViewインスタンス（上でいう子View）に属するもの
* VMのプロパティはDataContextに設定された別インスタンスに属するもの

である。
Viewで自身のCLRプロパティやDependencyPropertyをバインドする場合は、バインドデータに以下の記載が必要

.. code-block:: XML

  RelativeSource={RelativeSource AncestorType=UserControl}

--------------
RelativeSource
--------------

* 自分の親をさかのぼり最初のExpanderのActualWidthを自分のWidthにバインディングする

  .. code-block:: XML

    Width="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Expander}}, Path=ActualWidth}"


------------------
Region名のバインド
------------------

RegionNameはバインディングすることはできるが、バインディングしている名前を途中で変更してはいけない。
例外が発生する。

------------------
イベントのバインド
------------------

.. code-block:: XML

  xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
  xmlns:interactivity="clr-namespace:Reactive.Bindings.Interactivity;assembly=ReactiveProperty.WPF"

  <ComboBox ItemsSource="{Binding ComList}" SelectedItem="{Binding ComSelected.Value}">
      <i:Interaction.Triggers>
          <i:EventTrigger EventName="DropDownOpened">
              <interactivity:EventToReactiveCommand Command="{Binding ComboBoxDropDownOpendCommand}"/>
          </i:EventTrigger>
      </i:Interaction.Triggers>
  </ComboBox>

.. code-block:: XML

  <Window xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity">
      <Grid>
          <TextBlock x:Name="lblMessage">
              <i:Interaction.Triggers>
                  <i:EventTrigger EventName="MouseEnter">
                      <i:InvokeCommandAction Command="{Binding MouseEnterCommand}"/>
                  </i:EventTrigger>
                  <i:EventTrigger EventName="MouseLeave">
                      <i:InvokeCommandAction Command="{Binding MouseLeaveCommand}"/>
                  </i:EventTrigger>
              </i:Interaction.Triggers>
          </TextBlock>
      </Grid>
  </Window>

------------------------------------------
バインドした値がNullやなしの場合の挙動設定
------------------------------------------

* Value=null、もしくは、Value.Project.Value=null の場合は、FallbackValueが実行される
* Value.Project.Value.RemainingTime.Value=null の場合は、TargetNullValueが実行される

.. code-block:: XML

  Text="{Binding Value.Project.Value.RemainingTime.Value, TargetNullValue='-', FallbackValue='--'}"

--------------------------
Staticプロパティのバインド
--------------------------

.. code-block:: XML

  xmlns:data="clr-namespace:XXXXX.Data;assembly=XXXXX"

  <Slider LargeChange="{Binding Source={x:Static data:TestValue}}"/>

トリガ
======

----------------
プロパティトリガ
----------------

自分のプロパティの値に応じて、自分の見た目にかかわるプロパティの値を変える

.. code-block:: XML

  <Trigger Property="IsMouseOver" Value="True">
      <Setter Property="Fill" Value="GreenYellow"/>
  </Trigger>

------------
データトリガ
------------

ViewModel等のプロパティの値に応じて見た目を変える

.. code-block:: XML

  <DataTrigger Binding="{Binding ColorChangeFlag}" Value="true">
      <Setter Property="Fill" Value="Blue"/>
  </DataTrigger>

.. code-block:: XML

  <!--ボタン-->
  <ToggleButton x:Name="Toggle1">
      <Image Stretch="None">
          <Image.Style>
              <Style TargetType="Image">
                  <Setter Property="Source" Value="../Resources/icon_1.png"/>
                  <Style.Triggers>
                      <DataTrigger Binding="{Binding ElementName=Toggle1, Path=IsChecked}" Value="true">
                          <Setter Property="Source" Value="../Resources/icon_2.png"/>
                      </DataTrigger>
                  </Style.Triggers>
              </Style>
          </Image.Style>
      </Image>
  </ToggleButton>

スタイル
========

----------------
トグルボタンの例
----------------

トグルボタンの上部左右角を丸にし、トグルボタン内に三角マークを表示する例

.. code-block:: XML

  <!--上角丸トグルボタン + 三角マーク-->
  <Style x:Key="TopCornerRadiusToggleButton" TargetType="ToggleButton">
      <Setter Property="Background" Value="White" />
      <Setter Property="Foreground" Value="Black" />
      <Setter Property="Template">
          <Setter.Value>
              <ControlTemplate TargetType="ButtonBase">
                  <Border x:Name="border" Background="White" BorderThickness="1" BorderBrush="Black" 
                          SnapsToDevicePixels="true" CornerRadius="6 6 0 0">
                      <Grid>
                          <ContentPresenter x:Name="contentPresenter" Focusable="False" 
                                            HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" 
                                            Margin="5" RecognizesAccessKey="True" 
                                            SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" 
                                            VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                          <Path HorizontalAlignment="Left" VerticalAlignment="Top" Fill="Gray" Stretch="None"  
                                StrokeThickness="0"
                            Data="M 4,44 L 4,50 L 10,50 L 4,44 Z" />
                      </Grid>
                  </Border>
                  <ControlTemplate.Triggers>
                      <Trigger Property="IsEnabled" Value="false">
                          <Setter Property="Background" TargetName="border" Value="Gray"/>
                          <Setter Property="Foreground" Value="Black"/>
                      </Trigger>
                  </ControlTemplate.Triggers>
              </ControlTemplate>
          </Setter.Value>
      </Setter>
  </Style>