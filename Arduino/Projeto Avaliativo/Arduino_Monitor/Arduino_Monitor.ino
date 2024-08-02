#define led 12
#define cooler 11
#define trigPin 53    // Trigger
#define echoPin 51    // Echo
#define pont A2
#define ldr A0
#define temp A1

long duration, cm, vTemp;
String Analog, Analog2, Analog3, Analog4, canal ,comando;
int Vel;

void setup() {
    Serial.begin(9600);
    pinMode(led, OUTPUT);
    pinMode(cooler, OUTPUT);
    pinMode(trigPin, OUTPUT);
    pinMode(echoPin, INPUT);
}

void loop() {
 while (Serial.available()) {
    delay(10);
    char byteRec = Serial.read();
    comando += byteRec;
        
    // dados recebidos tipo: "d1000;"
    
    if (byteRec == ';') {
      //Dado enviado
      if (comando.substring(0, 1) == "d") {
         canal = comando.substring(1, 5);
         Vel = (canal.toInt() - 1000);
         //Teste
         analogRead(temp);
         delayMicroseconds(200);
         analogRead(pont);
         // temperatura
         vTemp= analogRead(temp);
         //ultrassonic
         digitalWrite(trigPin, LOW);
         delayMicroseconds(15);
         digitalWrite(trigPin, HIGH);
         delayMicroseconds(30);
         digitalWrite(trigPin, LOW);
 
         pinMode(echoPin, INPUT);
         duration = pulseIn(echoPin, HIGH);
 
         cm = (duration/2) / 29.1;

         //Envio
         Analog = String(map(analogRead(pont), 0, 1023, 0, 255), DEC);
         Analog2 = String(((vTemp*(5.0/1023))/0.010), 0);
         Analog3 = String(cm, DEC);
         Analog4 = String(map(analogRead(ldr), 0, 1023, 0, 255), DEC);
         Serial.println( "@" + Analog + "#" + Analog2 + "$" + Analog3 + "%" + Analog4 + "*" );
         
         analogWrite(led, Vel);
         analogWrite(cooler, Vel);
        }
        comando = "";
        
      }
 }  }
