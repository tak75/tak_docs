========
samba
========

インストール
=============

  ::
    
    sudo apt-get install samba samba-common samba-common-bin

設定
====

1. smb.confを開く。::

    $ sudo leafpad /etc/samba/smb.conf  # Xwindow使用時
    $ sudo vim /etc/samba/smb.conf      # Xwindow未使用時

2. 開いたファイルに以下を追加する。[share]はファイルの末尾に追加する。::

    [global]
    dos charset = CP932
    unix charset = UTF-8
    
    [share]                 # 外部から接続した際に見える共有名となる
    path = /home/pi/Public  # 共有したいディレクトリのパス名を設定
    valid users = pi        # 指定したユーザだけが利用できる
    writable = yes          # 共有フォルダに書き込めるように設定
    guest ok = no           # ゲストユーザでの接続を許可
    guest only = no         # ゲストユーザのみ接続を許可
    create mode = 0777
    directory mode = 0777

起動
====

* 上記設定直後に、設定内容をsambaに反映させるには、以下を実行する。::

    $ sudo /etc/init.d/samba reload

* システム起動時に自動的に起動させる場合は、以下を実行する。::

    $ sudo update-rc.d samba defaults   # 自動起動させる
    $ sudo update-rc.d samba remove     # 自動起動させない

備考
====

* smb.conf に [homes] の記載があるが、これはユーザのホームディレクトリを **Readonly** で共有するための設定である。
  外部から接続した際に見える共有名はユーザ名（例えば **pi**）となる。

参考
====

* `Sambaの設定（共有フォルダの追加） <http://www.uetyi.com/server-const/entry-23.html>`__
