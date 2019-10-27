=============
Flask基本機能
=============


ルーティング
============

* <変数名>にて値を取得できる::

    @app.route('/rt_variable/<var>')
    def fn_rt_variable(var=None):
      return f'var = {var}, type(var) = {escape(type(var))}'

* 変数の型を制約することもできる::

    @app.route('/rt_variable_i/<int:var>')
    @app.route('/rt_variable_f/<float:var>')
    @app.route('/rt_variable_p/<path:var>')
    @app.route('/rt_variable_u/<uuid:var>')

* 既定の値のみを受付けるようにすることもできる。以下の例では、"s1" or "s2" or "s3"のみを受付ける::

    @app.route('/rt_variable_a/<any(s1,s2,s3):var>')

* 変数が複数ある場合や、各々の変数の初期値をある場合::

    @app.route('/rt_variable_m/end')
    @app.route('/rt_variable_m/<s1>/end')
    @app.route('/rt_variable_m/<s1>/<s2>/end')
    def fn_rt_variable_m(s1=None, s2='default'):
      return f's1 = {s1}, s2 = {s2}'

テンプレート
============

http://python.zombie-hunting-club.com/entry/2017/11/03/223503

http://www.subarunari.com/entry/2017/09/30/003944

* Flaskのデフォルトのテンプレートエンジンは jinja2 で HTML と Python のコードを同居させることができる。
* テンプレート（～.html）はアプリケーションルート配下の templates ディレクトリ以下に置く。
* テンプレート利用のためのインポート::

    from flask import render_template

* 使用例::

    @app.route('/ex_template')
    @app.route('/ex_template/<t1>')
    def fn_template(t1=None):
        return render_template('template_example.html', var=t1)

* テンプレートhtmlファイル例::

    <!doctype html>
    <title>Template Example</title>
    {% if var %}
    <h1>var:{{var}}</h1>
    {% else %}
    <h1>var is None.</h1>
    {% endif %}

* {{...}} で囲われた部分がPhthonのコード。
* {{...}} はPythonの値をHTMLに出力するために用いるもので、Directiveと呼ぶ。
* {%...%} はif文などの式を埋め込みたい場合に用いるもの。

リクエストオブジェクト
======================

* リクエストオブジェクト利用のためのインポート::

    from flask import request

* 使用例::

    @app.route('/ex_req', methods=['GET', 'POST'])
    def fn_req():
        print(request.method)
        print(request.path)
        print(request.content_length)
        print(request.mimetype)

        print(request.args.get('u1'))
        print(request.args['u2'])
        print(request.args.getlist('u1'))

        print(request.form.get('f1'))
        print(request.form['f2'])
        print(request.form.getlist('f2'))

        print(request.headers.get('Connection'))
        print(request.headers['Connection'])
        print(request.headers.getlist('Connection'))

        return 'call fn_req().'

リダイレクト関数
================

* リダイレクトとは、処理中のページから別のページ（ファイル）へ処理を移す方法
* クラアイアントがページXを要求すると、サーバがページYを要求する指示をクライアントに戻す。これによって“クライアントは自動的に”ページYを要求し、結果としてページYがクライアントに戻される（ページXとページYは、必ずしも同一サーバからのレスポンスではない）。（:numref:`リダイレクト`）

    .. figure:: images/リダイレクト.jpg
       :name: リダイレクト

       リダイレクト

* リダイレクト関数利用のためのインポート::

    from flask import redirect

* 使用例::

    @app.route('/ex_redirect')
    def fn_redirect():
        return redirect(url_for('fn_rt_variable'))
        
* 上記使用例では、"fn_rt_variable"関数のルーティングにリダイレクトされ、"http://localhost:5000/ex_redirect/"と入力しEnterキーを押すと、"http://localhost:5000/rt_variable/"にURL表示が変わる。

* デフォルトでは、httpステータスコード302でリダイレクトされる。任意のステータスコードでリダイレクトしたい場合は、以下のように"code="を付ける::
 
    @app.route('/ex_redirect')
    def fn_redirect():
        return redirect(url_for('fn_rt_variable'), code=301)

エラー処理
==========

* 例外の発生方法について

    * abort関数利用のためのインポート::

        from flask import abort

    * 使用例::

        @app.route('/ex_abort/<int:var>')
        def fn_abort(var):
            abort(var)          # httpステータスコード=varの例外を発生させる

* 所定コードの例外の捕捉方法について

    * 使用例::

        @app.errorhandler(400)      # コード400のみを捕捉する
        def fn_error_handler(error):
            print(error)
            return 'call fn_error_handler().'

* 全てのHTTP例外の捕捉方法について

    * 必要なインポート::

        import werkzeug

    * 使用例::

        @app.errorhandler(werkzeug.exceptions.HTTPException)
        def fn_error_handler(error):
            print(error)
            return 'call fn_error_handler().'

* ZeroDivision例外の捕捉方法について

    * 使用例::

        @app.errorhandler(ZeroDivisionError)
        def fn_error_handler(error):
            print(error)
            return 'call fn_error_handler().'

        @app.route('/ex_zderr')     # ZeroDivision例外発生テスト用
        def fn_zderr():
            i = 1 / 0
            return 'call fn_zderr().'

ファイルアップロード
====================

    * 使用例::

        @app.route('/ex_upload', methods=['GET', 'POST'])
        def fn_upload():
            if request.method == 'POST' and 'file' in request.files:
                f = request.files['file']
                f.save('upload_files/' + secure_filename(f.filename))
                return 'file uploaded.'
                
            return '''
            <!doctype html>
            <title>Upload</title>
            <form method="post" enctype="multipart/form-data">
            <input type="file" name="file">
            <input type="submit" value="Upload">
            </form>
            '''

    .. note:: secure_filename()関数はセキュアなファイル名を作成する関数であり、ファイル名のパス区切り文字、スラッシュ、さらにはパス内の非ASCII文字にいたるまでを取り去る。
        使用するためには、"from werkzeug.utils import secure_filename" が必要
