#include <MMA7660.h>
#include <Wire.h>
#include <SoftwareSerial.h>

#define rxPin 0
#define txPin 1

MMA7660 accelemeter;
int dt = 10; // in milliseconds
double k = .15; // distance between accels in meters
double g = 9.81; // in m/s^2
int t = 5; // amount of filtering
int triggerpin = 2;
SoftwareSerial mySerial = SoftwareSerial(rxPin, txPin);

void setup() {
  Serial.begin(9600);
  accelemeter.init();
  pinMode(rxPin, INPUT);
  pinMode(txPin, OUTPUT);
  mySerial.begin(9600);
}

float ax = 0;
float ay = 0;
float az = 0;
float axavg = 0;
float ayavg = 0;
float azavg = 0;
double pitch = 0; // in degrees
double yaw = 0;
double roll = 0;
double vyaw = 0; // in degrees/second

void loop() {
  Serial.flush();
  accelemeter.getAcceleration(&ax, &ay, &az); // in units of g
  axavg = (axavg*t*1.5+ax)/(t*1.5+1);
  ayavg = (ayavg*t+ay)/(t+1);
  azavg = (azavg*t+az)/(t+1);
  double ax2 = readLine();
  int shoot = digitalRead(triggerpin);
  pitch = -atan2(-azavg,ayavg)*180/3.14159-90;
  roll = atan2(axavg,azavg)*180/3.14159;
  double ayaw;
//  if(abs(pitch)<70 && abs(roll)<70) {
//    ayaw = g*(axavg-ax2)/(k*cos(pitch)*cos(roll))*180/3.14159; // in degrees/second^2
//  }
//  if(!isnan(ayaw)&&abs(ayaw)<1000) vyaw += ayaw * dt/1000;
//  ayaw = roll*3.14159/180*g/k;
  if(cos(roll)*cos(pitch)!=0) {
    ayaw = (axavg+g*sin(roll))/(k*cos(roll)*cos(pitch))*.3;
  }
  vyaw += ayaw *dt/1000;
  yaw += vyaw * dt/1000;
  yaw = fmod(yaw+180, 360)-180;
//  vyaw *= 0.99;
//  yaw *= 0.99;
  Serial.print(pitch);
  Serial.print(",");
  Serial.print(yaw);
  Serial.print(",");
  Serial.print(roll);
  Serial.print(",");
  Serial.println(shoot);
  delay(dt);
}

float readLine() {
  String s = "";
  char c;
  while(mySerial.available()) {
    c = mySerial.read();
    if(c=='z') break;
    s.concat(c);
  }
//  Serial.println(s);

  return s.toFloat();
}

