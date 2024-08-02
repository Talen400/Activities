char LD;
void setup() {
  Serial.begin(9600);
  pinMode(53, OUTPUT);

}

void loop() {
  if(Serial.available()){
    LD = Serial.read();
    Serial.println(LD);
     switch (LD){
      case 'l':
      digitalWrite(53, HIGH);
      break;
      case 'd':
      digitalWrite(53, LOW);
      break;
      }
    }
  

}
