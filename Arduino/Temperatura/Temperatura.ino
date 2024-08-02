/*
0V = 0;
5V = 1023;
10 mV = 1C;

Tensão em A0 é : (Tensão em A0)*(5.0/1023)
temp = Tensão em A0/10mV

Logo

temp= ((valor_lido_A0)*(5.0/1023))/10mV

Então : temp= ((valor_lido_A0)*(5.0/1023))/0.010
*/

#define pino A1
float temp = 0.0, ultimaTemp = 0.0;
void setup() {
  Serial.begin(9600);
}

void loop() {
  temp = ((analogRead(pino))*(5.0/1023))/0.010;
  Serial.println(temp);
}
