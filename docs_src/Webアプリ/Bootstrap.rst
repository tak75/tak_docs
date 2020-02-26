=========
Bootstrap
=========

概要
====

* レスポンシブ対応（※）のWebサイトのレイアウトを、簡単に素早く作れる。
  （※画面幅に応じてレイアウトが変わる）
* 無償、MITライセンス（無償で無制限に使ってよい。ただし、著作権表示が必要。責任は負わない）
* 元々はTwitter Bootstrapと呼ばれており、Twitterのサイト構築に利用されていた。

参考になるWebページ
====================

* `Bootstrap 4 Cheat Sheet <https://hackerthemes.com/bootstrap-cheatsheet/>`__

機能紹介
========

* グリッドシステム

  * 横方向を12に分割し、分解能1/12でレイアウトを簡単に作ることができる::

      <div class="container">
        <div class="row">
          <div class="col-6">A</div>        // 幅6
          <div class="col-4">B</div>        // 幅4
          <div class="col-2">C</div>        // 幅2
        </div>
      </div>

  * 等幅も可能。その場合はcolだけにすればよい::

      <div class="container">
        <div class="row">
          <div class="col">A</div>
          <div class="col">B</div>
          <div class="col">C</div>
        </div>
      </div>

  * 画面サイズに応じてレイアウトを変化させることも可能::

      <div class="container">
        <div class="row">
          <div class="col-lg-6">A</div>        // 幅6
          <div class="col-lg-4">B</div>        // 幅4
          <div class="col-lg-2">C</div>        // 幅2
        </div>
      </div>

  * 入れ子も可能::

      <div class="row">
        <div class="col-sm-9">
          Level 1:9
          <div class="row">
            <div class="col-sm-8">
              Level 2:8
            </div>
            <div class="col-sm-4">
              Level 2:4
            </div>
          </div>
        </div>
        <div class="col-sm-3">
          Level 1:3
        </div>
      </div>

