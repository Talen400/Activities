String ler = "1000";
int n;
void setup() {
  pinMode(12, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  n = ler.toInt();
  if(Serial.available()){
    ler = Serial.readStringUntil("/n");
    n = ler.toInt();
    }
    else {
  digitalWrite(12, 1);
  delay(n);
  digitalWrite(12, 0);
  delay(n);
    }
}
