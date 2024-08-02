int trigPin1 = 13;
int echoPin1 = 12;
long duration1, cm1;
int velocidade = 124;

int sensor1 (){
  digitalWrite(trigPin1, LOW);
  delayMicroseconds(5);
  digitalWrite(trigPin1, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin1, LOW);

  pinMode(echoPin1, INPUT);
  duration1 = pulseIn(echoPin1, HIGH);

  cm1 = (duration1/2) / 29.1;
  return cm1;
}

void Frente () {
  analogWrite(5, velocidade);
  analogWrite(6, velocidade);
  }
void Tras () {
  analogWrite(3, velocidade);
  analogWrite(9, velocidade);
  }
void RotacionarDireita () {
  analogWrite(3, velocidade);
  analogWrite(6, velocidade);
  }
void RotacionarEsquerda () {
  analogWrite(5, velocidade);
  analogWrite(9, velocidade);
  }
void Parar () {
  analogWrite(3, 0);
  analogWrite(5, 0);
  analogWrite(6, 0);
  analogWrite(9, 0);
  }
 
void setup () {
  Serial.begin(9600);
  pinMode(trigPin1, OUTPUT);
  pinMode(echoPin1, INPUT);
  
  }

int distancia;
int limite = 30;

void loop() {
  
  
  distancia = sensor1();
  Serial.print(distancia);
  Serial.println(" cm");
  Parar();
  if( distancia > limite) {
    Frente();
    }
  if(distancia < limite){
    RotacionarDireita();
    }   
}
