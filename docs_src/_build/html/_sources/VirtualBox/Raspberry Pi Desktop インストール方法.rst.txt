======================================
Raspberry Pi Desktop インストール方法
======================================

インストール
==============

* `ここ <https://www.raspberrypi.org/downloads/raspberry-pi-desktop/>`__ からisoファイルをダウンロード

* VirtualBox で新規に Virtual Machine を作成しインストール（詳細は :ref:`VB_lable_ref` を参照）

.. warning:: Oracle VM VirtualBox マネージャー -> 設定 -> 一般 -> 基本 -> バージョン については、「Debian (64-bit)」ではなく、isoファイルに合わせて「Debian (32-bit)」を選択すること。
  そうしないと、スクリーンサイズ変更やクリップボード共有ができなくなる。

* パッケージ更新::

    sudo sh -c 'apt update && apt upgrade -y && reboot'

VBoxLinuxAdditionsインストール
===============================

本処理は、スクリーンサイズを変更したり、クリップボードの共有を行うために必要。

#. ディスク挿入::

    VirtualBoxのMenu: Devices > Insert Guest Additions CD Images...

  .. note:: 既に挿入されている場合はエラーが出る。その場合は次のステップへ進む。

#. 仮想機内でターミナルを開いて、コマンド実行::

    sudo bash /media/cdrom/VBoxLinuxAdditions.run

#. 待つ

#. 一応、再起動::

    sudo reboot

グループ追加
=============

本処理は、フォルダ共有のために必要。

* ユーザにvboxsfグループを追加::

    sudo adduser pi vboxsf

  .. note:: ユーザが何のグループにも所属していないためフォルダ共有設定ができない。

.. _VB_lable_ref:

参考
====

* `[メモ] VirtualBoxにて、Raspberry Pi Desktop(2017-11-16-rpd-x86-stretch版) <https://qiita.com/mt08/items/8c5fc9c754b5eeee447c>`__
