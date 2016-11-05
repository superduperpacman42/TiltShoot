/*
 * Reads accelerometer input, calculates angle of gun, and sends it to Unity through Serial.
 */

#include <MMA7660.h>
#include <Wire.h>

#define rxPin 0
#define txPin 1

MMA7660 accelemeter;
int dt = 10; // in milliseconds
double k = .15; // distance between accels in meters
double g = 9.81; // in meters/second^2
int t = 5; // amount of vertical filtering
int t2 = 7.5; // amount of horizontal filtering
int triggerpin = 2;

void setup() {
  Serial.begin(9600);
  accelemeter.init();
  pinMode(rxPin, INPUT);
  pinMode(txPin, OUTPUT);
}

float ax = 0; // in units of g
float ay = 0;
float az = 0;
float axavg = 0; // in meters/second^2
float ayavg = 0;
float azavg = 0;
double pitch = 0; // in degrees
double yaw = 0;
double roll = 0;

void loop() {
  Serial.flush();
  accelemeter.getAcceleration(&ax, &ay, &az);
  axavg = (axavg*t2+ax)/(t2+1);
  ayavg = (ayavg*t+ay)/(t+1);
  azavg = (azavg*t+az)/(t+1);
  int shoot = digitalRead(triggerpin);
  pitch = -atan2(-azavg,ayavg)*180/3.14159-90;
  roll = atan2(axavg,azavg)*180/3.14159;

  Serial.print(pitch);
  Serial.print(",");
  Serial.print(yaw);
  Serial.print(",");
  Serial.print(roll);
  Serial.print(",");
  Serial.println(shoot);
  delay(dt);
}
