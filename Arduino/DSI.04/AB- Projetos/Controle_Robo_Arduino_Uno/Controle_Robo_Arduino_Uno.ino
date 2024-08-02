#include <SoftwareSerial.h>

#define pinBT_RX 10
#define pinBT_TX 11

SoftwareSerial serialBT(pinBT_RX, pinBT_TX); // RX, TX

String comando;
String canal;
String velocidadeCanal;

void setup() {
  Serial.begin(9600);
  serialBT.begin(9600);
  Serial.println("Iniciado!!!");
  pinMode(3, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(9, OUTPUT);
}

void loop() {

  while (serialBT.available()) {
    char byteRec = serialBT.read();
    comando += byteRec;

    if (byteRec == ';') {
      Serial.print("Comando Recebido: ");
      Serial.println(comando);

      if (comando.substring(0,1) == "C") {
        canal = comando.substring(1,2);
           if(canal == "V"){
            velocidadeCanal = comando.substring(2, 6);
            }
        }
      
        comando = ""; 
      }
    }
        
        // PARA FRENTE
        
        if(canal == "f") {
          analogWrite(5, velocidadeCanal.toInt());
          analogWrite(6, velocidadeCanal.toInt());
          }
        if(canal == "F") {
          analogWrite(5, LOW);
          analogWrite(6, LOW);
          }
          
        //PARA TRÀS (BATERIA)
        
        if(canal == "b") {
          analogWrite(3, velocidadeCanal.toInt());
          analogWrite(9, velocidadeCanal.toInt());
          }
        if(canal == "B") {
          analogWrite(3, LOW);
          analogWrite(9, LOW);
          }

        //DIREITA
        
        if(canal == "d") {
          analogWrite(6, velocidadeCanal.toInt());
          }
        if(canal == "D") {
          analogWrite(6, LOW);
          }

        //ESQUERDA
        
        if(canal == "e") {
          analogWrite(5, velocidadeCanal.toInt());
          }
        if(canal == "E") {
          analogWrite(5, LOW);
        }

        //ROTAÇÃO PARA A DIREITA
        
        if(canal == "z") {
          analogWrite(3, velocidadeCanal.toInt());
          analogWrite(6, velocidadeCanal.toInt());
          }
        if(canal == "Z") {
          analogWrite(3, LOW);
          analogWrite(6, LOW);
          }

        //ROTAÇÃO ESQUERDA
        
        if(canal == "x") {
          analogWrite(5, velocidadeCanal.toInt());
          analogWrite(9, velocidadeCanal.toInt());
          }
        if(canal == "X") {
          analogWrite(5, LOW);
          analogWrite(9, LOW);
          }
  
        Serial.println(canal); // Letra Minuscula Liga e letra Maiuscula Desliga
        Serial.println(velocidadeCanal.toInt());
}
