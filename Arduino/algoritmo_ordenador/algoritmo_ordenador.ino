int arranjo[] = {31, 41, 59, 26, 41, 58};
int qtd_elementos;



void setup() {
  Serial.begin(9600);
  qtd_elementos = sizeof(arranjo)/sizeof(int);  
}

void loop() {
  for ( int j = 2; j <= qtd_elementos ; j++) {
    int key = arranjo[j];
    int i = j - 1;
    while (i > 0 && arranjo[i] < key) {
      arranjo[i + 1] = arranjo[i];
      i = i - 1;
      }
    arranjo[i + 1] = key; 
    }
  for ( int j = 0; j <= qtd_elementos ; j++) {
    Serial.println(arranjo[j]);
    delay(1000);
    }
}
