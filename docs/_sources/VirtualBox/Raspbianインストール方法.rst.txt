==========================
Raspbianインストール方法
==========================

Raspberry Pi Desktop インストール
==================================

* `ここ <https://www.raspberrypi.org/downloads/raspberry-pi-desktop/>`__ からisoファイルをダウンロード

* VirtualBox で新規に Virtual Machine を作成しインストール（詳細は”参照”を参考のこと）

インストール後の処理
====================

* パッケージ更新::

    sudo sh -c 'apt update && apt upgrade -y && reboot'

* ssh有効化（お好みで）

  * 方法1.コマンドライン::

      sudo systemctl enable ssh 
      sudo systemctl restart ssh 

  * 方法2.GUI

    OSメニュー -> 設定 -> Raspberry Pi の設定　で表示される画面より、インタフェース -> SSH を”有効”にチェックする。

VBoxLinuxAdditionsインストール（スクリーンサイズ変更に必要？）
==============================================================

#. ディスク挿入::

    VirtualBoxのMenu: Devices > Insert Guest Additions CD Images...

  .. note:: 既に挿入されている場合はエラーが出る。その場合は次のステップへ進む。次のステップでもエラーが出る場合は一旦ディスクを取り出す？

#. 仮想機内でターミナルを開いて、コマンド実行::

    sudo bash /media/cdrom/VBoxLinuxAdditions.run

#. 待つ

#. 一応、再起動::

    sudo reboot

スクリーンサイズ変更
=====================

* コマンドライン::

    xrandr -s 1920x1200

参考
====

* `[メモ] VirtualBoxにて、Raspberry Pi Desktop(2017-11-16-rpd-x86-stretch版) <https://qiita.com/mt08/items/8c5fc9c754b5eeee447c>`__
