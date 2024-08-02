// Projeto 1 - LED piscante
/* Todo o texto dentro
das barras e dos asteriscos
é um comentário, e será
ignorado pelo compilador */
int ledPin = 10;
void setup() {
  pinMode(ledPin, OUTPUT);
}
void loop() {
  digitalWrite(ledPin, HIGH);
  delay(1000);
  digitalWrite(ledPin, LOW);
  delay(1000);
}
