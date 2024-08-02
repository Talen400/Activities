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
  Serial.println("BORAAAA CARAIIIII");
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
          analogWrite(3, velocidadeCanal.toInt());
          analogWrite(4, velocidadeCanal.toInt());
          }
        if(canal == "F") {
          analogWrite(3, LOW);
          analogWrite(4, LOW);
          }
          
        //PARA TRÀS (BATERIA)
        
        if(canal == "b") {
          analogWrite(2, velocidadeCanal.toInt());
          analogWrite(5, velocidadeCanal.toInt());
          }
        if(canal == "B") {
          analogWrite(2, LOW);
          analogWrite(5, LOW);
          }

        //DIREITA
        
        if(canal == "d") {
          analogWrite(4, velocidadeCanal.toInt());
          }
        if(canal == "D") {
          analogWrite(4, LOW);
          }

        //ESQUERDA
        
        if(canal == "e") {
          analogWrite(3, velocidadeCanal.toInt());
          }
        if(canal == "E") {
          analogWrite(3, LOW);
        }

        //ROTAÇÃO PARA A DIREITA
        
        if(canal == "z") {
          analogWrite(2, velocidadeCanal.toInt());
          analogWrite(4, velocidadeCanal.toInt());
          }
        if(canal == "Z") {
          analogWrite(2, LOW);
          analogWrite(4, LOW);
          }

        //ROTAÇÃO ESQUERDA
        
        if(canal == "x") {
          analogWrite(3, velocidadeCanal.toInt());
          analogWrite(5, velocidadeCanal.toInt());
          }
        if(canal == "X") {
          analogWrite(3, LOW);
          analogWrite(5, LOW);
          }
  
        Serial.println(canal); // Letra Minuscula Liga e letra Maiuscula Desliga
        Serial.println(velocidadeCanal.toInt());
}
