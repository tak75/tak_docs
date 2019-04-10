======
flask
======

http://python.zombie-hunting-club.com/entry/2017/11/03/223503

http://www.subarunari.com/entry/2017/09/30/003944

* Flaskのデフォルトのテンプレートエンジンは jinja2 で HTML と Python のコードを同居させることができる。
* テンプレートはアプリケーションルート配下の templtates ディレクトリ以下に置く。


例1::

  <!-- user.html -->
  <p>
      {{ user_name }}
  </p>

* {{...}} で囲われた部分がPhthonのコード。
* {{...}} はPythonの値をHTMLに出力するために用いるもので、Directiveと呼ぶ。
* {%...%} はif文なのの式を埋め込みたい場合に用いるもの。

ハマったこと
============

-------------------
UnicodeDecodeError
-------------------

Python2.7でFlaskのアプリケーションを起動したときUnicodeDecodeErrorが出た時の対処法。
Flaskで簡単なアプリを作って起動してみたところ、以下のエラーが発生した。::

  UnicodeDecodeError: 'ascii' codec can't decode byte 0xe3 in position 0: ordinal not in range(128)

これはPython2.7のデフォルトの文字コードがASCIIのため。
以下のようにして文字コードをUTF-8にする必要あり::

  import sys

  reload(sys)
  sys.setdefaultencoding('utf-8')

