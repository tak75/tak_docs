============================
Sphinxドキュメントの公開方法
============================

ディレクトリ構成
================

::

  github_sphinx_example
  ├── .gitignore
  ├── docs
  │   ├── .nojekyll（Jekyllを使用しないようにするために必要）
  │   ├── 公開するhtmlファイル
  └── docs_src
      ├── build元のrstファイル


.nojekyllファイルの作成方法
===========================

コマンドプロンプトにて、以下入力でOK::

  type null > .nojekyll


参考
====

* `Sphinxで作ったドキュメントをGithubで公開 <https://sky-joker.github.io/github_sphinx_example/#>`__
* `コマンドプロンプト/ファイルサイズ0の空ファイルの作成方法 <https://win.just4fun.biz/?%E3%82%B3%E3%83%9E%E3%83%B3%E3%83%89%E3%83%97%E3%83%AD%E3%83%B3%E3%83%97%E3%83%88/%E3%83%95%E3%82%A1%E3%82%A4%E3%83%AB%E3%82%B5%E3%82%A4%E3%82%BA0%E3%81%AE%E7%A9%BA%E3%83%95%E3%82%A1%E3%82%A4%E3%83%AB%E3%81%AE%E4%BD%9C%E6%88%90%E6%96%B9%E6%B3%95>`__
