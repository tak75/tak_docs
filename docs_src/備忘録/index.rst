備忘録
======

-------------------------------------------
androidスマホでindex.htmlファイルを開く方法
-------------------------------------------

Google Drive や Dropbox などのクラウドサービスにある index.html ファイルを開くことはできない。
正確には、できないわけではなく、そのファイル自体をブラウザで開くことはできるが、そのページに記載されているリンクページが開けない。
ではどうするか。
下記のように、一旦ローカルにコピーして開くしかなさそうである。

1. クラウドサービス内のファイルをローカルにコピーする

   まず、アプリ "ESファイルエクスプローラ" にクラウドサービスを登録する。
   （ ``左スライドメニュー->ネットワーク->クラウド->新規`` にて、登録したいクラウドサービスを選択）
   次いで、コピーしたいディレクトリをローカルにコピーする（どこでもよい）。

2. ブラウザでアドレスを直打ちする

   Chrome などのブラウザを開き、アドレスバーに index.html ファイルのパスを直打ちする。
   ``file:///storage/emulated/0/html/index.html`` などの具合である。
   このアドレスをブックマークに登録しておけば、後はブックマークから開くことができる。


----------------------
TortoiseGitの使い方
----------------------

自宅サーバでリポジトリを管理する
---------------------------------

* `TortoiseGitで新規プロジェクトを作成してからリモートにプッシュするまでの手順 <http://ohexuan-note.hatenablog.jp/entry/2015/08/24/154611>`_