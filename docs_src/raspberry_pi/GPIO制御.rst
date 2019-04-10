==========
GPIO制御
==========

GPIO制御モジュール
===================

GPIO制御は、pigpio が最良である。
RPi.GPIO、およびWiringPiの不満点を完全に解消している。

http://karaage.hatenadiary.jp/entry/2017/02/10/073000

.. csv-table::
   :header-rows: 1

   項目, **pigpio** , RPi.GPIO, WiringPi 
   高精度PWM, **32本** , 0本, 2本  
   入力割り込み, **有り** , 有り, 無し  
   リモートからの制御, **有り** , 無し, 有り(+WebIOPi) 
   対応言語, python/C, python, python/C  

pigpio 有効化方法
===================

1. :numref:`GPIO制御_pigpio設定` のように、リモートGPIOを有効に設定する
2. pigpio デーモンを有効化する::

    sudo systemctl enable pigpiod

3. 念のため、pigpio デーモンの状態を確認する::

    systemctl status pigpiod
    # runnning状態となっていればOK

.. figure:: images/GPIO制御_pigpio設定.png
   :name: GPIO制御_pigpio設定

   リモートGPIO有効化

pigpio 使用方法
=================
