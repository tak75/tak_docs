import RPi.GPIO as GPIO
import time

GPIO.setmode(GPIO.BCM)

gp_out = 4
GPIO.setup(gp_out, GPIO.OUT)
servo = GPIO.PWM(gp_out, 50) 

servo.start(0.0)

servo.ChangeDutyCycle(2.5)
time.sleep(0.5)

servo.ChangeDutyCycle(12.0)
time.sleep(0.5)

servo.ChangeDutyCycle(2.5)
time.sleep(0.5)

GPIO.cleanup()
