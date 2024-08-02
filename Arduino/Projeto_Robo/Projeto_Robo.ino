#define echo 2
#define trig 3
long duration, cm;

void setup() {
  Serial.begin(9600);
  pinMode(echo, INPUT);
  pinMode(trig, OUTPUT);

  Serial.println("Ativo");
}

void distance() {
  digitalWrite(trig, LOW);
  delayMicroseconds(15);
  digitalWrite(trig, HIGH);
  delayMicroseconds(30);
  digitalWrite(trig, LOW);

  duration = pulseIn(echo, HIGH);
  cm = (duration/2)*0.0343;
  }

void loop() {
  distance();
  Serial.println(cm);
  delay(10);
}
