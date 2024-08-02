int arranjo[] = {31, 41, 59, 26, 41, 58};
int qtd_elementos;
int v = 41;
int YES;
int indice;

void setup() {
  Serial.begin(9600);
  qtd_elementos = sizeof(arranjo)/sizeof(int);  
}

void loop() {
  for(int j = 0; j < qtd_elementos ; j ++) {
    if (arranjo[j] == v){
             YES = arranjo[j];
             indice = j;
        }
  }
  
  if ( YES == v){
    Serial.print("yes! indice: ");
    Serial.println(indice);
    } else {
      Serial.println("NILL");
      }
  delay(1000);
}
